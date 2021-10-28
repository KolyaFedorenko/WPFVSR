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

namespace WPFVSR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VSREntities context;

        public MainWindow()
        {
            InitializeComponent();
            context = new VSREntities();
            ShowTable();
        }

        public void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newTickets = new Tickets();
            context.Tickets.Add(newTickets);
            var win = new AddInfoWindow(context, newTickets);
            win.ShowDialog();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var row = DataGridRegistrations.SelectedItem as Tickets;
            if (row == null)
            {
                MessageBox.Show("Выберите строку для удаления");
                return;
            }

            MessageBoxResult result = MessageBox.Show("Удалить эту строку данных?", "Подтверждение удаления", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    context.Tickets.Remove(row);
                    context.SaveChanges();
                    ShowTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка:" + ex);
                }

            }
        }

        public void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button btnEdit = sender as Button;
            var editTickets = btnEdit.DataContext as Tickets;
            var win = new AddInfoWindow(context, editTickets);
            win.ShowDialog();
        }


        public void ShowTable()
        {
            DataGridRegistrations.ItemsSource = context.Tickets.ToList();
        }
    }
}
