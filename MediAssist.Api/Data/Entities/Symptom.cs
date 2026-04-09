namespace MediAssist.Api.Data.Entities;
public class Symptom
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int DefaultSeverityScore { get; set; }
    // If true, the presence of this symptom alone bumps the assessment
    // to the highest priority regardless of total score.
    // Example: "active chest pain", "loss of consciousness".
    public bool AlwaysCritical { get; set; }
}