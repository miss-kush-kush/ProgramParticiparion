public class ScholarshipParticipant : Participant
{
    public Country? PreferredCountry { get; set; }

    public override bool CheckEligibility()
    {
        return Age > 18 && IsStudent;
    }
}
