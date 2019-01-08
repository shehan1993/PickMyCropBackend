using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MySql.Data.Entity;

namespace PickMyCropBackend.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(): this("MyConnection") { }
        public ApplicationDbContext(string connStringName) : base(connStringName) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ASPNetUsers -> User
            modelBuilder.Entity<ApplicationUser>().ToTable("User").Property(c => c.UserName)
                .HasMaxLength(128)
                .IsRequired();
            //ASPNetRoles -> Role
            modelBuilder.Entity<IdentityRole>().ToTable("Role").Property(c => c.Name)
                .HasMaxLength(128)
                .IsRequired();
            //ASPNetUserClaims -> UserClaims
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            //ASPNetUserLogin -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            //ASPNetUserRole -> UserRole
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}