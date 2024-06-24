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
            if (weightIN.Text == "" || heightIN.Text == "") {
                MessageBox.Show("Ошибка! Введите все свои данные");
                return;
            }
            double weight = Convert.ToDouble(weightIN.Text);
            double height = Convert.ToDouble(heightIN.Text);
            double heightM = height;
            double index =  (weight / (heightM*heightM)) *10000 ;
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

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public double activityIndex;
        private void btnBZUcalc_Click(object sender, RoutedEventArgs e)
        {
            if (weightIN.Text == "" || heightIN.Text == "" || ageIN.Text == "" || activityIndexComboBox.SelectedItem == null || genderIN.SelectedItem == null)
            {
                MessageBox.Show("Ошибка! Введите все свои данные");
                return;
            }
            double weight = Convert.ToDouble(weightIN.Text);
            double height = Convert.ToDouble(heightIN.Text);
            double age = Convert.ToDouble(ageIN.Text);

            if (activityIndexComboBox.SelectedItem == one_ActivityRange) { activityIndex = 1.2; }
            if (activityIndexComboBox.SelectedItem == two_ActivityRange) { activityIndex = 1.375; }
            if (activityIndexComboBox.SelectedItem == three_ActivityRange) { activityIndex = 1.46; }
            if (activityIndexComboBox.SelectedItem == four_ActivityRange) { activityIndex = 1.55; }
            if (activityIndexComboBox.SelectedItem == five_ActivityRange) { activityIndex = 1.64; }
            if (activityIndexComboBox.SelectedItem == six_ActivityRange) { activityIndex = 1.72; }
            if (activityIndexComboBox.SelectedItem == seven_ActivityRange) { activityIndex = 1.9; }

            if (genderIN.SelectedItem == fgend) 
            { 
            double baseMet = 9.99 * weight + 6.25 * height - 4.92 * age - 161;
                double kalByDay = baseMet * activityIndex;
                bzuOut.Text = "Ваша норма:" + kalByDay.ToString() + "калорий/день";
            }
            else if (genderIN.SelectedItem == mgend)
            {
            double baseMet = 9.99 * weight + 6.25 * height - 4.92 * age +5;
                double kalByDay = baseMet * activityIndex;
                bzuOut.Text = "Ваша норма:" + kalByDay.ToString() + "калорий/день";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            double B;
            if (prodKal_Belki.Text == "")
            {
                B = 0;
            }
            else { 
            B = Convert.ToDouble(prodKal_Belki.Text);
            }

            double Z;
            if (prodKal_Ziri.Text == "" )
            {
                Z = 0;
            }
            else
            {
                Z = Convert.ToDouble(prodKal_Ziri.Text);
            }

            double U;
            if (prodKal_Uglevodi.Text == "")
            {
                U = 0; 
            }
            else
            {
                U = Convert.ToDouble(prodKal_Uglevodi.Text);
            }

            double kal = (B * 4) + (Z * 4) + (U * 9);
            productKalOUT.Text = "Калорийность: " + kal.ToString() + "калорий";
        }
    }
}