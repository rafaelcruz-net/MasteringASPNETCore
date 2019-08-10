using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Underwater.Models;

namespace Underwater.Data
{
    public class UserDbContext : IdentityDbContext<UserAccount>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        public DbSet<UserAccount> UserAccounts { get; set; }
    }
}
