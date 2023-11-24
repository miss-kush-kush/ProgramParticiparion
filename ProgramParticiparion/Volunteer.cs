public class Volunteer : Participant
{
    public bool IsLongTerm { get; set; }
    public override bool CheckEligibility()
    {
        return Age > 18;
    }
}
