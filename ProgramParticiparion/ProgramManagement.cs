public class ProgramManagement
{
    public delegate bool CheckCVDelegate(string cvContent);

    public event Action<Participant> ParticipantAdded;

    private List<Participant> participants = new();

    public List<Participant> GetParticipantsByType<T>() where T : Participant
    {
        return participants.FindAll(p => p.GetType() == typeof(T));
    }

    protected void AddParticipant(Participant participant)
    {
        participants.Add(participant);
        ParticipantAdded?.Invoke(participant);
    }

    public void AddVolunteer(Volunteer volunteer)
    {
        if(volunteer.CheckEligibility())
        {
            AddParticipant(volunteer);
        }
        else
        {
            Console.WriteLine("Volunteer not eligible");
        }
    }

    public void AddScholarshipParticipant(ScholarshipParticipant participant)
    {
        if (participant.CheckEligibility())
        {
            Console.WriteLine($"Offering list of available countries for {participant.Name}:");

            // Assuming PreferredCountry is of type Country
            if (participant.PreferredCountry != null)
            {
                Console.WriteLine($"Country: {participant.PreferredCountry.Name}, University: {participant.PreferredCountry.UniversityName}, Scholarship Program: {participant.PreferredCountry.ScholarshipProgram}, Faculty: {participant.PreferredCountry.Faculty}");
            }
            else
            {
                Console.WriteLine("Preferred country information not available.");
            }

            AddParticipant(participant);
        }
        else
        {
            Console.WriteLine("Scholarship participant not eligible.");
        }
    }


    public bool CheckCVFile(String filePath, CheckCVDelegate checkCVDelegate)
    {
        try
        {
            string cvContent = File.ReadAllText(filePath);
            return checkCVDelegate(cvContent);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"CV file not found at {filePath}.");
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading CV file: {ex.Message}");
            return false;
        }
    }
}
