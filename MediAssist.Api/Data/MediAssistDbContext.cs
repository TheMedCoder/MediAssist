using MediAssist.Api.Data;
using MediAssist.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediAssist.Api.Data;

public class MediAssistDbContext : DbContext
{
    public MediAssistDbContext(DbContextOptions<MediAssistDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Drug> Drugs => Set<Drug>();
    public DbSet<DrugInteraction> DrugInteractions => Set<DrugInteraction>();
    public DbSet<Symptom> Symptoms => Set<Symptom>();
    public DbSet<TriageAssessment> TriageAssessments => Set<TriageAssessment>();
    public DbSet<TriageAssessmentSymptom> TriageAssessmentSymptoms => Set<TriageAssessmentSymptom>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Emails must be unique. We will lean on this at the database level,
        // not just the application level, because the application level is
        // a suggestion and the database level is the law.
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
        // Medical record numbers must be unique too.
        modelBuilder.Entity<Patient>()
            .HasIndex(u => u.MedicalRecordNumber)
            .IsUnique();
        // An interaction row is keyed on the pair of drugs. You should not
        // be able to insert the same (DrugA, DrugB) pair twice.
        modelBuilder.Entity<DrugInteraction>()
            .HasIndex(i => new { i.DrugAId, i.DrugBId })
            .IsUnique();
        // The join table between assessments and symptoms needs a composite key.
        modelBuilder.Entity<TriageAssessmentSymptom>()
            .HasKey(tas => new { tas.TriageAssessmentId, tas.SymptomId });
        // Explicitly tell EF about the two navigation props on Drug so it
        // doesn't get confused and generate a single-direction mapping.
        modelBuilder.Entity<DrugInteraction>()
            .HasOne(di => di.DrugA)
            .WithMany(d => d.InteractionAsA)
            .HasForeignKey(di => di.DrugAId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<DrugInteraction>()
            .HasOne(di => di.DrugB)
            .WithMany(d => d.InteractionAsB)
            .HasForeignKey(di => di.DrugBId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}