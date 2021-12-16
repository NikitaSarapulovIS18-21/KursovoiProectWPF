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
    /// Логика взаимодействия для AddDoc.xaml
    /// </summary>
    public partial class AddDoc : Page
    {
        private Врач _currentDoc = new Врач();
        private ДанныеДляВхода _currentInf = new ДанныеДляВхода();
        public AddDoc()
        {
            InitializeComponent();
            DataContext = _currentDoc;
            log.DataContext = _currentInf;
            pass.DataContext = _currentInf;
            position.ItemsSource = HospitalSNEntities.GetContext().Должность.ToList();
            role.ItemsSource = HospitalSNEntities.GetContext().Роль.ToList();
        }

        private void addDoc_Click(object sender, RoutedEventArgs e)
        {
            var _currentNote = HospitalSNEntities.GetContext().Врач.ToList();
            StringBuilder errors = new StringBuilder();

            if (fio.Text == "")
                errors.AppendLine("Введите ФИО!");
            if (Adress.Text == "")
                errors.AppendLine("Введите адрес!");
            if (dateOfBirth.SelectedDate == null)
                errors.AppendLine("Укажите дату рождения!");
            if (role.SelectedItem == null)
                errors.AppendLine("Укажите роль!");
            if (phone.Text == "")
                errors.AppendLine("Введите номер телефона!");
            if (timeToWork.Text == "")
                errors.AppendLine("Введите время работы!");
            if (position.SelectedItem == null)
                errors.AppendLine("Укажите должность!");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка!");
                return;
            }
            int id = 0;
            if (_currentDoc.idВрача == 0)
            {
                _currentDoc.idВрача = _currentNote.Count;
                _currentDoc.idВрача++;
                id = _currentDoc.idВрача;
                _currentDoc.Статус = true;
                HospitalSNEntities.GetContext().Врач.Add(_currentDoc);
            }
            _currentInf.idВрача = id;
            HospitalSNEntities.GetContext().ДанныеДляВхода.Add(_currentInf);

            try
            {
                HospitalSNEntities.GetContext().SaveChanges();
                MessageBox.Show("Сотрудник добавлен!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
