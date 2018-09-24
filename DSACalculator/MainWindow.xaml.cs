using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DSACalculator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_OnClick(object sender, RoutedEventArgs e)
        {
            var attr1 = int.Parse(Att1.Text);
            var attr2 = int.Parse(Att2.Text);
            var attr3 = int.Parse(Att3.Text);

            var taw = int.Parse(TaWBox.Text);

            int val = 0;

            if (taw < 1)
                val = Math.Min(20, attr1 + taw) * Math.Min(20, attr2 + taw) * Math.Min(20, attr3 + taw);
            else if (taw >= 1)
            {
                var temp1 = Math.Min(20, attr1) * Math.Min(20, attr2) * Math.Min(20, attr3);

                var sum = 0;

                for (int i = 1; i <= Math.Min(20 - attr1, taw); ++i)
                {
                    sum += Math.Min(20, attr2) * Math.Min(20, attr3 + i);
                }

                for (int i = 1; i <= Math.Min(20 - attr2, taw); ++i)
                {
                    sum += Math.Min(20, attr3) * Math.Min(20, attr1 + i);
                }

                for (int i = 1; i <= Math.Min(20 - attr3, taw); ++i)
                {
                    sum += Math.Min(20, attr1) * Math.Min(20, attr2 + i);
                }

                val = temp1 + sum;
            }

            ReturnBox.Text = (double)val / 8000 + "";
        }

        private void RollButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ReturnBox.Text))
                CalculateButton_OnClick(sender, e);

            var roll = new Random().Next(0, 100) / 100.0;

            if (roll <= double.Parse(ReturnBox.Text, CultureInfo.CurrentUICulture))
                RollBox.Text = "Erfolg (" + roll + ")";
            else
                RollBox.Text = "Fehlschlag (" + roll + ")";
        }
    }
}
