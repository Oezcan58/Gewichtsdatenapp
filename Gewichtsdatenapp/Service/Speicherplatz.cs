using System.Text.Json;
using Gewichtsdatenapp_LiveChart.Model;


namespace Gewichtsdatenapp_LiveChart.Service
{
    public class Speicherplatz
    {
        private readonly string _filePath;

        public Speicherplatz(string filePath)
        {
            _filePath = filePath;
        }

        public List<Werte> LoadData()
        {
            if (!File.Exists(_filePath))
                return new List<Werte>();

            try
            {
                string json = File.ReadAllText(_filePath);
                var daten = JsonSerializer.Deserialize<List<Werte>>(json);
                return daten ?? new List<Werte>();
            }
            catch (Exception)
            {
                return new List<Werte>();
            }
        }

        public void SaveData(List<Werte> daten)
        {
            try
            {
                string json = JsonSerializer.Serialize(daten, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(_filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Speichern der Daten: {ex.Message}");
            }
        }
    }
}
