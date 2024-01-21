namespace Domain;

public class Audit
{
    public Guid Id { get; init; }
    public string Action { get; init; }
    public string Field { get; init; }
    public string OriginalValue { get; init; }
    public string CurrentValue { get; init; }
    public DateTime ModifiedOn { get; init;}
    public string ModifiedBy { get; init; }

    public Audit(
        string action, 
        string field, 
        string originalValue, 
        string currentValue, 
        DateTime modifiedOn, 
        string modifiedBy)
    {
        Id = Guid.NewGuid();
        Action = action;
        Field = field;
        OriginalValue = originalValue;
        CurrentValue = currentValue;
        ModifiedOn = modifiedOn;
        ModifiedBy = modifiedBy;
    }
}