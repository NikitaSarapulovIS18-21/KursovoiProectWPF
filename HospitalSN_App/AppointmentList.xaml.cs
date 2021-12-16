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
    /// Логика взаимодействия для AppointmentList.xaml
    /// </summary>
    public partial class AppointmentList : Page
    {
        private Врач InfoDoc;
        public AppointmentList(Врач Info)
        {
            InitializeComponent();
            InfoDoc = Info;
            appList.ItemsSource = HospitalSNEntities.GetContext().УчетПриема.ToList();
            if(Info.idРоли == 3)
            {
                appList.IsReadOnly = false;
                appList.Columns[3].IsReadOnly = true;
                BtnSaveNoteDoc.Visibility = Visibility.Visible;
            }
            else
            {
                appList.IsReadOnly = true;
                BtnSaveNoteDoc.Visibility = Visibility.Hidden;
            }
        }

        private void BtnAddNotePac_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Appointment(InfoDoc);
        }

        private void BtnSaveNoteDoc_Click(object sender, RoutedEventArgs e)
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
