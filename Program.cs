using System;
using ShapeUp.Models;
using ShapeUp.Services;


namespace ShapeUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.WriteLine("Welcome to the Ultimate BMI & Fitness Advisor!");
            Console.WriteLine("Here, you can calculate your BMI and get personalized training and nutrition advice.");
            Console.WriteLine("Let's get started!");
            Console.WriteLine("====================================\n");


            bool continueProgram = true;

            while (continueProgram)
            {

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write("Enter your height in meters: ");
                double height = double.Parse(Console.ReadLine().Replace(".", ","));

                Console.Write("Enter your weight in kilograms: ");
                double weight = double.Parse(Console.ReadLine().Replace(".", ","));

                Console.Write("Enter your age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter your gender (M/F/Other): ");
                string gender = Console.ReadLine();


                BMI_Request request = new BMI_Request
                {
                    Height = height,
                    Weight = weight,
                    Age = age,
                };

                BMI_Response response = BMI_Calculator.Calculate(request);


                if (response.Category == "Normal")
                    Console.ForegroundColor = ConsoleColor.Green; // grön för normal
                else
                    Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"\nYour BMI is: {response.BMI:F2}");
                Console.WriteLine($"Category: {response.Category}");
                Console.WriteLine($"\nPersonalized Training Plan:\n{response.Trainingsplan}");
                Console.WriteLine($"\nNutrition Advice:\n{response.NutritionAdvice}");


                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nDo you want to calculate again? (y/n): ");
                string answer = Console.ReadLine().Trim().ToLower();
                if (answer != "y")
                    continueProgram = false;

                Console.WriteLine(); // extra rad
            }
        }

    }

    
}
