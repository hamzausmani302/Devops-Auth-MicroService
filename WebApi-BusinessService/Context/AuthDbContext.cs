using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using WebApi_BusinessService.Entities;

namespace WebApi_BusinessService.Models
{
    public class AuthDbContext1: DbContext
    {
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AppMonthRecords> MonthRecords { get; set; }
        public DbSet<AppMonthAttachment> Attachments { get; set; }
        public AuthDbContext1(DbContextOptions options) : base(options)
        {
        }
    }
}
