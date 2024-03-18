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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private labaEntities context = new labaEntities();

        public MainWindow()
        {
            InitializeComponent();

            var query = from Student in context.Students
                        join course in context.Courses on Student.StudentID equals course.CourseID
                        select new
                        {
                            Student.StudentID,
                            Student.FirstName,
                            Student.LastName,
                            course.CourseName
                        };


            StudentsDgr.ItemsSource = query.ToList();
        }
    }
}