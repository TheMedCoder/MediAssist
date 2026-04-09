namespace MediAssist.Api.Data.Entities;
public enum TriagePriority
{
    NonUrgent = 0,
    Standard = 1,
    Urgent = 2,
    Critical = 3
}

public class TriageAssessment
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public Patient? Patient { get; set; }
    public int PerformedByUserId { get; set; }
    public User? PerformedBy { get; set; }
    public int TotalScore { get; set; }
    public TriagePriority Priority { get; set; }
    public string? Notes { get; set; }
    public DateTime PerformedAt { get; set; } = DateTime.UtcNow;
    public ICollection<TriageAssessmentSymptom> ObservedSymptoms { get; set; } = new List<TriageAssessmentSymptom>();
}
public class TriageAssessmentSymptom
{
    public int TriageAssessmentId { get; set; }
    public TriageAssessment? Assessment { get; set; }
    public int SymptomId { get; set; }
    public Symptom? Symptom { get; set; }
    public string? Note { get; set; }
}