
public abstract class Participant
{
    public string Name { get; set; }
    public int Age { get; set; }    
    public bool IsStudent { get; set; }

    public abstract bool CheckEligibility();
}
