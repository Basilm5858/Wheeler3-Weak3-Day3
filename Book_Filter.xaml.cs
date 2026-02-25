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
    /// Interaction logic for Book_Filter.xaml
    /// </summary>
    public partial class Book_Filter : Page
    {


        public Book_Filter()
        {
            InitializeComponent();
            Loaded_Books();
        }

        private void Loaded_Books()
        {
            using (LibrarysEntities db = new LibrarysEntities())
            {
                var books = db.Books.ToList();
                dgbooks.ItemsSource = books;
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            using(LibrarysEntities db = new LibrarysEntities())
            {
                string SearchTerm = txtsearch.Text.ToLower();
                var selected = db.Books
                    .Where(x => x.Title.Contains(SearchTerm)).ToList();
                dgbooks.ItemsSource = selected;

            }
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            using(LibrarysEntities db = new LibrarysEntities())
            {
                if(txtid == null)
                {
                    MessageBox.Show("Please Enter The Id");
                    return;
                }
                Book selectedBook = (Book) dgbooks.SelectedItem;
                Book booktoupdate = db.Books.Find(selectedBook.Id);
                if(booktoupdate != null)
                {
                    booktoupdate.Title = txttitle.Text;
                    db.SaveChanges();
                    MessageBox.Show("Book updated successfully.");
                    Loaded_Books();
                }
            }
        }

        private void showall_Click(object sender, RoutedEventArgs e)
        {
            Loaded_Books();
        }
    }
}
