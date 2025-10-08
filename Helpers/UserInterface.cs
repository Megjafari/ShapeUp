using ShapeUp.Models;
using ShapeUp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeUp.Helpers
{
    public class UserInterface
    {
        private UserService _userService;

        public UserInterface(UserService userService)
        {
            _userService = userService;
        }

        // Startar användarinteraktionen och returnerar den inloggade användaren
        public User Start()
        {
            Console.WriteLine("Welcome to ShapeUp!");

            while (true)
            {
                Console.WriteLine("\n1. Sign Up");
                Console.WriteLine("2. Sign in");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine()!;

                switch (choice)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        var user = LoginUser();
                        if (user != null)
                        {
                            Console.WriteLine($"Welcome {user.Nickname}!");
                            return user;
                        }
                        break;

                    case "3":
                        return null!;
                    default:
                        Console.WriteLine("invalid option.");
                        break;
                }
            }
        }

        private void RegisterUser()
        {
            //Nickname
            string nickname;

            while (true)
            {
                Console.Write("Nickname: ");
                nickname = Console.ReadLine()!;

                if (!string.IsNullOrWhiteSpace(nickname))
                    break;

                Console.WriteLine("Nickname cannot be empty. Try again.");

            }

            Console.Write("Username: ");
            string username = Console.ReadLine()!;

            //repeat password

            string password;
            while (true)
            {
                Console.Write("Password: ");
                password = Console.ReadLine()!;

                Console.WriteLine("Repeat Password: ");
                string repeatPassword = Console.ReadLine()!;

                if (password == repeatPassword)
                    break;

                Console.WriteLine("Password do not match. Try again. ");

            }

            //birthday

            DateTime birthday;
            while (true)
            {
                Console.Write("Birthday (YYYY-MM-DD): ");
                string input = Console.ReadLine()!;

                if (DateTime.TryParse(input, out birthday))
                    break;

                Console.Write("Invalid Date format, try again (e.g., 1999-09-28). ");
            }


            Console.Write("Your weight in kg: ");
            double weight = double.Parse(Console.ReadLine()!);

            Console.Write("Your height in meter: ");
            double height = double.Parse(Console.ReadLine()!);

            User newUser = new User
            {
                Username = username,
                Password = password,
                Weight = weight,
                Height = height
            };

            _userService.Register(newUser);
            Console.WriteLine("Registration done!");
        }





        private User LoginUser()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine()!;

            Console.Write("Password: ");
            string password = Console.ReadLine()!;

            User user = _userService.Login(username, password);

            if (user != null)
            {
                Console.WriteLine($"Welcome {user.Username}!");
                return user;
            }
            else
            {
                Console.WriteLine("Wrong username or password.");
                return null!;
            }
        }
        
        

        

    }

}




