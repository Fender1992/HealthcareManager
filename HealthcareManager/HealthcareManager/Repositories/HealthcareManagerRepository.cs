using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using HealthcareManager.Data.Models.ViewModels;
using HealthcareManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Telerik.Blazor.Components.Scheduler.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HealthcareManager.Repositories
{
    public class HealthcareManagerRepository<TEntity, DTO> : IHealthcareManagerRepository<TEntity, DTO> where TEntity : BaseEntity where DTO : BaseDTO<TEntity>
    {
        protected ApplicationDbContext Context { get; set; }
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        protected DbSet<TEntity> _entities;
        private bool _disposed = false;
        public HealthcareManagerRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        protected virtual T CreateDTO<T>(TEntity entity) where T : DTO
        {
            return BaseDTO<TEntity>.FromEntity<T>(entity);
        }
        protected IQueryable<TEntity> ApplySelect(IQueryable<TEntity> query, bool selectSlim)
        {
            return selectSlim ? BaseDTO<TEntity>.ApplySelect<DTO>(query) : BaseDTO<TEntity>.ApplySelect<DTO>(query);
        }

        public async Task<DTO> AddOrUpdateAsync(DTO dto, TEntity entity)
        {
            try
            {
                await CreateContext();
                var e = entity.GetType();
                if (entity.Id == 0 || e.Name == "NewAppointmentForm" || e.Name == "UserDataCustomForm" || e.Name == "DataForm")
                    entity.CreatedDate = DateTime.Now;
                entity.LastModifiedDate = DateTime.Now;
                if (entity.Timestamp is null)
                    Context.Set<TEntity>().Add(entity);
                else
                {
                    var formId = entity.Id;
                    Context.Set<TEntity>().Update(entity);
                }
                await Context.SaveChangesAsync();
                foreach (var navEntry in Context.Entry(entity).Navigations)
                {
                    navEntry.Load();
                }
                DTO d = CreateDTO<DTO>(Context.Entry(entity).Entity);
                return d;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception($"Failed to update entity of type {nameof(TEntity)} : {ex.Message}");
            }
            finally
            {
                Context.ChangeTracker.Clear();
            }
        }
        public async Task<bool> DeleteAsync(TEntity entity)
        {
            try
            {
                await CreateContext();
                Context.Set<TEntity>().Remove(entity);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                var a = Context.Entry(entity);
                var pValues = a.CurrentValues;
                var dbValues = a.GetDatabaseValues();
                a.OriginalValues.SetValues(pValues);
                Context.Set<TEntity>().Remove(a.Entity);
                await Context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async IAsyncEnumerable<DTO> GetAllAsync(bool tracking = false, bool selectSlim = false)
        {
            await CreateContext();
            _entities = Context.Set<TEntity>();

            var query = Context.Set<TEntity>().AsNoTrackingWithIdentityResolution();
            if (tracking)
                query = query.AsTracking();

            var selectQuery = ApplySelect(query, selectSlim);

            foreach (var item in selectQuery.ToList())
            {
                yield return CreateDTO<DTO>(item) ?? throw new InvalidOperationException($"Could not retrieve the entities of type {nameof(TEntity)}");
            }
        }
        public async IAsyncEnumerable<DTO> FindAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = false, bool selectSlim = false)
        {
            var cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            await CreateContext();
            _entities = Context.Set<TEntity>();
            var b = typeof(DTO).Name;

            var query = _entities.Where(predicate).AsNoTrackingWithIdentityResolution();
            if (tracking)
                query = query.AsTracking();

            var selectQuery = ApplySelect(query, selectSlim);

            foreach(var item in selectQuery.ToList())
            {
                yield return CreateDTO<DTO>(item) ?? throw new InvalidOperationException($"Could not retrieve the entities of type {nameof(TEntity)}");
            }
        }

        public async Task<DTO> GetByIdAsync(object id, bool tracking = false)
        {
            if (id == null)
                throw new Exception($"No entity id passed.");
            await CreateContext();
            _entities = Context.Set<TEntity>();

            var b = typeof(DTO).Name;
            var query = b.Equals("AppointmentDTO") || b.Equals("MedicationsDTO")? (IQueryable<TEntity>)Context.Set<Appointment>().Where(x => x.Id == id).AsNoTrackingWithIdentityResolution() : _entities.Where(x => x.Id.ToString() == id.ToString()).AsNoTrackingWithIdentityResolution();
            if(tracking) query = query.AsTracking();
            var selectQuery = ApplySelect(query, false);

            if (selectQuery != null && selectQuery.Count() == 0)
                throw new Exception($"Cannot find entity with id {id}");

            DTO item = CreateDTO<DTO>(selectQuery.ToList().FirstOrDefault());
            if (item == null)
                throw new Exception($"Cannot find entity with id {id}");
            return item;
        }

        private async Task CreateContext()
        {
            if(Context == null || Context.IsDisposed())
                Context = await _dbContextFactory.CreateDbContextAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!_disposed)
            {
                if (disposing)
                    if (Context != null && !Context.IsDisposed()) Context.Dispose();
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
