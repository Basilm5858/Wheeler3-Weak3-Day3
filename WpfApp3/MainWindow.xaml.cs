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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        // Read Data
        private void LoadData()
        {
            using(ExpenseEntities context = new ExpenseEntities())
            {
                var data = context.expense_report.ToList();
                dgExp.ItemsSource = data;
            }
        }
        //Add / Create Data
        //private void AddData()
        //{
        //    using (ExpenseEntities context = new ExpenseEntities())
        //    {
        //        expense_report exp_Report = new expense_report();
        //        exp_Report.Name = "Basil";
        //        exp_Report.Department = "CS";
        //        exp_Report.ExpenseTitle = "Laptop";
        //        exp_Report.Amount = 15000;
        //        exp_Report.Id = 16;
        //        exp_Report.ExpenseDate = DateTime.Now;
        //        exp_Report.Notes = "For Work";
        //        exp_Report.CreatedAt = DateTime.Now;
        //        context.expense_report.Add(exp_Report);
        //        context.SaveChanges();
        //    }
        //}

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (ExpenseEntities context = new ExpenseEntities())
            {
                expense_report exp_Report = new expense_report()
                {
                    Name = txtName.Text,
                    Department = txtDepartment.Text,
                    ExpenseTitle = txtTitle.Text,
                    Amount = decimal.Parse(txtAmount.Text),
                    ExpenseDate = DateTime.Now,
                    Notes = txtNotes.Text,
                    CreatedAt = DateTime.Now
                };
                
                context.expense_report.Add(exp_Report);
                context.SaveChanges();
                LoadData();

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            using (ExpenseEntities Context = new ExpenseEntities())
            {
                if(dgExp.SelectedItem == null)
                {
                    MessageBox.Show("Please select a record to update.");
                    return;
                }
                expense_report selected = (expense_report)dgExp.SelectedItem;
                expense_report expUpdate = Context.expense_report.Find(selected.Id);
                if (expUpdate != null)
                {
                    expUpdate.Name = txtName.Text;
                    expUpdate.Department = txtDepartment.Text;
                    expUpdate.ExpenseTitle = txtTitle.Text;
                    expUpdate.Amount = decimal.Parse(txtAmount.Text);
                    expUpdate.ExpenseDate = DateTime.Now;
                    expUpdate.Notes = txtNotes.Text;
                    expUpdate.CreatedAt = DateTime.Now;
                    Context.SaveChanges();
                }
                LoadData();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (ExpenseEntities context = new ExpenseEntities())
            {
                if (dgExp.SelectedItem == null)
                {
                    MessageBox.Show("Please select a record to delete.");
                }
                expense_report selectedReport = (expense_report)dgExp.SelectedItem;

                var reportToDelete = context.expense_report.Find(selectedReport.Id);
                if (reportToDelete != null)
                {
                    context.expense_report.Remove(reportToDelete);
                    context.SaveChanges();
                    LoadData();
                }

            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            using(ExpenseEntities context = new ExpenseEntities())
            {
                var data = context.expense_report.ToList();
                dgExp.ItemsSource = data;
            }
        }
    }
}
