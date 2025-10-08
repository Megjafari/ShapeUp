namespace ShapeUp.Models
{
    public class BMI_Request
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ActivityLevel { get; set; }
        public string FitnessGoal { get; set; }
    }
}
