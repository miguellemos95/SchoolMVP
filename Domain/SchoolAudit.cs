namespace Domain;

public class SchoolAudit : Audit
{
    public SchoolAudit(
        string action,
        string field,
        string originalValue,
        string currentValue,
        DateTime modifiedOn,
        string modifiedBy) : base(action, field, originalValue, currentValue, modifiedOn, modifiedBy)
    {
        Action = action;
        Field = field;
        OriginalValue = originalValue;
        CurrentValue = currentValue;
        ModifiedOn = modifiedOn;
        ModifiedBy = modifiedBy;
    }
}

//public record SchoolAudit(string Name, string Description);