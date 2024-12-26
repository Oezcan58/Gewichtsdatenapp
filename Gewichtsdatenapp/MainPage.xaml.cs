using Gewichtsdatenapp.Model;
using System.Text;

namespace Gewichtsdatenapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            try
            {
                // Eingaben aus den Feldern holen
                double weight = double.Parse(WeightEntry.Text); // Gewicht
                double height = double.Parse(HeightEntry.Text); // Größe
                int age = int.Parse(AgeEntry.Text); // Alter
                string gender = GenderPicker.SelectedItem?.ToString(); // Geschlecht

                // BMI berechnen
                double bmi = weight / (height * height);

                // BMI-Kategorie basierend auf Geschlecht bestimmen
                string category = GetBMICategory(bmi, gender, age);

                // Neues Datenelement erstellen
                var newData = new Werte
                {
                    Weight = weight,
                    Height = height,
                    Age = age,
                    Gender = gender,
                    BMI = Math.Round(bmi, 2) // BMI auf 2 Nachkommastellen runden
                };


                // Daten aus JSON laden
                var data = App.StorageService.LoadData();

                // Neue Daten hinzufügen und speichern
                data.Add(newData);
                App.StorageService.SaveData(data);

                await DisplayAlert("Erfolg", "$\"Dein BMI ist {newData.BMI} ({category})", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Fehler", $"Daten konnten nicht gespeichert werden: {ex.Message}", "OK");
            }
        }

        private async void OnShowDataButtonClicked(object sender, EventArgs e)
        {
            var data = App.StorageService.LoadData();

            var dataString = new StringBuilder();
            foreach (var entry in data)
            {
                dataString.AppendLine($"Datum: {entry.Date:dd.MM.yyyy}, Gewicht: {entry.Weight} kg, Größe: {entry.Height} m, Alter: {entry.Age}, Geschlecht: {entry.Gender}, BMI: {entry.BMI}");
            }

            await DisplayAlert("Gespeicherte Daten", dataString.ToString(), "OK");
        }

        private string GetBMICategory(double bmi, string gender, int age)
        {
            if (age < 18)
                return "BMI für Kinder und Jugendliche nicht geeignet"; // Alternativ spezifische Kinder-BMI-Werte verwenden

            if (gender.ToLower() == "männlich")
            {
                if (bmi < 20) return "Untergewicht";
                if (bmi < 25) return "Normalgewicht";
                if (bmi < 30) return "Übergewicht";
                return "Adipositas";
            }
            else if (gender.ToLower() == "weiblich")
            {
                if (bmi < 19) return "Untergewicht";
                if (bmi < 24) return "Normalgewicht";
                if (bmi < 29) return "Übergewicht";
                return "Adipositas";
            }

            return "Unbekannt";
        }

    }
}
