using System;
using System.Windows.Forms;

namespace AlienClockApp
{
    public partial class SetTimeForm : Form
    {
        // Properties to hold the validated time values
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }
        public int Hour { get; private set; }
        public int Minute { get; private set; }
        public int Second { get; private set; }

        // Array to hold the maximum days in each month
        private static int[] daysArray = { 44, 42, 48, 40, 48, 44, 40, 44, 42, 40, 40, 42, 44, 48, 42, 40, 44, 38 };

        public SetTimeForm()
        {
            InitializeComponent();

            // Initialize default values
            Year = 2804;
            Month = 18;
            Day = 31;
            Hour = 2;
            Minute = 2;
            Second = 88;

            // Populate default values in the text boxes
            txtYear.Text = Year.ToString();
            txtMonth.Text = Month.ToString();
            txtDay.Text = Day.ToString();
            txtHour.Text = Hour.ToString();
            txtMinute.Text = Minute.ToString();
            txtSecond.Text = Second.ToString();
        }

        // Event handler for OK button click
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Input validation
            if (!int.TryParse(txtYear.Text, out int year) || year < 2804)
            {
                MessageBox.Show("Invalid year. The year must be greater than or equal to 2804.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMonth.Text, out int month) || month < 1 || month > 18)
            {
                MessageBox.Show("Invalid month. Please enter a value between 1 and 18.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtDay.Text, out int day) || day < 1 || day > daysArray[month - 1])
            {
                MessageBox.Show($"Invalid day. For month {month}, please enter a value between 1 and {daysArray[month - 1]}.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtHour.Text, out int hour) || hour < 0 || hour >= 36)
            {
                MessageBox.Show("Invalid hour. Please enter a value between 0 and 35.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMinute.Text, out int minute) || minute < 0 || minute >= 90)
            {
                MessageBox.Show("Invalid minute. Please enter a value between 0 and 89.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtSecond.Text, out int second) || second < 0 || second >= 90)
            {
                MessageBox.Show("Invalid second. Please enter a value between 0 and 89.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Assign values to the properties if all inputs are valid
            Year = year;
            Month = month;
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;

            // Close the form and return OK result
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Event handler for Cancel button click
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving the input
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }
}