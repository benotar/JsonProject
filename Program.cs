
using Sharp;
using Sharp.Entities;

var database = new DataBase();

database.LoadToFile();

//foreach(Feedback feedback in database.GetFeedbackByUserName("benotar"))
//{
//    Console.WriteLine(feedback);
//}


//var temp = database.GetUserByFeedbackID(Guid.Parse("dcbb1649-ad0f-4dfa-a587-22888da03f77"));

//Console.WriteLine(temp);

Console.WriteLine($"Average rating: {database.GetAverageRating()}");