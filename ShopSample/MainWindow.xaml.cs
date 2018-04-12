using System.Windows;
using System.Windows.Controls;

namespace ShopSample
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ComboBox.Text = "Выберите таблицу";
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataBaseHelper helper = new DataBaseHelper();

            switch (ComboBox.SelectedIndex)
            {
                case 0: Table.ItemsSource = helper.GetCustomers(); break;
                case 1: Table.ItemsSource = helper.GetSellers(); break;
                case 2: Table.ItemsSource = helper.GetOrders(); break;
                default: MessageBox.Show("Что-то пошло не так :("); break;
            }
        }
    }
}
