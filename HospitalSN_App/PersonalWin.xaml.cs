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
    /// Логика взаимодействия для PersonalWin.xaml
    /// </summary>
    public partial class PersonalWin : Page
    {
        private Врач InfoDoc;
        public PersonalWin(Врач Info)
        {
            InitializeComponent();
            InfoDoc = Info;
            DataContext = Info;
            if(Info.idРоли == 4)
            {
                BtnAddDoc.Visibility = Visibility.Visible;
                BtnAccounting.Visibility = Visibility.Hidden;
            }
            else
            {
                BtnAddDoc.Visibility = Visibility.Hidden;
                BtnAccounting.Visibility = Visibility.Visible;
            }
        }

        private void BtnAccounting_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new Accounting(InfoDoc);
        }

        private void BtnAddDoc_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Content = new AddDoc();
        }
    }
}
