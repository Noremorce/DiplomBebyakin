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
using System.Windows.Shapes;

namespace StoreApp
{
    /// <summary>
    /// Логика взаимодействия для ActiveWindow.xaml
    /// </summary>
    public partial class ActiveWindow : Window
    {
        public ActiveWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new ChoicePage());
            Manager.MainFrame = MainFrame;
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)//исчезновение кнопки назад
        {
            if (MainFrame.CanGoBack)
            {
                Back.Visibility = Visibility.Visible;
            }
            else
            {
                Back.Visibility = Visibility.Hidden;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();//переход на окно авторизации
            main.Show();
            this.Close();
        }
    }
}
