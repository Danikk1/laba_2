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
            StudentsDgr.ItemsSource = context.Students.ToList();
        }

        //Добавление
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Students c = new Students();
            c.FirstName = NameTbx.Text;

            context.Students.Add(c);

            context.SaveChanges();
            StudentsDgr.ItemsSource = context.Students.ToList();
        }

        //Удаление
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (StudentsDgr.SelectedItem != null)
            {
                context.Students.Remove(StudentsDgr.SelectedItem as Students);

                context.SaveChanges();
                StudentsDgr.ItemsSource = context.Students.ToList();
            }



        }

        //Изменение
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (StudentsDgr.SelectedItem != null)
            {
                var selected = StudentsDgr.SelectedItem as Students;

                selected.LastName = NameTbx.Text;

                context.SaveChanges();
                StudentsDgr.ItemsSource = context.Students.ToList();
            }
        }
    }
}