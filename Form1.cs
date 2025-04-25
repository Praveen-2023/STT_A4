using System;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;

namespace TimeAlarmWinForms
{
    // Delegate for the alarm event
    public delegate void AlarmEventHandler(object? sender, EventArgs e);

    // AlarmClock class (copied from Activity 1, with nullable event)
    public class AlarmClock
    {
        public event AlarmEventHandler? raiseAlarm;
        private TimeSpan targetTime;

        public AlarmClock(string timeInput)
        {
            if (!TimeSpan.TryParse(timeInput, out targetTime))
            {
                throw new ArgumentException("Invalid time format. Use HH:MM:SS.");
            }
        }

        public void Start()
        {
            while (true)
            {
                TimeSpan currentTime = DateTime.Now.TimeOfDay;
                if (Math.Abs((currentTime - targetTime).TotalSeconds) < 1)
                {
                    raiseAlarm?.Invoke(this, EventArgs.Empty);
                    break;
                }
                System.Threading.Thread.Sleep(100);
            }
        }
    }

    public partial class Form1 : Form
    {
        private System.Timers.Timer? colorTimer;
        private readonly Random random = new Random();
        private AlarmClock? alarmClock; // Nullable to fix warning

        public Form1()
        {
            InitializeComponent();
            // Initialize timer
            colorTimer = new System.Timers.Timer(1000); // 1 second
            colorTimer.Elapsed += ColorTimer_Elapsed;
        }

        private void buttonStart_Click(object? sender, EventArgs e)
        {
            try
            {
                string timeInput = textBoxTime.Text;
                alarmClock = new AlarmClock(timeInput);
                alarmClock.raiseAlarm += AlarmClock_raiseAlarm;
                colorTimer?.Start();
                buttonStart.Enabled = false;
                textBoxTime.Enabled = false;
                System.Threading.Tasks.Task.Run(() => alarmClock.Start());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ColorTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                this.BackColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            });
        }

        private void AlarmClock_raiseAlarm(object? sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                colorTimer?.Stop();
                MessageBox.Show("Alarm! The target time has been reached!", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttonStart.Enabled = true;
                textBoxTime.Enabled = true;
                this.BackColor = SystemColors.Control;
            });
        }
    }
}
