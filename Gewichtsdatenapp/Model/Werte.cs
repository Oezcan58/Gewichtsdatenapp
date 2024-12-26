using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gewichtsdatenapp.Model
{
    public class Werte

    {
        public DateTime Date { get; set; }= DateTime.Now;
        public double Height { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; } // Gewicht
        public string Gender {  get; set; }
        public double BMI { get; set; } // Berechneter BMI
    }
}