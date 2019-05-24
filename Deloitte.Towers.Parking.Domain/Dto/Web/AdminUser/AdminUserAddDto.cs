using Deloitte.Towers.Parking.Domain.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deloitte.Towers.Parking.Domain.Dto.Web.AdminUser
{
    [Validator(typeof(AdminUserAddValidator))]
    public class AdminUserAddDto
    {       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime LastModificationDate { get; set; }
        public bool IsDeleted { get; set; }

        public string Status { get { return (IsActive == true) ? "Active" : "Inactive"; }
            set { } 
        }

        public AdminUserEditDto ToAdminUserEditDto(int id)
        {
            return new AdminUserEditDto
            {
                Id = id,
                Email = Email,
                IsActive = IsActive,
                Status = Status,
                FirstName = FirstName,
                LastName = LastName,
                ModifiedBy = ModifiedBy,
                LastModificationDate = LastModificationDate,
                IsDeleted = IsDeleted
            };
        }
    }
}
