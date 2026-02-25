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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }
        User u;
        private void back_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.NavigationService.Navigate(login);
        }

        private void signup_Click(object sender, RoutedEventArgs e)
        {
            if (txtfullname.Text == "" || txtemail.Text == "" || txtpass.Password == "" || txtconfpass.Password == "")
            {
                MessageBox.Show("Please fill all the fields.");
                return;
            }
            if (txtpass.Password != txtconfpass.Password)
            {
                MessageBox.Show("Passwords do not match.");
            }
            try
            {
                using (LibrarysEntities db = new LibrarysEntities())
                {
                    string selectedRole = "";
                    if(Member.IsChecked == true)
                    {
                        selectedRole = "Member";
                    }
                    else if(Librarian.IsChecked == true)
                    {
                        selectedRole = "Librarian";
                    }
                    u = new User
                    {
                        FullName = txtfullname.Text,
                        Email = txtemail.Text,
                        Password = txtpass.Password,
                        Role = selectedRole,
                    };
                    db.Users.Add(u);
                    db.SaveChanges();
                    MessageBox.Show("Account created successfully!");
                    this.NavigationService.Navigate(new Login());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);

            }
        }
    }
}
