using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        private static readonly List<Employee> value = [];
        private List<Employee> employees = value;
        private int nextId = 1;

        public MainWindow()
        {
            InitializeComponent();
            EmployeeDataGrid.ItemsSource = employees;
        }
        

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeDataGrid.SelectedItem is not Employee selectedEmployee)
            {
                MessageBox.Show("Пожалуйста, выберите сотрудника для редактирования");
                return;
            }

            var name = NameTextBox.Text;
            var position = PositionTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Пожалуйста заполните все поля");
                return;
            }

            selectedEmployee.Name = name;
            selectedEmployee.Position = position;

            EmployeeDataGrid.Items.Refresh();
            ClearInputs();
        }

        private void ClearInputs()
        {
            NameTextBox.Clear();
            PositionTextBox.Clear();
        }
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Position { get; set; }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var name = NameTextBox.Text;
            var position = PositionTextBox.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Пожалуйстка заполните все поля");
                return;
            }

            var newEmployee = new Employee
            {
                Id = nextId++,
                Name = name,
                Position = position
            };

            employees.Add(newEmployee);
            EmployeeDataGrid.Items.Refresh();
            ClearInputs();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = EmployeeDataGrid.SelectedItem as Employee;

            if (selectedEmployee == null)
            {
                MessageBox.Show("Пожалуйста выберите сотрудника для удаления");
                return;
            }
        }
    }
}