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
using word = Microsoft.Office.Interop.Word;

namespace HospitalSN_App
{
    /// <summary>
    /// Логика взаимодействия для Appointment.xaml
    /// </summary>
    public partial class Appointment : Page
    {
        private УчетПриема _note = new УчетПриема();
        private Врач InfoDoc;
        public Appointment(Врач Info)
        {
            InitializeComponent();
            DataContext = _note;
            if(Info.idРоли == 3)
            {
                getPatient.ItemsSource = HospitalSNEntities.GetContext().Пациент.ToList();
                getDoc.ItemsSource = HospitalSNEntities.GetContext().Врач.ToList();
            }
            else
            {
                getPatient.ItemsSource = HospitalSNEntities.GetContext().Пациент.Where(p => p.idВрача == Info.idВрача).ToList();
                getDoc.Items.Add(Info);
            }
            
            InfoDoc = Info;
            
        }

        private void addNote_Click(object sender, RoutedEventArgs e)
        {
            var _currentNote = HospitalSNEntities.GetContext().УчетПриема.ToList();
            StringBuilder errors = new StringBuilder();

            if (getDoc.SelectedItem == null)
                errors.AppendLine("Выберите врача!");
            if (getPatient.SelectedItem == null)
                errors.AppendLine("Выберите пациента!");
            if (getDate.SelectedDate == null)
                errors.AppendLine("Укажите дату приема!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Предупреждение!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            if (_note.Номер == 0)
            {
                _note.Номер = _currentNote.Count;
                _note.Номер++;
                _note.Присутствие = false;
                HospitalSNEntities.GetContext().УчетПриема.Add(_note);
            }

            try
            {
                HospitalSNEntities.GetContext().SaveChanges();
                word.Document doc = null;
                word.Application app = new word.Application();
                string source = @"C:\Users\suhar\source\repos\HospitalSN_App\Talon.docx";
                doc = app.Documents.Open(source);
                doc.Activate();
                word.Bookmarks wBookmarks = doc.Bookmarks;
                word.Range wRange;
                int k = 0;
                string Word2 = $"==================\n" +
                    $"------------------\n" +
                    $"==================\n" +
                    $"\tТалон\t\n" +
                    $"Врач: {getDoc.SelectedItem}\n" +
                    $"Пациенту {getPatient.SelectedItem}\n" +
                    $"явиться на прием \n" +
                    $"в назначенную дату {getDate.SelectedDate.Value.Date}\n";
                foreach (word.Bookmark mark in wBookmarks)
                {
                    wRange = mark.Range;
                    wRange.Text = Word2;
                    k++;
                }
                doc.Close();
                doc = null;

                MessageBox.Show("Запись добавлена! Талон готов!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                Manager.MainFrame.Navigate(new AppointmentList(InfoDoc));
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void findPatient_TextChanged(object sender, TextChangedEventArgs e)
        {
            var find = HospitalSNEntities.GetContext().Пациент.Where(p => p.idВрача == InfoDoc.idВрача).ToList();
            find = find.Where(p => p.ФИО.Contains(findPatient.Text)).ToList();
            getPatient.ItemsSource = find;
        }
    }
}
