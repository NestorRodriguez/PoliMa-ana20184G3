namespace ProyectoNota.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    // Para agregar datos de perfil del usuario, agregue más propiedades a su clase ApplicationUser. Visite https://go.microsoft.com/fwlink/?LinkID=317594 para obtener más información.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name= "NombreCompleto")]
        [StringLength(350)]
        public string NombreCompleto { get; set; }
        [Display(Name = "NumeroDocumento")]        
        public long NumeroDocumento { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("LoginNota", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("NOTA_USUARIO");
            modelBuilder.Entity<IdentityRole>().ToTable("NOTA_ROL");
            modelBuilder.Entity<IdentityUserRole>().ToTable("NOTA_USUARIO_ROL");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("NOTA_USUARIO_LOGIN");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("NOTA_USUARIO_CLAIM");
        }
    }
}