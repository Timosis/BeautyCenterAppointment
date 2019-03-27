using BeautyCenter.Data.Config.Appointments;
using BeautyCenter.Data.Config.Customers;
using BeautyCenter.Data.Config.Identity;
using BeautyCenter.Data.Config.Installments;
using BeautyCenter.Data.Config.Operations;
using BeautyCenter.Data.Config.Payments;
using BeautyCenter.Data.Entities.Appointments;
using BeautyCenter.Data.Entities.Customers;
using BeautyCenter.Data.Entities.Identity;
using BeautyCenter.Data.Entities.Installments;
using BeautyCenter.Data.Entities.Operations;
using BeautyCenter.Data.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautyCenter.Data.Context
{
    public class BeautyCenterContext : DbContext
    {
        public BeautyCenterContext()
        {
           
        }

        public BeautyCenterContext(DbContextOptions<BeautyCenterContext> options) : base(options)
        {
        }


        #region Appointments

        public DbSet<Appointment> Appointment { get; set; }

        #endregion

        #region Customers

        public DbSet<Customer> Customer { get; set; }

        #endregion

        #region Identity

        public DbSet<Function> Function { get; set; }
        public DbSet<ResetPassword> ResetPassword { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleFunction> RoleFunction { get; set; }
        public DbSet<TwoFactorAuth> TwoFactorAuth { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserSession> UserSession { get; set; }

        #endregion

        #region Installments

        public DbSet<Installment> Installment { get; set; }

        public DbSet<InstallmentDetail> InstallmentDetail { get; set; }

        #endregion

        #region Operations

        public DbSet<Operation> Operation { get; set; }

        public DbSet<OperationDetail> OperationDetail { get; set; }

        #endregion

        #region Payments

        public DbSet<Payment> Payment { get; set; }

        #endregion

        public virtual void Save()
        {
            base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(@"Server=Tumer;Database=BeautyCenterDb;User ID=sa;Password=1234qqqQ;TrustServerCertificate=True;Trusted_Connection=False;Connection Timeout=30;Integrated Security=False;Persist Security Info=False;Encrypt=True;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region AppointmentConfig

            modelBuilder.ApplyConfiguration(new AppointmentConfig());

            #endregion

            #region CustomerConfig

            modelBuilder.ApplyConfiguration(new CustomerConfig());

            #endregion

            #region IdentityConfig

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserRoleConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new FunctionConfig());
            modelBuilder.ApplyConfiguration(new ResetPasswordConfig());
            modelBuilder.ApplyConfiguration(new RoleFunctionConfig());
            modelBuilder.ApplyConfiguration(new TwoFactorAuthConfig());

            #endregion

            #region InstallmentConfig

            modelBuilder.ApplyConfiguration(new InstallmentConfig());
            modelBuilder.ApplyConfiguration(new InstallmentDetailConfig());


            #endregion

            #region OperationConfig

            modelBuilder.ApplyConfiguration(new OperationConfig());
            modelBuilder.ApplyConfiguration(new OperationDetailConfig());

            #endregion

            #region PaymentConfig

            modelBuilder.ApplyConfiguration(new PaymentConfig());

            #endregion
        }

    }
}
