using HealthcareManager.Domain.Entities;
using System.Reflection;

namespace HealthcareManager.Data.DTO
{
    public interface IBaseDTO<UEntity> where UEntity : class
    {
        int CreatedById { get; }
        int LastModifiedById { get; }
        DateTime CreatedDate { get; }
        DateTime LastModifiedDate { get; }
        byte[] TimeStamp { get; }
    }
    public abstract class BaseDTO<TEntity> : IBaseDTO<TEntity> where TEntity : BaseEntity
    {
        protected abstract Func<IQueryable<TEntity>, IQueryable<TEntity>> Select { get; }
        protected abstract Func<IQueryable<TEntity>, IQueryable<TEntity>> SelectSlim { get; }
        public int CreateById { get; set; } = int.MinValue;
        public int LastModifiedById { get; set; } = int.MinValue;
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public byte[] TimeStamp { get; set; }

        public int CreatedById => throw new NotImplementedException();

        protected abstract TEntity ToEntity<D>();
        public abstract BaseDTO<TEntity> FromEntity(TEntity entity);
        public IQueryable<TEntity> ApplySelect(IQueryable<TEntity> query) => Select(query);
        public IQueryable<TEntity> ApplySelectSlim(IQueryable<TEntity> query) => SelectSlim(query);
        public static TEntity ToEntity<D>(D DTO) where D : BaseDTO<TEntity> => DTO.ToEntity<D>();
        public static D FromEntity<D>(TEntity entity) where D: BaseDTO<TEntity>
        {
            var method = typeof(D).GetMethod("FromEntity", BindingFlags.Public | BindingFlags.Instance);
            if(method == null)
                throw new InvalidOperationException($"FromEntity method not found in {typeof(D).Name}");

            var instance = Activator.CreateInstance<D>();
            return (D)method.Invoke(instance, new object[] { entity });
        }
        public static IQueryable<TEntity> ApplySelect<D>(IQueryable<TEntity> query) where D : BaseDTO<TEntity>
        {
            var instance = Activator.CreateInstance<D>();
            return instance.ApplySelect(query);
        }
        public static IQueryable<TEntity> ApplySelectSlim<D>(IQueryable<TEntity> query) where D : BaseDTO<TEntity>
        {
            var instance = Activator.CreateInstance<D>();
            return instance.ApplySelectSlim(query);
        }
    }
}
