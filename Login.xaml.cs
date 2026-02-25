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

namespace Library_mangment
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            using(LibrarysEntities db = new LibrarysEntities())
            {
                string email = txtemail.Text;
                string password = txtpass.Password;
                if(email == "" || password == "")
                {
                    MessageBox.Show("Please enter both email and password.");
                    return;
                }
                if (db.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault() != null) 
                {
                    MessageBox.Show("Login successful!");
                    Book_Filter bookFilter = new Book_Filter();
                    this.NavigationService.Navigate(bookFilter);
                }
                else
                {
                    MessageBox.Show("Invalid email or password.");
                }
            }
        }
    }
}
