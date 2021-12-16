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
    /// Логика взаимодействия для Accounting.xaml
    /// </summary>
    public partial class Accounting : Page
    {
        public Accounting(Врач Info)
        {
            InitializeComponent();
            accList.ItemsSource = HospitalSNEntities.GetContext().УчетПриема.Where(p => p.idВрача == Info.idВрача).ToList();
        }

        private void BtnSaveNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HospitalSNEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешное сохранение!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
