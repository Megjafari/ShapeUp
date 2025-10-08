using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        namespace ShapeUp.Models
        {
             public class User
             {
       
                public string Username { get; set; }
                public string Password { get; set; }
                public DateTime Birthday { get; set; }      // måste vara DateTime
                public string Nickname { get; set; }
                public double Weight { get; set; }
                public double Height { get; set; }
                public List<double> BMIHistory { get; set; } = new List<double>(); // bra att ha direkt
              }

        }




