using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Test.Core.Interfaces;

namespace Test.Core.Model
{
    public class ApplicationUser : IdentityUser, IBaseEntity<string>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        object IBaseEntity.Id
        {
            get
            {
                return this.Id;
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private DateTime? createdDate;
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return createdDate ?? DateTime.UtcNow; }
            set { createdDate = value; }
        }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public bool IsDeleted
        {
            get; set;
        }

        // sign up information

        public string Name { get; set; }
        public Gender Gender { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateOfBirth { get; set; }
    }
}
