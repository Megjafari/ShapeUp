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
            

            ConsoleHelper.PrintWelcome();

            // Get user input
            var request = ConsoleHelper.GetUserInput();

            // Calculate BMI
            double bmi = BmiCalculator.CalculateBmi(request.Height, request.Weight);
            string category = BmiCalculator.GetBmiCategory(bmi);
            string trainingPlan = BmiCalculator.GetTrainingPlan(category);

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
