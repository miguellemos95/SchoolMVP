namespace Domain;

public class School : IEntity<School>
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }

    public School(string name, string description)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
    }

    public void Update(School school)
    {
        Name = school.Name;
        Description = school.Description;
    }
}