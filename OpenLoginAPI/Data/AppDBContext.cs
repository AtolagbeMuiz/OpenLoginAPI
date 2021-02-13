using Microsoft.EntityFrameworkCore;
using OpenLoginAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenLoginAPI.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
        {

        }

        public DbSet<UserRegistrationModel> UserRegistration { get; set; }
    }
}
