namespace MediAssist.Api.Data.Entities;

public class Drug
{
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string? OpenFDAId {get; set;}
    public string? Description {get; set;}
    public DateTime LastFetchedAt {get; set;} = DateTime.UtcNow;
    // The A side of An interaction
    public ICollection<DrugInteraction> InteractionAsA { get; set; } = new List<DrugInteraction>();
    // The B side of An interaction
    public ICollection<DrugInteraction> InteractionAsB { get; set; } = new List<DrugInteraction>();
}