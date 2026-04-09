using MediAssist.Api.Data.Entities;

namespace MediAssist.Api.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(MediAssistDbContext db)
    {
        if (!db.Symptoms.Any())
        {
            db.Symptoms.AddRange(new[]
            {
                new Symptom { Name = "Chest pain", DefaultSeverityScore = 8, AlwaysCritical = true },
                new Symptom { Name = "Loss of consciousness", DefaultSeverityScore = 10, AlwaysCritical = true },
                new Symptom { Name = "Shortness of breath", DefaultSeverityScore = 6 },
                new Symptom { Name = "Fever", DefaultSeverityScore = 3 },
                new Symptom { Name = "Headache", DefaultSeverityScore = 2 },
                new Symptom { Name = "Nausea", DefaultSeverityScore = 2 },
                new Symptom { Name = "Abdominal pain", DefaultSeverityScore = 4 },
                new Symptom { Name = "Dizziness", DefaultSeverityScore = 3 },
            });
        }
        if (!db.Drugs.Any())
        {
            db.Drugs.AddRange(new[]
            {
                new Drug { Name = "Paracetamol" },
                new Drug { Name = "Ibuprofen" },
                new Drug { Name = "Warfarin" },
                new Drug { Name = "Amoxicillin" },
                new Drug { Name = "Metformin" },
                new Drug { Name = "Aspirin" },
            });
        }
        await db.SaveChangesAsync();
    }
}
