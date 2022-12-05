using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TyperGame
{
    public partial class Form1 : Form
    {
        private Random _random = new Random();
        private Stats _stats = new Stats();

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;

        }

        /// <summary>
        /// The timer will be called every 800 milliseconds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add((Keys)_random.Next(65, 90));
            if (listBox1.Items.Count > 7)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Game Over...");
                timer1.Stop();
            }

        }

        /// <summary>
        /// Handle User Key press event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (listBox1.Items.Contains(e.KeyCode))
            {
                listBox1.Items.Remove(e.KeyCode);
                listBox1.Refresh();

                if (timer1.Interval > 400)
                    timer1.Interval -= 10;
                if (timer1.Interval > 250)
                    timer1.Interval -= 7;
                if (timer1.Interval > 100)
                    timer1.Interval -= 2;

                progressBar.Value = 800 - timer1.Interval;

                _stats.Update(true);
            }
            else
            {
                _stats.Update(false);
            }

            correctLabel.Text = $"Correct: {_stats.Correct}";
            missedLabel.Text = $"Missed: {_stats.Missed}";
            totalLabel.Text = $"Total: {_stats.Total}";
            accuracyLabel.Text = $"Accuracy: {_stats.Accuracy}%";
        }
    }
}