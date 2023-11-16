using System;
using System.Collections.Generic;
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

namespace DniCalc {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    public partial class MainWindow : Window {
        private char[] chars = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E'};

        public MainWindow( ) {
            InitializeComponent( );
        }

        private void btngetChar_Click( object sender, RoutedEventArgs e ) {
            int num = 0;
            if(int.TryParse(tbDniNumber.Text, out num ) && num.ToString().Length == 8) {
                lblChar.Content = chars[num % 23];
            }
        }
    }
}
