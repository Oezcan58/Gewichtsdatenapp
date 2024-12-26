using System.Text.Json;
using Gewichtsdatenapp.Model;


namespace Gewichtsdatenapp.Service
{
    public class JsonStorageService
    {
        private readonly string _filePath;

        public JsonStorageService(string filePath)
        {
            _filePath = filePath;
        }

        public List<Werte> LoadData()
        {
            if (!File.Exists(_filePath))
                return new List<Werte>();

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Werte>>(json) ?? new List<Werte>();
        }

        public void SaveData(List<Werte> data)
        {
            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
