using Gewichtsdatenapp.Model;
using System.Collections.ObjectModel;

namespace Gewichtsdatenapp;

public partial class WerteSeite : ContentPage
{
    private ObservableCollection<Werte> _werteListe;

    public WerteSeite()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        // Lade die gespeicherten Daten aus der JSON-Datei
        var data = App.StorageService.LoadData();

        // Initialisiere die ObservableCollection
        _werteListe = new ObservableCollection<Werte>(data);

        // Binde die Daten an die CollectionView
        DataCollectionView.ItemsSource = _werteListe;
    }

    public void UpdateWerte(Werte neueWerte)
    {
        // Werte in der Liste aktualisieren
        var bestehendeWerte = _werteListe.FirstOrDefault(w => w.Date == neueWerte.Date);
        if (bestehendeWerte != null)
        {
            bestehendeWerte.Weight = neueWerte.Weight;
            bestehendeWerte.Height = neueWerte.Height;
        }
        else
        {
            _werteListe.Add(neueWerte);
        }

        // Speichere die aktualisierten Werte
        App.StorageService.SaveData(_werteListe.ToList());
    }
}
