using HealthcareManager.Domain.Entities;

namespace HealthcareManager.Data.DTO
{
    public class UserRoleDTO : BaseDTO<UserRole>
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string Role {  get; set; }
        public string UserId { get; set; }
        public bool IsAuthorized { get; set; }
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int RoleCodeId { get; set; }
        public string RoleCode { get; set; }
        public int RoleScore { get; set; }
        protected override Func<IQueryable<UserRole>, IQueryable<UserRole>> Select => _userRoles => _userRoles.Select(_userRoles => new UserRole
        {
            Id = _userRoles.Id,
            RoleId = _userRoles.RoleId,
            Role = _userRoles.Role,
            UserId = _userRoles.UserId,
            CreatedBy = _userRoles.CreatedBy,
            CreatedDate = _userRoles.CreatedDate,
            CreatedById = _userRoles.CreatedById,
            IsAuthorized = _userRoles.IsAuthorized,
            LastModifiedBy = _userRoles.LastModifiedBy,
            LastModifiedDate = _userRoles.LastModifiedDate,
            LastModifiedById = _userRoles.LastModifiedById,
            Timestamp = _userRoles.Timestamp,
            User = _userRoles.User,
        });

        protected override Func<IQueryable<UserRole>, IQueryable<UserRole>> SelectSlim => throw new NotImplementedException();

        public override UserRoleDTO FromEntity(UserRole _userRole)
        {
            return new UserRoleDTO
            {
                Id = _userRole.Id,
                RoleId = _userRole.RoleId,
                UserId = _userRole.UserId,
                Role = _userRole.Role.TypeCode != null ? $"{_userRole.Role.Id} {_userRole.Role.Facility.Id} {_userRole.Role.RoleCode.Abbreviation} {_userRole.Role.TypeCode.Abbreviation}" : $"{_userRole.Role.Id} {_userRole.Role.Facility.Id} {_userRole.Role.RoleCode.Abbreviation}",
                RoleScore = (int)_userRole.Role.RoleCode.Score,
                IsAuthorized = _userRole.IsAuthorized,
                FacilityId = _userRole.Role.FacilityId,
                FacilityName = _userRole.Role.Facility.FacilityName,
                RoleCode = _userRole.Role.RoleCode.Abbreviation,
                RoleCodeId = _userRole.Role.RoleCodeId,
                LastModifiedById = (int)_userRole.Role.LastModifiedById,
                LastModifiedDate = _userRole.Role.LastModifiedDate,
                CreateById = (int)_userRole.Role.CreatedById,
                CreatedDate = _userRole.Role.CreatedDate,
                TimeStamp = _userRole.Timestamp,

            };
        }

        protected override UserRole ToEntity<D>()
        {
            throw new NotImplementedException();
        }
    }
}
