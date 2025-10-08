using ShapeUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeUp.Helpers
{
    
    

        public static class ConsoleHelper
        {
            public static void PrintWelcome()
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=====================================================");
                Console.WriteLine(" Welcome to ShapeUp – Your Fitness Assistant!\n");
                Console.WriteLine("=====================================================");
                Console.WriteLine("This tool helps you calculate your BMI and provides");
                Console.WriteLine("personalized training and nutrition advice.\n");
                Console.ResetColor();
        }

            public static BMI_Request GetUserInput()
            {
                
                var req = new BMI_Request();

                Console.Write("Enter your height (cm): ");
                string heightInput = Console.ReadLine()!.Replace(',', '.');
                req.Height = double.Parse(heightInput, System.Globalization.CultureInfo.InvariantCulture) / 100;


                Console.Write("Enter your weight (kg): ");
                string weightInput = Console.ReadLine()!.Replace(',', '.');
                req.Weight = double.Parse(weightInput, System.Globalization.CultureInfo.InvariantCulture);

                Console.Write("Enter your age: ");
                req.Age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter your gender (male/female): ");
                req.Gender = Console.ReadLine()!;

                Console.Write("Enter your activity level (sedentary, light, moderate, active, very active): ");
                req.ActivityLevel = Console.ReadLine()!;

                Console.Write("Enter your goal (lose, maintain, gain): ");
                req.FitnessGoal = Console.ReadLine()!;

                return req;
            }

            public static void PrintResults(double bmi, string category, string trainingPlan, NutritionAdvice nutrition)
            {
                Console.Clear();
                Console.WriteLine("Your ShapeUp Results\n");

                if (category == "Normal weight")
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"BMI: {bmi:F1} ({category})");
                Console.ResetColor();

                Console.WriteLine($"\nTraining Plan: {trainingPlan}");
                Console.WriteLine($"\nNutrition Advice:");
                Console.WriteLine(nutrition.ToString());

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }

