using System;
using System.Windows.Threading;
using System.Windows;

namespace CuentaAtrasPaypal {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();

        }
        private void dispatcherTimer_Tick(object sender, EventArgs e) {
            DateTime date1 = DateTime.Now;
            DateTime date2 = DateTime.Parse("11/11/2030 00:00:01 AM");

            int oldMonth = date2.Month;
            while (oldMonth == date2.Month) {
                date1 = date1.AddDays(-1);
                date2 = date2.AddDays(-1);
            }

            int years = 0, months = 0, days = 0, hours = 0, minutes = 0, seconds = 0, milliseconds = 0;


            // getting number of years
            while (date2.CompareTo(date1) >= 0) {
                years++;
                date2 = date2.AddYears(-1);
            }
            date2 = date2.AddYears(1);
            years--;


            // getting number of months and days
            oldMonth = date2.Month;
            while (date2.CompareTo(date1) >= 0) {
                days++;
                date2 = date2.AddDays(-1);
                if ((date2.CompareTo(date1) >= 0) && (oldMonth != date2.Month)) {
                    months++;
                    days = 0;
                    oldMonth = date2.Month;
                }
            }
            date2 = date2.AddDays(1);
            days--;

            TimeSpan difference = date2.Subtract(date1);

            LYear.Content = years.ToString() + "Y";
            LMonth.Content = months.ToString() + "M";
            LDay.Content = days.ToString() + "D";
            LHour.Content = difference.Hours.ToString() + "h";
            LMinute.Content = difference.Minutes.ToString() + "m";
            LSecond.Content = difference.Seconds.ToString() + "s";
            LMilliseconds.Content = difference.Milliseconds.ToString() + "mm";
        }
    }
}
