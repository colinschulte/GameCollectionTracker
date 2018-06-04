using LiftoffProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiftoffProject.Data
{
    public class AccountDbContext : IdentityDbContext<User>
    {
        public DbSet<User> AppUsers { get; set; }
    }
}
