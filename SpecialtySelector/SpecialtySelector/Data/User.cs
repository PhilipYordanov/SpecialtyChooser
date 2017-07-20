﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SpecialtySelector.Data
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Departments = new HashSet<Department>();
            this.SubDepartments = new HashSet<SubDepartment>();
        }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<SubDepartment> SubDepartments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}