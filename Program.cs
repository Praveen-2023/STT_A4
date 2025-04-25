using System;
using System.Threading;

namespace TimeAlarmConsole
{
    // Define the delegate for the alarm event
    public delegate void AlarmEventHandler(object sender, EventArgs e);

    // Publisher class
    public class AlarmClock
    {
        // Declare the event using the delegate
        public event AlarmEventHandler raiseAlarm;

        private TimeSpan targetTime;

        public AlarmClock(string timeInput)
        {
            // Parse input time (HH:MM:SS)
            if (!TimeSpan.TryParse(timeInput, out targetTime))
            {
                throw new ArgumentException("Invalid time format. Use HH:MM:SS.");
            }
        }

        public void Start()
        {
            Console.WriteLine("Alarm clock started. Waiting for target time...");
            while (true)
            {
                // Get current system time (only hours, minutes, seconds)
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                // Compare hours, minutes, seconds
                if (Math.Abs((currentTime - targetTime).TotalSeconds) < 1)
                {
                    // Raise the event
                    raiseAlarm?.Invoke(this, EventArgs.Empty);
                    break; // Exit after alarm
                }
                // Wait 100ms to avoid excessive CPU usage
                Thread.Sleep(100);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Get time input
                Console.Write("Enter alarm time (HH:MM:SS): ");
                string timeInput = Console.ReadLine();

                // Create publisher
                AlarmClock alarmClock = new AlarmClock(timeInput);

                // Subscribe to the event
                alarmClock.raiseAlarm += Ring_alarm;

                // Start the alarm clock
                alarmClock.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Event handler (subscriber)
        static void Ring_alarm(object sender, EventArgs e)
        {
            Console.WriteLine("Alarm! The target time has been reached!");
        }
    }
}