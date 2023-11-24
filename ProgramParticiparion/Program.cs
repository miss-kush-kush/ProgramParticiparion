using System;
using System.Collections.Generic;
using System.IO;

ProgramManagement programManagement = new ProgramManagement();
Volunteer volunteer = new Volunteer { Name = "John Doe", Age = 20, IsStudent = true, IsLongTerm = true };
programManagement.AddVolunteer(volunteer);

// Adding a scholarship participant
ScholarshipParticipant scholarshipParticipant = new ScholarshipParticipant
{
    Name = "Jane Smith",
    Age = 22,
    IsStudent = true,
    PreferredCountry = new Country("Ukraine", "KPI", "Government Scholarship", "Computer Engineering"),
};
programManagement.AddScholarshipParticipant(scholarshipParticipant);

// Lambda expression to check CV for specific words
ProgramManagement.CheckCVDelegate checkCVDelegate = cvContent =>
{
    return cvContent.Contains("motivated") || cvContent.Contains("hardworking") ||
           cvContent.Contains("leader") || cvContent.Contains("creative");
};

// Checking CV from file for the volunteer
bool isVolunteerCVValidFromFile = programManagement.CheckCVFile("CV.txt", checkCVDelegate);
Console.WriteLine($"Volunteer CV is valid: {isVolunteerCVValidFromFile}");

// Checking CV from file for the scholarship participant
bool isScholarshipParticipantCVValidFromFile = programManagement.CheckCVFile("CV.txt", checkCVDelegate);
Console.WriteLine($"Scholarship participant CV is valid: {isScholarshipParticipantCVValidFromFile}");

// Displaying all volunteers
var volunteers = programManagement.GetParticipantsByType<Volunteer>();
Console.WriteLine("Volunteers:");
foreach (var v in volunteers)
{
    Console.WriteLine($"{v.Name} - {((v as Volunteer).IsLongTerm ? "Long Term" : "Short Term")}");
}

// Displaying all scholarship participants
var scholarshipParticipants = programManagement.GetParticipantsByType<ScholarshipParticipant>();
Console.WriteLine("Scholarship Participants:");
foreach (var sp in scholarshipParticipants)
{
    if (sp is ScholarshipParticipant)
    {
        // Cast 'sp' to ScholarshipParticipant directly within the Console.WriteLine
        Console.WriteLine($"{sp.Name} - Preferred Country: {((ScholarshipParticipant)sp).PreferredCountry?.Name}");
    }
}