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

namespace HospitalSN_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var enter = HospitalSNEntities.GetContext().ДанныеДляВхода.ToList();
            var check = enter.FirstOrDefault(p => p.Логин.Trim() == log.Text && p.Пароль.Trim() == pass.Password);
            if(check != null)
            {
                Menu mn = new Menu(check.Врач);
                mn.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Данные отсутствуют!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
