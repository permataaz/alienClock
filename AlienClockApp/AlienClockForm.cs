using System;
using System.Windows.Forms;
using System.Timers;

namespace AlienClockApp
{
    public partial class AlienClockForm : Form
    {
        // Arrays for months and days
        static int[] monthsArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 20, 11, 12, 13, 14, 15, 16, 17, 18 };
        static int[] daysArray = { 44, 42, 48, 40, 48, 44, 40, 44, 42, 40, 40, 42, 44, 48, 42, 40, 44, 38 };

        // Time conversion constants
        const double earthSecondsPerCustomSecond = 0.5;  // 1 custom second = 0.5 Earth seconds
        const int secondsPerMinute = 90;
        const int minutesPerHour = 90;
        const int hoursPerDay = 36;

        // Base custom time at Unix Epoch
        const int baseYear = 2804;
        const int baseMonth = 18;
        const int baseDay = 31;
        const int baseHour = 2;
        const int baseMinute = 2;
        const int baseSecond = 88;

        private System.Timers.Timer timer; // More precise timer
        private DateTime alienCustomTime;  // Used to store the set alien time

        private bool isCustomTimeSet = false;

        public AlienClockForm()
        {
            InitializeComponent();
        }

        private void AlienClockForm_Load(object sender, EventArgs e)
        {
            // Create the timer with a 500ms interval
            timer = new System.Timers.Timer(500); // 500 milliseconds = 0.5 seconds
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;  // Continue firing at the interval
            timer.Enabled = true;    // Start the timer

            // Set alienCustomTime to Earth Time initially
            alienCustomTime = DateTime.UtcNow;
        }

        // This method is called every 500ms by the timer
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            DateTime earthNow = DateTime.UtcNow.AddHours(8); // Earth time adjusted for GMT+8

            if (!isCustomTimeSet)
            {
                // If custom time is not set, update based on Earth time
                DisplayCurrentEarthTime(earthNow);
                ConvertEarthToCustomTime(earthNow);
            }
            else
            {
                // If custom time is set, just increment the custom time without reverting
                alienCustomTime = alienCustomTime.AddSeconds(earthSecondsPerCustomSecond);
                ConvertEarthToCustomTime(alienCustomTime);  // Update alien time display
                DisplayCurrentEarthTime(alienCustomTime);   // Update Earth time display
            }
        }

        // Convert Earth time to custom time
        private void ConvertEarthToCustomTime(DateTime earthNow)
        {
            // Calculate total Earth seconds since Unix Epoch
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan earthTimeElapsed = earthNow - unixEpoch;
            double totalEarthSecondsElapsed = earthTimeElapsed.TotalSeconds;

            // Convert Earth seconds to custom seconds
            double totalCustomSecondsElapsed = totalEarthSecondsElapsed / earthSecondsPerCustomSecond;

            // Add the initial custom time offset
            long initialCustomSeconds = GetInitialCustomSecondsOffset();
            totalCustomSecondsElapsed += initialCustomSeconds;

            // Convert the total custom seconds into time components
            ConvertCustomSecondsToTime(totalCustomSecondsElapsed);
        }

        // Convert total custom seconds into custom time (with overflow handling)
        private void ConvertCustomSecondsToTime(double totalCustomSeconds)
        {
            // Break down custom time
            int customSeconds = (int)(totalCustomSeconds % secondsPerMinute);
            int totalCustomMinutes = (int)(totalCustomSeconds / secondsPerMinute);

            int customMinutes = totalCustomMinutes % minutesPerHour;
            int totalCustomHours = totalCustomMinutes / minutesPerHour;

            int customHours = totalCustomHours % hoursPerDay;
            int totalCustomDays = totalCustomHours / hoursPerDay;

            // Now, calculate custom years, months, and days
            int customYears = baseYear;
            int customMonths = baseMonth;
            int customDays = baseDay;

            // Calculate years
            while (totalCustomDays > GetTotalDaysInYear())
            {
                totalCustomDays -= GetTotalDaysInYear();
                customYears++;
            }

            // Calculate months
            for (int i = 0; i < monthsArray.Length; i++)
            {
                if (totalCustomDays < daysArray[i])
                {
                    customDays = totalCustomDays + 1;
                    customMonths = monthsArray[i];
                    break;
                }
                totalCustomDays -= daysArray[i];
            }

            // Display final custom time in the label
            labelCustomTime.Invoke((MethodInvoker)(() => labelCustomTime.Text = $"{customYears:D4}/{customMonths:D2}/{customDays:D2} \n {customHours:D2}:{customMinutes:D2}:{customSeconds:D2}"));
        }

        // Get initial custom seconds offset (starting time)
        private long GetInitialCustomSecondsOffset()
        {
            long totalSeconds = baseSecond;
            totalSeconds += baseMinute * secondsPerMinute;
            totalSeconds += baseHour * minutesPerHour * secondsPerMinute;
            totalSeconds += (baseDay - 1) * hoursPerDay * minutesPerHour * secondsPerMinute;

            // Add months (sum of days in previous months)
            for (int i = 0; i < baseMonth - 1; i++)
            {
                totalSeconds += daysArray[i] * hoursPerDay * minutesPerHour * secondsPerMinute;
            }

            return totalSeconds;
        }

        // Get total number of days in a custom year
        private int GetTotalDaysInYear()
        {
            int totalDays = 0;
            foreach (int days in daysArray)
            {
                totalDays += days;
            }
            return totalDays;
        }

        // Display current Earth time in the label
        private void DisplayCurrentEarthTime(DateTime earthNow)
        {
            DateTime gmtPlus8Time = earthNow.AddHours(8);
            earthlbl.Invoke((MethodInvoker)(() => earthlbl.Text = $"{earthNow:yyyy/MM/dd \n HH:mm:ss}"));
        }

   
        
       

        // Convert custom alien time to Earth time
        private DateTime ConvertCustomTimeToEarth(int year, int month, int day, int hour, int minute, int second)
        {
            // Convert the user-provided custom time to Earth seconds
            long totalCustomSeconds = second;
            totalCustomSeconds += minute * secondsPerMinute;
            totalCustomSeconds += hour * minutesPerHour * secondsPerMinute;
            totalCustomSeconds += (day - 1) * hoursPerDay * minutesPerHour * secondsPerMinute;

            // Add months (sum of days in previous months)
            for (int i = 0; i < month - 1; i++)
            {
                totalCustomSeconds += daysArray[i] * hoursPerDay * minutesPerHour * secondsPerMinute;
            }

            // Subtract base custom time to get the elapsed time
            long elapsedCustomSeconds = totalCustomSeconds - GetInitialCustomSecondsOffset();

            // Convert the elapsed custom seconds to Earth seconds
            double elapsedEarthSeconds = elapsedCustomSeconds * earthSecondsPerCustomSecond;

            // Calculate the Earth time
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime earthTime = unixEpoch.AddSeconds(elapsedEarthSeconds);

            return earthTime;
        }

        private void UpdateCustomTime(int year, int month, int day, int hour, int minute, int second)
        {
            isCustomTimeSet = true; 

            // Convert the new custom time to Earth time and update both displays
            alienCustomTime = ConvertCustomTimeToEarth(year, month, day, hour, minute, second);

            ConvertEarthToCustomTime(alienCustomTime);  
            DisplayCurrentEarthTime(alienCustomTime);   
        }

        private void setTimebtn_Click(object sender, EventArgs e)
        {

            // Create a new instance of the SetCustomTimeForm
            using (SetTimeForm setTime = new SetTimeForm())
            {

                //Set isTimeSet back to false
                isCustomTimeSet = false; 


                
                if (setTime.ShowDialog() == DialogResult.OK)
                {
                   
                    int year = setTime.Year;
                    int month = setTime.Month;
                    int day = setTime.Day;
                    int hour = setTime.Hour;
                    int minute = setTime.Minute;
                    int second = setTime.Second;

                    UpdateCustomTime(year, month, day, hour, minute, second);
                }
            
            }

        }


    }
}
