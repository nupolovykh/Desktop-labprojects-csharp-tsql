using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MyWinFormsAppForDb
{
	public partial class Analytics : Form
	{
		private IServiceProvider _serviceProvider;
		private IDbWorker _worker;

		private string defaultChartArea = "MainArea";
		private string defaultLegend = "MainLegend";
		private string nameOfAxisY = "Ultimate Value";

		private const decimal coefficient = 1.5m;
		private Random rand = new Random();

		private statesForClosingWindow states_for_closing_window = statesForClosingWindow.ClosingByTheShutDownWindow;

		public Analytics(IServiceProvider serviceProvider, IDbWorker worker)
		{
			InitializeComponent();

			_serviceProvider = serviceProvider;
			_worker = worker;

			PopulationOfTheMeasurementsComboBox();
		}

		//main logic

		private void PopulationOfTheMeasurementsComboBox()
		{
			foreach (var survayLine in _worker.SurveyLines)
			{
				if (!survayLine.Pickets.Any()) continue;
				cmbBx_msrt.Items.Add(survayLine.Name + $" - {survayLine.SurveyLineId}");
			}
			cmbBx_msrt.SelectedIndex = 0;
		}

		private void AttuneTheChart()
		{
			chrt_main.Visible = true;
			chrt_main.ChartAreas.Clear();
			chrt_main.Legends.Clear();
			chrt_main.Series.Clear();

			chrt_main.ChartAreas.Add(defaultChartArea);
			chrt_main.Legends.Add(defaultLegend);
		}

		private void AttuneSerie(string key) 
		{
			chrt_main.Series[key].Color = RandomColor();
			chrt_main.Series[key].ChartArea = defaultChartArea;
			chrt_main.Series[key].Legend = defaultLegend;
			chrt_main.Series[key].ChartType = SeriesChartType.Column;
		}

		private decimal? MainFormula(decimal? a, decimal? b) => (a + b) / coefficient / 2;

		private Color RandomColor() => Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));

		private void FillingOfTheChart(List<Picket> pickets)
		{
			try
			{
				var obj = chrt_main.ChartAreas[0];
				double minAxisX = (double)pickets.Min(p => p.Latitude)!;
				double maxAxisX = (double)pickets.Max(p => p.Latitude)!;

				obj.AxisX.IntervalType = DateTimeIntervalType.Number;
				obj.AxisX.Minimum = minAxisX - 2;
				obj.AxisX.Maximum = maxAxisX + 2;

				obj.AxisY.IntervalType = DateTimeIntervalType.Number;
				obj.AxisY.Minimum = -10000;
				obj.AxisY.Maximum = 10000;

				foreach (var picket in pickets)
				{
					var chartKey = picket.PicketId.ToString();
					chrt_main.Series.Add(chartKey);

					AttuneSerie(chartKey);

					var last = picket.Measurements.MaxBy(m => m.MeasurementDate);

					foreach (var data in last!.Data)
					{
						var point = MainFormula(data.ApparentResistivity, data.ApparentResistivity);
						chrt_main.Series[chartKey].Points.AddXY(picket.Latitude, point);
					}

				}

				var anyPicket = _worker.Pickets.FirstOrDefault();
				chrt_main.ChartAreas[0].AxisX.Title = nameof(anyPicket.Latitude);
				chrt_main.ChartAreas[0].AxisY.Title = nameOfAxisY;
			}
			catch (Exception ex) 
			{
				MessageBox.Show(ex.Message);
				chrt_main.Visible = false;
			}
		}

		// logic of navigation buttons

		private void btn_retrn_Click(object sender, EventArgs e)
		{
			var main = _serviceProvider.GetService<Main>();
			main!.Show();
			states_for_closing_window = statesForClosingWindow.ClosingByTheReturn;

			this.Close();
		}

		//another logic of the form

		private void cmbBx_msrt_SelectedValueChanged(object sender, EventArgs e)
		{
			var key = cmbBx_msrt.SelectedItem as string;
			string stringId = key!.Split('-').LastOrDefault()?.Trim()!;
			if (!int.TryParse(stringId, out int intId)) return;

			AttuneTheChart();

			var pickets = _worker.Pickets.Where(m => m.SurveyLineId == intId).ToList();

			FillingOfTheChart(pickets);
		}

		private void Analytics_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && states_for_closing_window == statesForClosingWindow.ClosingByTheShutDownWindow)
			{
				var entrance = _serviceProvider.GetService<Entrance>();
				Entrance.ReopenForm(entrance!);
			}
		}
	}
}
