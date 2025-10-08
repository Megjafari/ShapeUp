using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ShapeUp.Models;

namespace ShapeUp.Services
{
    public class UserService
    {
        private const string FilePath = "Data/users.json";
        private List<User> users = new List<User>();

        public UserService()
        {
            if (File.Exists(FilePath))

            {
                users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(FilePath))!;

            }
        }

        public void Register(User user)
        {
            users.Add(user);
            SaveChanges();
        }
        public User Login(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password)!;
        }

        public void UpdateUser(User user)
        {
            var existingUser = users.FirstOrDefault(u => u.Username == user.Username);
            if (existingUser != null)
            {
                existingUser.Weight = user.Weight;
                existingUser.Height = user.Height;
                existingUser.BMIHistory = user.BMIHistory;
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            File.WriteAllText(FilePath, JsonSerializer.Serialize(users));
        }

        public List<User> GetAllUsers() => users;

    }
}
