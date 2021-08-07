using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToursManagement.Views
{
	/// <summary>
	/// Interaction logic for ScheduleView.xaml
	/// </summary>
	public partial class ScheduleView : UserControl
	{
		private const int HourCount = 9;
		private const int DayCount = 7;

		public ScheduleView()
		{
			InitializeComponent();

			Loaded += ScheduleView_Loaded;
		}

		private void ScheduleView_Loaded(object sender, RoutedEventArgs e)
		{
			AddHoursColumn();
			AddBusyBlock();
		}

		private void AddHoursColumn()
		{
			for (int counter = 0; counter < HourCount; counter++)
			{
				var timeBlock = new TextBlock()
				{
					Text = string.Format("{0:D2}:00 ", counter + HourCount - 1)
				};

				Grid.SetColumn(timeBlock, 0);
				Grid.SetRow(timeBlock, counter + 1);
				
				ScheduleGrid.Children.Add(timeBlock);
			}
		}

		private void AddBusyBlock()
		{
			var random = new Random();

			for (int colCounter = 0; colCounter < DayCount; colCounter++)
			{
				for (int rowCounter = 0; rowCounter < HourCount; rowCounter++)
				{
					var crowdPercent = random.NextDouble();
					var rectangle = new Rectangle()
					{
						Margin = new Thickness(1, 2, 1, 2),
						HorizontalAlignment = HorizontalAlignment.Stretch,
						Height = 60,
						Fill = new SolidColorBrush(Color.FromScRgb(1.0f, (float)crowdPercent, .1f, (float)(1 - crowdPercent)))
					};

					Grid.SetColumn(rectangle, colCounter + 1);
					Grid.SetRow(rectangle, rowCounter + 1);
					ScheduleGrid.Children.Add(rectangle);
				}
			}
		}

	}
}
