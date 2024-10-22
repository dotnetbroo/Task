using Task.Domain.Commons;

namespace Task.Domain.Entities;

public class Student : Auditable
{
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }    
}
