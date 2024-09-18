using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.Reflection.Emit;

namespace lab_3_OS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] Id = new int[1000];
        string[] Info = new string[1000]; 
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int k = 0;
            
            foreach (Process process in Process.GetProcesses())
            {
                string StartTime = "", Modules = "";
                try 
                { 
                    StartTime = process.StartTime.ToString();
                    Modules = process.Modules.ToString();
                }
                catch{ }
                int i = process.Id;
                string j = process.ProcessName;
                listBox1.Items.Add(i + " " + j);
                Id[k] = i;
                Info[k] = $"Id процесса: {process.Id}\n" +
                    $"Имя процесса: {process.ProcessName}\n" +
                    $"Имя машины: {process.MachineName}\n" +
                    $"Время запуска процесса: {StartTime}\n" +
                    $"Объём памяти процесса: {process.VirtualMemorySize64}\n" +
                    $"Используемые модули: {Modules}";
                k++;
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = Info[listBox1.SelectedIndex].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ofd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            }
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(ofd.FileName);
            process.Start();
        }
    }
}