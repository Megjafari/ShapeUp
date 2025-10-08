

using ShapeUp.Models;

namespace ShapeUp.Services
{

    public static class BmiCalculator
    {
        public static double CalculateBmi(double height, double weight)
        {
            if (height <= 0) return 0;
            return weight / (height * height);
        }

        public static string GetBmiCategory(double bmi)
        {
            if (bmi < 18.5) return "Underweight";
            if (bmi < 25) return "Normal weight";
            if (bmi < 30) return "Overweight";
            return "Obesity";
        }

        public static string GetTrainingPlan(string category)
        {
            switch (category)
            {
                case "Underweight":
                    return "Focus on strength training and calorie surplus.";
                case "Normal weight":
                    return "Maintain balance with 3–4 workouts per week.";
                case "Overweight":
                    return "Add more cardio and track calorie intake.";
                case "Obesity":
                    return "Start light with walking and build consistency.";
                default:
                    return "General fitness: move daily and stay active.";
            }
        }
    }
}

