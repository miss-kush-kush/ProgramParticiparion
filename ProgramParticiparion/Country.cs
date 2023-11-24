public class Country
{
    public string Name { get; set; }
    public string UniversityName { get; set; }
    public string ScholarshipProgram { get; set; }
    public string Faculty { get; set; }

    public Country(string name, string universityName, string scholarshipProgram, string faculty) 
    {
        Name = name;
        UniversityName = universityName;
        ScholarshipProgram = scholarshipProgram;
        Faculty = faculty;  
    }

    public override string ToString()
    {
        return $"Country: {Name}, University: {UniversityName}, Scholarship Program: {ScholarshipProgram}, Faculty: {Faculty}";
    }

}
