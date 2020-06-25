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
using ysoft.src;

namespace ysoft
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly string stringValid = "string";
        public static readonly string intValid = "int";

        string password, username;
        bool space;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void login_Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (controlFields())
            {
                this.Hide();
                Menu menu = new Menu();
                menu.Show();
            }
            else if (space)
            {
                MessageBox.Show("Wrong username or password.","Error",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private bool controlFields()
        {
            username = username_text.Text.Trim();
            password = password_box.Password.Trim();
            if (Controller.checkAllSpaces(username) && Controller.checkAllSpaces(password))
            {
                space = true;
                return Controller.isUserExist(username, password);
            }
            else
            {
                MessageBox.Show("All fields have to be filled.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                space = false;
                return space;
            }
        }

    }
}
