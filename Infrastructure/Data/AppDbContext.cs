using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ApplicationCore.Entities;
using ApplicationCore.Entities.Raw;


namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryBalance> CategoryBalances { get; set; }
        public DbSet<Identity> Identities { get; set; }
        public DbSet<Institution> Institutions { get; set; }

        public DbSet<TransactionsRawOld> TransactionsRawOlds { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Core
            builder.Entity<Account>().ToTable("Account", "Core");
            builder.Entity<Account>().HasKey(p => p.AccountID);
            builder.Entity<Account>().Property(p => p.AccountID);
            builder.Entity<Account>().Property(p => p.Number).IsRequired().HasMaxLength(50);
            builder.Entity<Account>().Property(p => p.ExpireDT);
            builder.Entity<Account>().Property(p => p.IdentityID);
            builder.Entity<Account>().Property(p => p.InstitutionID);
            builder.Entity<Account>().HasOne(p => p.Institution);
            builder.Entity<Account>().HasOne(p => p.Identity);

            builder.Entity<Category>().ToTable("Category", "Core");
            builder.Entity<Category>().HasKey(p => p.CategoryID);
            builder.Entity<Category>().Property(p => p.CategoryID);
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<Category>().Property(p => p.Description).HasMaxLength(255);
            builder.Entity<Category>().Property(p => p.Hierarchy).IsRequired();
            builder.Entity<Category>().Property(p => p.CategoryParentID);
            builder.Entity<Category>().Property(p => p.IconUI);
            builder.Entity<Category>().Property(p => p.CreatedDT);
            builder.Entity<Category>().HasMany(p => p.CategoryBalances);

            builder.Entity<CategoryBalance>().ToTable("CategoryBalance", "Core");
            builder.Entity<CategoryBalance>().HasKey(p => p.CategoryBalanceID);
            builder.Entity<CategoryBalance>().Property(p => p.CategoryBalanceID).IsRequired();
            builder.Entity<CategoryBalance>().Property(p => p.Period).IsRequired().HasMaxLength(20);
            builder.Entity<CategoryBalance>().Property(p => p.DateReference);
            builder.Entity<CategoryBalance>().Property(p => p.TotalExpense);
            builder.Entity<CategoryBalance>().Property(p => p.PlannedExpense);
            builder.Entity<CategoryBalance>().Property(p => p.CategoryID);
            builder.Entity<CategoryBalance>().Property(p => p.CreatedDT).IsRequired();

            builder.Entity<Identity>().ToTable("Identity", "Core");
            builder.Entity<Identity>().HasKey(p => p.IdentityID);
            builder.Entity<Identity>().Property(p => p.IdentityID).IsRequired();
            builder.Entity<Identity>().Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Entity<Identity>().Property(p => p.LastName).IsRequired().HasMaxLength(50);
            builder.Entity<Identity>().Property(p => p.Email).IsRequired().HasMaxLength(200);
            builder.Entity<Identity>().Property(p => p.Phone).HasMaxLength(25);
            builder.Entity<Identity>().Property(p => p.CreatedDT).IsRequired();
            builder.Entity<Identity>().HasMany(p => p.Accounts);

            builder.Entity<Institution>().ToTable("Institution", "Core");
            builder.Entity<Institution>().HasKey(p => p.InstitutionID);
            builder.Entity<Institution>().Property(p => p.InstitutionID).IsRequired();
            builder.Entity<Institution>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<Institution>().Property(p => p.CreatedDT).IsRequired();
            builder.Entity<Institution>().HasMany(p => p.Accounts);


            // Raw
            builder.Entity<TransactionsRawOld>().ToTable("Transactions_Raw_Old_csv", "raw");
            builder.Entity<TransactionsRawOld>().HasKey(p => p.ID);
            builder.Entity<TransactionsRawOld>().Property(p => p.ID);
            builder.Entity<TransactionsRawOld>().Property(p => p.matchedCategoryID);
            builder.Entity<TransactionsRawOld>().Property(p => p.Date);
            builder.Entity<TransactionsRawOld>().Property(p => p.Cod);
            builder.Entity<TransactionsRawOld>().Property(p => p.Category);
            builder.Entity<TransactionsRawOld>().Property(p => p.SubCategory);
            builder.Entity<TransactionsRawOld>().Property(p => p.Payment);
            builder.Entity<TransactionsRawOld>().Property(p => p.Name);
            builder.Entity<TransactionsRawOld>().Property(p => p.Value);
            builder.Entity<TransactionsRawOld>().Property(p => p.Type);
            builder.Entity<TransactionsRawOld>().Property(p => p.Comment);
        }

    }
}
