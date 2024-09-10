using HealthcareManager.Data;
using HealthcareManager.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HealthcareManager.Repositories
{
    public interface IUserRepository: IHealthcareManagerRepository<ApplicationUser, ApplicationUserDTO>
    {
        Task<IEnumerable<ApplicationUserDTO>> GetUserbyId(List<int> ids);
    }
    public class UserRepository: HealthcareManagerRepository<ApplicationUser, ApplicationUserDTO>, IUserRepository
    {
        protected readonly IUserRepository _userRepository;

        public UserRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory, IUserRepository userRepo) : base(dbContextFactory) 
        {
            _userRepository = userRepo;
        }

        Task<IEnumerable<ApplicationUserDTO>> IUserRepository.GetUserbyId(List<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
