using System.ComponentModel;

namespace Gewichtsdatenapp.Model
{
    public class Werte : INotifyPropertyChanged
    {
        private double _weight;
        private double _height;
        private double _bmi;
        private string _gewichtsklasse;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime Date { get; set; } = DateTime.Now;

        public double Weight
        {
            get => _weight;
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged(nameof(Weight));
                    BerechneBMI(); // Berechnet BMI automatisch
                }
            }
        }

        public double Height
        {
            get => _height;
            set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(nameof(Height));
                    BerechneBMI(); // Berechnet BMI automatisch
                }
            }
        }

        public double BMI
        {
            get => _bmi;
            private set
            {
                if (_bmi != value)
                {
                    _bmi = value;
                    OnPropertyChanged(nameof(BMI));
                }
            }
        }

        public string Gewichtsklasse
        {
            get => _gewichtsklasse;
            private set
            {
                if (_gewichtsklasse != value)
                {
                    _gewichtsklasse = value;
                    OnPropertyChanged(nameof(Gewichtsklasse));
                }
            }
        }

        public int Age { get; set; } // Alter bleibt unverändert
        public string Gender { get; set; } // Geschlecht bleibt unverändert

        private void BerechneBMI()
        {
            if (Height > 0)
            {
                BMI = Math.Round(Weight / (Height * Height), 2);
                Gewichtsklasse = BestimmeGewichtsklasse(BMI);
            }
        }

        private string BestimmeGewichtsklasse(double bmi)
        {
            if (bmi < 18.5) return "Untergewicht";
            if (bmi < 24.9) return "Normalgewicht";
            if (bmi < 29.9) return "Übergewicht";
            return "Adipositas";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
