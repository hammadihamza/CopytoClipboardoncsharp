using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copytoclipboard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(textBox1.Text);
                label1.Text = "Copied! and will be removed from Clipboard in a few seconds";
                var t = new Timer();
                t.Interval = 60000; // it will disappear in 1 minute
                textBox1.Text = String.Empty;
                t.Tick += (s, eee) =>
                    {
                        label1.Hide();
                        t.Stop();
                        Clipboard.Clear();
                    };
                t.Start();
                
            }
            catch (Exception exc)
            { MessageBox.Show(exc.Message); }
        }
    }
}
