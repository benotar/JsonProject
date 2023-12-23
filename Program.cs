
using Sharp;
using Sharp.Entities;

var database = new DataBase();

database.LoadToFile();

foreach(Feedback feedback in database.GetFeedbackByUserName("benotar"))
{
    Console.WriteLine(feedback);
}