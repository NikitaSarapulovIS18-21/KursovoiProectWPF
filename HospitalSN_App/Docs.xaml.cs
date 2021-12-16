using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HospitalSN_App
{
    /// <summary>
    /// Логика взаимодействия для Docs.xaml
    /// </summary>
    public partial class Docs : Page
    {
        private Врач InfoDoc;
        public Docs(Врач Info)
        {
            InitializeComponent();
            InfoDoc = Info;
            docList.ItemsSource = HospitalSNEntities.GetContext().Врач.ToList();
        }

        private void BtnDocSave_Click(object sender, RoutedEventArgs e)
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

        private void docList_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {

        }
    }
}
