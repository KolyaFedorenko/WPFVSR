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
using System.Windows.Shapes;

namespace WPFVSR
{
    /// <summary>
    /// Логика взаимодействия для AddInfoWindow.xaml
    /// </summary>
    public partial class AddInfoWindow : Window
    {
        MainWindow mw = (MainWindow)Application.Current.MainWindow;
        VSREntities context;
        
        public AddInfoWindow(VSREntities context, Tickets newTickets)
        {
            InitializeComponent();
            this.context = context;
            this.DataContext = newTickets;
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                context.SaveChanges();
                mw.ShowTable();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка: " + exception.Message);
            }
        }
    }
}
