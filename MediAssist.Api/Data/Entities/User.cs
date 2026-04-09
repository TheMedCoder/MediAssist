namespace MediAssist.Api.Data.Entities
{
    public enum UserRole
    {
        Nurse = 0,
        Doctor = 1,
        Admin = 2
    }

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; } = UserRole.Nurse;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // A user performs many triage assessments
        public ICollection<TriageAssessment> Assessments { get; set; } = new List<TriageAssessment>();
    }
}