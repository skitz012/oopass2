using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;


namespace OO_programming
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }


    /// <summary>
    /// Class a capture details accociated with an employee's pay slip record
    /// </summary>
    public class PaySlip
    {
        public Employee Employee { get; set; }
        public double HoursWorked { get; set; }
        public double HourlyRate { get; set; }
        public double TaxThreshold { get; set; }

        // Constructor
        public PaySlip(Employee employee, double hoursWorked, double hourlyRate, double taxThreshold)
        {
            Employee = employee;
            HoursWorked = hoursWorked;
            HourlyRate = hourlyRate;
            TaxThreshold = taxThreshold;
        }

        // Gross Pay = Hours Worked * Hourly Rate
        public double GrossPay => HoursWorked * HourlyRate;

        // Tax calculation (can be overridden by subclasses)
        public virtual double Tax => CalculateTax(GrossPay);

        // Net Pay = Gross Pay - Tax
        public double NetPay => GrossPay - Tax;

        // Superannuation is assumed to be 11% of gross pay
        public double Superannuation => GrossPay * 0.11;

        // Tax calculation method (can be adjusted in subclasses)
        public virtual double CalculateTax(double grossPay)
        {
            return grossPay * 0.;  // Default tax rate of 20%
        }
    }


    /// <summary>
    /// Base class to hold all Pay calculation functions
    /// Default class behaviour is tax calculated with tax threshold applied
    /// </summary>
    public class PayCalculator
    {

    }

    /// <summary>
    /// Extends PayCalculator class handling No tax threshold
    /// </summary>
    public class PayCalculatorNoThreshold : PayCalculator
    {

    }

    /// <summary>
    /// Extends PayCalculator class handling With tax threshold
    /// </summary>
    public class PayCalculatorWithThreshold : PayCalculator
    {

    }

    public class Employee // Class to hold employee details
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(int employeeId, string firstName, string lastName)
        {
            EmployeeId = employeeId;
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{EmployeeId} - {FirstName} {LastName}";
        }
    }
    public class TaxBracket // Class to hold tax bracket details
    {
        public double Lower { get; set; }
        public double Upper { get; set; }
        public double Rate { get; set; }
        public double FixedAmount { get; set; }

        public TaxBracket(double lower, double upper, double rate, double fixedAmount)
        {
            Lower = lower;
            Upper = upper;
            Rate = rate;
            FixedAmount = fixedAmount;
        }


        string taxThresholdloc = "C:\\Users\\3dcc03c7656da9e6\\OneDrive - TAFE NSW\\AlexW\\Programming (c # )\\oop asssss2\\Cl_OOProgramming_AE_Pro_Appx\\Part 3 application files\\taxrate-withthreshold.csv";
        string taxNoThresholdloc = "C:\\Users\\3dcc03c7656da9e6\\OneDrive - TAFE NSW\\AlexW\\Programming (c # )\\oop asssss2\\Cl_OOProgramming_AE_Pro_Appx\\Part 3 application files\\taxrate-nothreshold.csv";
        string employeeLoc = "C:\\Users\\3dcc03c7656da9e6\\OneDrive - TAFE NSW\\AlexW\\Programming (c # )\\oop asssss2\\Cl_OOProgramming_AE_Pro_Appx\\Part 3 application files\\employees.csv";

        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }

            // Employee class to store the details
            public class Employee
            {
                public int EmployeeId { get; set; }
                public string FirstName { get; set; }
                public string LastName { get; set; }

                public Employee(int employeeId, string firstName, string lastName)
                {
                    EmployeeId = employeeId;
                    FirstName = firstName;
                    LastName = lastName;
                }

                public override string ToString()
                {
                    return $"{EmployeeId} - {FirstName} {LastName}";
                }
            }

            // Method to load employee data from CSV
            private void LoadEmployeeData(string filePath)
            {
                var employees = new List<Employee>();

                try
                {
                    using (var reader = new StreamReader(filePath))
                    {
                        // Skip header row
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            // Assuming the CSV format: EmployeeId, FirstName, LastName
                            var employee = new Employee(int.Parse(values[0]), values[1], values[2]);
                            employees.Add(employee);
                        }
                    }

                    // Populate the ListBox with employee details
                    foreach (var employee in employees)
                    {
                        employeeListBox.Items.Add(employee);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading employee data: " + ex.Message);
                }
            }

            // Event to trigger when the form is loaded
            private void Form1_Load(object sender, EventArgs e)
            {
                // Load employee data from the CSV file
                string filePath = "C:\\Users\\3dcc03c7656da9e6\\OneDrive - TAFE NSW\\AlexW\\Programming (c # )\\oop asssss2\\Cl_OOProgramming_AE_Pro_Appx\\Part 3 application files\\employees.csv"; // Update with the actual path
                LoadEmployeeData(filePath);
            }
        } } }