using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;



namespace Gewichtsdatenapp_LiveChart.View
{
    public partial class GrafenSeite : ContentPage
    {
        public GrafenSeite()
        {
            InitializeComponent();
            LoadChartData();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadChartData();
        }

        public void LoadChartData()
        {

            var werte = App.Speicherstand.LoadData();

            if (werte == null || werte.Count == 0)
            {
                WeightChart.Series = new ISeries[]
                {
            new LineSeries<double>
            {
                Values = new List<double>(),
                Name = "Keine Daten vorhanden",
                Fill = null,
                Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 3 }
            }
                };
                return;
            }


            var values = werte.Select(w => w.Weight).ToList();
            var dates = werte.Select(w => w.Date).ToList();
            var bmis = werte.Select(w => w.BMI).ToList();

            var series = new ISeries[]
            {
        new LineSeries<double>
        {
            Values = values,
            Name = "Gewicht",
            Fill = null,
            GeometrySize = 15,
            Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 },
            GeometryStroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 4 }
        }
            };

            var x = new Axis[]
            {
        new Axis
        {
            Labels = dates.Select(d => d.ToString("dd.MM.")).ToList(),
            LabelsRotation = 0
        }
            };

            var y = new Axis[]
            {
        new Axis
        {
            Name = "Gewicht (kg)",
            NamePaint = new SolidColorPaint(SKColors.Black),
            LabelsPaint = new SolidColorPaint(SKColors.Black),
            TextSize = 14
        }
            };
            var z = new Axis[]
            {
              new Axis
              {
                    Name = "Bmi",
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 14
                }

            };
            WeightChart.Series = series;
            WeightChart.XAxes = x;
            WeightChart.YAxes = y;

            BmiChart.Series = new ISeries[]
{
    new LineSeries<double>
    {
        Values = bmis,
        Name = "BMI",
        Fill = null,
        GeometrySize = 15,
        Stroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 },
        GeometryStroke = new SolidColorPaint(SKColors.Green) { StrokeThickness = 4 }
    }
};
            BmiChart.XAxes = x;
            BmiChart.YAxes = z;

        }
    }
}
