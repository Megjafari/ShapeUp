

using ShapeUp.Models;

namespace ShapeUp.Services
{
    public static class BMI_Calculator
    {
        public static BMI_Response Calculate (BMI_Request request)
        {
           double BMI = request.Weight / (request.Height * request.Height);
           string category = "";
           string trainingsplan = "";
           string nutritionAdvice = "";

          
            
            if (BMI < 18.5)
            
            {
                 category = "Underweight";
                trainingsplan = "Focus on strength training to build muscle mass. Include compound movements like squats, deadlifts, and bench presses. Aim for 3-4 sessions per week.";
                nutritionAdvice = "Increase your calorie intake with nutrient-dense foods. Include more proteins, healthy fats, and complex carbohydrates in your diet. Consider eating 5-6 smaller meals throughout the day.";
            }

           
            
            else if (BMI < 25)
            
            {
                category = "Normal weight";
                trainingsplan = "Maintain a balanced workout routine with a mix of cardio and strength training. Aim for at least 150 minutes of moderate aerobic activity or 75 minutes of vigorous activity each week, along with muscle-strengthening activities on 2 or more days a week.";
                nutritionAdvice = "Continue eating a balanced diet rich in fruits, vegetables, lean proteins, and whole grains. Monitor portion sizes and stay hydrated.";
            }


            else if (BMI < 30)

            {
                category = "Overweight";
                trainingsplan = "Incorporate more cardio exercises such as walking, jogging, cycling, or swimming. Aim for at least 300 minutes of moderate-intensity aerobic activity per week. Include strength training exercises at least 2 days a week.";
                nutritionAdvice = "Focus on a calorie-controlled diet. Reduce intake of sugary foods and beverages, and increase consumption of vegetables, fruits, lean proteins, and whole grains. Consider consulting a nutritionist for personalized advice.";

            }

            return new BMI_Response
            {
                BMI = BMI,
                Category = category,
                Trainingsplan = trainingsplan,
                NutritionAdvice = nutritionAdvice
            };
        }
    }
}
