namespace MediAssist.Api.Data.Entities;
public enum Sex
{
    Unknown = 0,
    Male = 1,
    Female = 2,
}

public class Patient
{
    public int Id {get; set;}
    public string FullName {get; set;} = string.Empty;
    public DateTime DateOfBirth {get; set;}
    public Sex Sex {get; set;} = Sex.Unknown;
    public string MedicalRecordNumber {get; set;} = string.Empty;
    // Who created this patient record. We care about this for RBAC later.
    public int CreatedByUserId {get; set;}
    public User? CreatedBy { get; set; }
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
    public ICollection<TriageAssessment> Assessments { get; set; } = new List<TriageAssessment>();
}