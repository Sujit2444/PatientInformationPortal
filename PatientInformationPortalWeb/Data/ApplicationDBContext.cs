using Microsoft.EntityFrameworkCore;
using PatientInformationPortalWeb.Models;

namespace PatientInformationPortalWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<PatientInformation> PatientsInformation { get; set; }
        public DbSet<DiseaseInformation> DiseaseInformation { get; set; }
        public DbSet<NCD> NCDs { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<NCDDetail> NCD_Details { get; set; }
        public DbSet<AllergiesDetail> Allergies_Details { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientInformation>()
                .HasOne(pi => pi.DiseaseInformation)
                .WithMany(di => di.Patients)
                .HasForeignKey(pi => pi.DiseaseID);

            modelBuilder.Entity<NCDDetail>()
               .HasOne(nd => nd.Patient)
               .WithMany(p => p.NCDs)
               .HasForeignKey(nd => nd.PatientID);

            modelBuilder.Entity<NCDDetail>()
                .HasOne(nd => nd.NCD)
                .WithMany()
                .HasForeignKey(nd => nd.NCDID);

            modelBuilder.Entity<AllergiesDetail>()
                .HasOne(ad => ad.Patient)
                .WithMany(p => p.Allergies)
                .HasForeignKey(ad => ad.PatientID);

            modelBuilder.Entity<AllergiesDetail>()
                .HasOne(ad => ad.Allergies)
                .WithMany()
                .HasForeignKey(ad => ad.AllergiesID);
            modelBuilder.Entity<NCD>().HasData(
                  new NCD { NCDID=1,  NCDName = "Asthma" },
                  new NCD { NCDID=2, NCDName = "Cancer" },
                  new NCD { NCDID=3, NCDName = "Disorders of ear" },
                  new NCD { NCDID=4, NCDName = "Disorders of eye" },
                  new NCD { NCDID=5, NCDName = "Mental illness" },
                  new NCD { NCDID=6, NCDName = "Our health problems" }
             );
            modelBuilder.Entity<Allergies>().HasData(
              new Allergies { AllergiesID=1, AllergiesName = "Drugs - Penicillin" },
              new Allergies { AllergiesID=2,AllergiesName = "Drugs - Others" },
              new Allergies { AllergiesID=3,AllergiesName = "Animals" },
              new Allergies { AllergiesID=4,AllergiesName = "Food" },
              new Allergies { AllergiesID=5,AllergiesName = "Oniments" },
              new Allergies { AllergiesID=6,AllergiesName = "Plant" },
              new Allergies { AllergiesID=7,AllergiesName = "Sprays" },
              new Allergies { AllergiesID=8,AllergiesName = "Others" },
              new Allergies { AllergiesID=9,AllergiesName = "No Allergies" }
             );

        }
    }
}
