using Law_Firm.Models.ClsDatabase;
using Microsoft.EntityFrameworkCore;

namespace Law_Firm.Models.dbContext
{
    public class LawFirmdbContext  : DbContext
    {

        public DbSet<ServiceModel> Services { get; set; }

        public  DbSet <ContactFormModel> ContactForms { get; set; } 
        public LawFirmdbContext() : base()
        {

        }

        public LawFirmdbContext(DbContextOptions options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog =LawFirm_DB ; Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
