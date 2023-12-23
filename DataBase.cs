using Sharp.Entities;
using Sharp.Interfaces;
using System.Text.Json;

namespace Sharp;

public class DataBase : IPersistable
{
    private List<User> _users;

    private List<Feedback> _feedbacks;

    private const string _usersFileName = "users.json";

    private const string _feedbakcsFileName = "feedback.json";

    public DataBase()
    {
        _users = new List<User>();
        _feedbacks = new List<Feedback>();
    }

    public void AddUser(string userName, string? realName)
    {
        if (_users.Any(user => user.UserName.Equals(userName)))
        {
            throw new ArgumentException("Username already exists", nameof(userName));
        }

        _users.Add(new User
        {
            UserName = userName,
            RealName = realName
        });
    }

    public void AddFeedback(Guid userId, string text, uint rating)
    {
        if (!_users.Any(user => user.Id.Equals(userId)))
        {
            throw new ArgumentException("User not found", nameof(userId));
        }

        if (rating > 5)
        {
            throw new ArgumentException("Rating out of rande", nameof(rating));
        }

        _feedbacks.Add(new Feedback
        {
            UserId = userId,
            Text = text,
            Rating = rating
        });
    }

    public void PrintAllUsers()
    {
        foreach (User user in _users)
        {
            Console.WriteLine(user);
        }
    }

    public void SaveToFile()
    {
        using (var writer = new StreamWriter(_usersFileName))
        {
            string usersJson = JsonSerializer.Serialize(_users);
            writer.Write(usersJson);
        }

        using (var writer = new StreamWriter(_feedbakcsFileName))
        {
            string feedbackJson = JsonSerializer.Serialize(_feedbacks);
            writer.Write(feedbackJson);
        }
    }

    public void LoadToFile()
    {
        using (var reader = new StreamReader(_usersFileName))
        {
            string usersJson = reader.ReadToEnd();

            _users = JsonSerializer.Deserialize<List<User>>(usersJson);
        }

        using (var reader = new StreamReader(_feedbakcsFileName))
        {
            string feedbacksJson = reader.ReadToEnd();

            _feedbacks = JsonSerializer.Deserialize<List<Feedback>>(feedbacksJson);
        }
    }

    public IEnumerable<Feedback> GetFeedbackByUserName(string userName)
    {
        var user = _users.FirstOrDefault(user => user.UserName.Equals(userName));

        if (user is null)
        {
            throw new ArgumentException("User not found", nameof(userName));
        }

        return _feedbacks.Where(fb => fb.UserId.Equals(user.Id));
    }
}
