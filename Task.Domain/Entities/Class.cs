using Task.Domain.Commons;

namespace Task.Domain.Entities;

public class Class : Auditable
{
    public string Name { get; set; }
    public IEnumerable<Student> Students { get; set; }
}
