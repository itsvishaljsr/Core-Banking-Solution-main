using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CoreBanking.Domain.Entities;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CoreBanking.Application.Interfaces.IServices;

namespace CoreBanking.Infrastructure.Persistence
{
    public class CoreBankingDbContext : IdentityDbContext<Customer>, IBankingDbContext
    {
        public CoreBankingDbContext(DbContextOptions<CoreBankingDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations { get; set; } = default!;

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
            => base.SaveChangesAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Decimal precision
            builder.Entity<BankAccount>()
                .Property(b => b.Balance)
                .HasPrecision(18, 2);

            builder.Entity<Transactions>()
                .Property(t => t.Amount)
                .HasPrecision(18, 2);

            // Customer  BankAccount (1:1)
            builder.Entity<Customer>()
                .HasOne(c => c.BankAccount)
                .WithOne(b => b.Customers)
                .HasForeignKey<BankAccount>(b => b.CustomerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Transactions>()
    .HasOne(t => t.BankAccounts)
    .WithMany(b => b.Transactions)
    .HasForeignKey(t => t.BankAccountId)
    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Transactions>()
                .HasOne(t => t.Customers)
                .WithMany(c => c.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }


    }
}
