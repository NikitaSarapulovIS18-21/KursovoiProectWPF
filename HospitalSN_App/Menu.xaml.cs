using System.Windows;

namespace HospitalSN_App
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu(Врач Info)
        {
            InitializeComponent();
            InfoDoc = Info;
            DataContext = Info;
            if(Info.idРоли == 2 || Info.idРоли == 3)
            {
                DocInfo.IsEnabled = false;
                PacInfo.IsEnabled = false;
                MainFrame.Content = new PersonalWin(InfoDoc);
                Manager.MainFrame = MainFrame;
            }
            if(Info.idРоли == 3)
            {
                BtnPerson.IsEnabled = false;
                MainFrame.Content = new AppointmentList(InfoDoc);
                Manager.MainFrame = MainFrame;
            }
            else
            {
                MainFrame.Content = new PersonalWin(InfoDoc);
                Manager.MainFrame = MainFrame;
            }
            
        }
        public Врач InfoDoc;
        private void appointment_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Appointment(InfoDoc);
            Manager.MainFrame = MainFrame;
        }

        private void DocInfo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Docs(InfoDoc);
            Manager.MainFrame = MainFrame;
        }

        private void PacInfo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Patients();
            Manager.MainFrame = MainFrame;
        }

        private void NotesInfo_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new AppointmentList(InfoDoc);
            Manager.MainFrame = MainFrame;
        }
        private void BtnChange_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mn = new MainWindow();
            mn.Show();
            this.Close();
        }

        private void InfoTime_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new TimeOfWork();
            Manager.MainFrame = MainFrame;
        }

        private void BtnPerson_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new PersonalWin(InfoDoc);
            Manager.MainFrame = MainFrame;
        }
    }
}
