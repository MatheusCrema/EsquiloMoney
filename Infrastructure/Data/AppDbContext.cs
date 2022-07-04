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
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }


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

            builder.Entity<PaymentType>().ToTable("PaymentType", "Core");
            builder.Entity<PaymentType>().HasKey(p => p.PaymentTypeID);
            builder.Entity<PaymentType>().Property(p => p.PaymentTypeID).IsRequired();
            builder.Entity<PaymentType>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            builder.Entity<PaymentType>().Property(p => p.CreatedDT).IsRequired();
            
            builder.Entity<Transaction>().ToTable("Transaction", "Core");
            builder.Entity<Transaction>().HasKey(p => p.TransactionID);
            builder.Entity<Transaction>().Property(p => p.Type).IsRequired().HasMaxLength(7);
            builder.Entity<Transaction>().Property(p => p.Date).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Name).IsRequired().HasMaxLength(280);
            builder.Entity<Transaction>().Property(p => p.Value).IsRequired();
            builder.Entity<Transaction>().Property(p => p.Comment).HasMaxLength(510);
            builder.Entity<Transaction>().Property(p => p.OriginalCurrencyID).IsRequired();
            builder.Entity<Transaction>().Property(p => p.OriginalValue);
            builder.Entity<Transaction>().Property(p => p.CategoryID).IsRequired();
            builder.Entity<Transaction>().Property(p => p.PaymentTypeID).IsRequired();
            builder.Entity<Transaction>().Property(p => p.AccountID).IsRequired();
            builder.Entity<Transaction>().Property(p => p.CreatedDT).IsRequired();
            builder.Entity<Transaction>().HasOne(p => p.Account);
            builder.Entity<Transaction>().HasOne(p => p.Category);
            //builder.Entity<Transaction>().HasOne(p => p.Currency);
            builder.Entity<Transaction>().HasOne(p => p.PaymentType);



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
