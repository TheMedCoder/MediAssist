namespace MediAssist.Api.Data.Entities;

public enum InteractionSeverity
{
    Minor = 0,
    Moderate = 1,
    Major = 2,
    Contraindicated = 3
}

public class DrugInteraction
{
    public int Id {get;set;}
    public int DrugAId {get;set;}
    public Drug? DrugA {get;set;}
    public int DrugBId {get;set;}
    public Drug? DrugB {get;set;}
    public InteractionSeverity Severity {get;set;}
    public string Description {get;set;} = string.Empty;
}