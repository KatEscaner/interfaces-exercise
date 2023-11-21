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

namespace Calculator {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private long num1 = 0;
        private long num2 = 0;
        private int position = 1;
        private char operation = ' ';

        public MainWindow( ) {
            InitializeComponent( );
        }

        private void sumNum( long num) {
            if(position ==  1) {
                if ( num1 < 92233720368547758 && num1 > -92233720368547758 ) {
                    num1 = ( num1 * 10 ) + num;
                    lblResult.Content = num1;
                }
            } else if( position == 2) {
                if ( num2 < 92233720368547758 && num2 > -92233720368547758 ) {
                    num2 = ( num2 * 10 ) + num;
                    lblResult.Content = num2;
                }
            } 
        }

        private void calculateResult( ) {
            position = 0;
            switch( operation ) {
                case '+':
                    lblResult.Content = num1 + num2;
                    break;

                case '-':
                    lblResult.Content = num1 - num2;
                    break;
                        
                case '*':
                    lblResult.Content = num1 * num2;
                    break;

                case '/':
                    if(num2 == 0)
                        lblResult.Content = num1 / num2;
                    lblResult.Content = "Max Error";
                    break;

                default:
                    break;
            }
        }

        private void changeOperator( char charOperator ) {
            if ( position == 1 ) {
                position = 2;
                lblResult.Content = "";
            }

            operation = charOperator;
        }

        private void btnOne_Click( object sender, RoutedEventArgs e ) {
            sumNum( 1 );
        }

        private void btnTwo_Click( object sender, RoutedEventArgs e ) {
            sumNum( 2 );
        }

        private void btnThree_Click( object sender, RoutedEventArgs e ) {
            sumNum( 3 );
        }

        private void btnFour_Click( object sender, RoutedEventArgs e ) {
            sumNum( 4 );
        }

        private void btnFive_Click( object sender, RoutedEventArgs e ) {
            sumNum( 5 );
        }

        private void btnSix_Click( object sender, RoutedEventArgs e ) {
            sumNum( 6 );
        }

        private void btnSeven_Click( object sender, RoutedEventArgs e ) {
            sumNum( 7 );
        }

        private void btnEight_Click( object sender, RoutedEventArgs e ) {
            sumNum( 8 );
        }

        private void btnNine_Click( object sender, RoutedEventArgs e ) {
            sumNum( 9 );
        }

        private void btnZero_Click( object sender, RoutedEventArgs e ) {
            sumNum( 0 );
        }

        private void btnPlus_Click( object sender, RoutedEventArgs e ) {
            changeOperator( '+' );
        }

        private void btnSubstract_Click( object sender, RoutedEventArgs e ) {
            changeOperator( '-' );
        }

        private void btnMultiplication_Click( object sender, RoutedEventArgs e ) {
            changeOperator( '*' );
        }

        private void btnDivision_Click( object sender, RoutedEventArgs e ) {
            changeOperator( '/' );
        }

        private void btnReset_Click( object sender, RoutedEventArgs e ) {
            num1 = 0;
            num2 = 0;
            position = 1;
            operation = ' ';
            lblResult.Content = "";
        }

        private void btnResult_Click( object sender, RoutedEventArgs e ) {
            calculateResult( );
        }
    }
}
