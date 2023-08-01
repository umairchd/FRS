using System;
using System.Collections.Generic;
using Cares.Models.DomainModels;
using FRS.Models.DomainModels;

namespace FRS.Models.IdentityModels
{
    /// <summary>
    /// User
    /// </summary>
    public partial class AspNetUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public long UserDomainKey { get; set; }
        public long? EmployeeId { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string ImageName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
        public string UserComments { get; set; }

        public virtual ICollection<UserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<UserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<UserRole> AspNetRoles { get; set; }
    }
}
