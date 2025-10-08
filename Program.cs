using ShapeUp.Helpers;
using ShapeUp.Models;
using ShapeUp.Services;
using System;
using static Nutrition_Calculator;


namespace ShapeUp
{
    class Program
    {

        static void Main(string[] args)
        {

            UserService userService = new UserService();

            // Starta user interface (register/login)
            UserInterface ui = new UserInterface(userService);

            User currentUser = ui.Start(); // Nu får vi tillbaka inloggad användare
            if (currentUser != null)
            {


                Console.WriteLine($"Welcome back, {currentUser.Nickname}!");


                // Get user input
                var request = ConsoleHelper.GetUserInput();

                // Calculate BMI
                double bmi = BmiCalculator.CalculateBmi(request.Height, request.Weight);
                string category = BmiCalculator.GetBmiCategory(bmi);
                string trainingPlan = BmiCalculator.GetTrainingPlan(category);

                // Spara BMI i användarhistorik
                currentUser.BMIHistory.Add(bmi);
                userService.UpdateUser(currentUser); // Lägg till en metod i UserService

                // Calculate Nutrition
                var nutrition = NutritionCalculator.GetNutritionAdvice(
                    request.Weight, request.Height, request.Age, request.Gender,
                    request.ActivityLevel, request.FitnessGoal
                );

                // Display results
                ConsoleHelper.PrintResults(bmi, category, trainingPlan, nutrition);
            }
        }
    }
}
