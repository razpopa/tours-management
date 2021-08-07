using System;
using System.Collections.Generic;
using System.Linq;
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
using ToursManagement.Models;

namespace ToursManagement.Views
{
	/// <summary>
	/// Interaction logic for TourStopsView.xaml
	/// </summary>
	public partial class TourStopsView : UserControl
	{
		private List<TourStop> _tourStops;

		public TourStopsView()
		{
			InitializeComponent();

			_tourStops = TourSource.GetAllTourStops();
			ToursListBox.ItemsSource = _tourStops;
		}

		private void CalcButton_Click(object sender, RoutedEventArgs e)
		{
			var query = from tourStop in _tourStops
						where tourStop.Selected
						select tourStop.EstimatedMinutes;

			MessageTextBlock.Text = string.Format("{0} minutes", query.Sum());
		}
	}
}
