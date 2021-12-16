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
    /// Логика взаимодействия для TimeOfWork.xaml
    /// </summary>
    public partial class TimeOfWork : Page
    {
        public TimeOfWork()
        {
            InitializeComponent();
            docList.ItemsSource = HospitalSNEntities.GetContext().Врач.ToList();
        }
    }
}
