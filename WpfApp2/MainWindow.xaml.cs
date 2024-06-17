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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double weight = Convert.ToDouble(weightIN.Text);
            double height = Convert.ToDouble(heightIN.Text);
            double heightM = height / 100;
            double index =  weight / (heightM*heightM);
            int precision = 1;
            double roundIndex = Convert.ToDouble(index.ToString($"N{precision}"));

            indexOUT.Text = "Ваш индекс ИМТ: " + roundIndex.ToString();

            if (roundIndex >= 40)
            {
                bodyImage.Source = new BitmapImage(new Uri(@"/images/humanBody+3.png", UriKind.Relative));
                adviceOUT.Text = " Вам надо меньше есть, у вас Ожирение 3 степени";
            }
            else if (roundIndex >= 35 && roundIndex < 40)
            {
                bodyImage.Source = new BitmapImage(new Uri(@"/images/humanBody+2.png", UriKind.Relative));
                adviceOUT.Text = " Вам надо меньше есть, у вас Ожирение 2 степени";

            }
            else if (roundIndex >= 30 && roundIndex < 35)
            {
                bodyImage.Source = new BitmapImage(new Uri(@"/images/humanBody+1.png", UriKind.Relative));
                adviceOUT.Text = " Вам надо меньше есть, у вас Ожирение 1 степени";

            }
            else if (roundIndex >= 25 && roundIndex < 30)
            {
                bodyImage.Source = new BitmapImage(new Uri(@"/images/humanBod0y.png", UriKind.Relative));
                adviceOUT.Text = " Вам надо меньше есть, у вас Избыточная масса тела (предожирение)";

            }
            else if (roundIndex >= 18.5 && roundIndex < 25)
            {
                bodyImage.Source = new BitmapImage(new Uri(@"/images/humanBody-1.png", UriKind.Relative));
                adviceOUT.Text = " Сохраняйте обычный режим питания, ваш ИМТ в пределах нормы";

            }
            else if (roundIndex >= 16 && roundIndex < 18.5)
            {
                bodyImage.Source = new BitmapImage(new Uri(@"/images/humanBody-2.png", UriKind.Relative));
                adviceOUT.Text = " Вам надо больше есть, у вас Недостаточная (дефицит) масса тела";

            }
            else if ( roundIndex < 16)
            {
                bodyImage.Source = new BitmapImage(new Uri(@"/images/humanBody-3.png", UriKind.Relative));
                adviceOUT.Text = " Вам надо больше есть, у вас Выраженный дефицит массы тела";

            }
        }
    }
}