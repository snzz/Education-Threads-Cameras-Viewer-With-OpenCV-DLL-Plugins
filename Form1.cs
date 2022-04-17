using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace SoftEngineering_lab_2
{
    public partial class Form1 : Form
    {
        private Thread firstStreamThread;
        private bool isFirstStreamActive;
        private bool isFirstFilterActive;

        private Thread secondstreamThread;
        private bool isSecondStreamActive;
        private bool isSecondFilterActive;

        public Form1()
        {
            InitializeComponent();
            
            isFirstStreamActive = false;
            isFirstFilterActive = false;
            firstStreamThread = new Thread(() => GetStreamFrame(
                isFirstStreamActive, isFirstFilterActive,
                "http://176.9.251.105/jpg/1/image.jpg", StreamFrameHolderPictureBox1));
            
            isSecondStreamActive = false;
            isSecondFilterActive = false;
            secondstreamThread = new Thread(() => GetStreamFrame(
                isSecondStreamActive, isSecondFilterActive,
                "http://213.202.40.157/jpg/1/image.jpg", StreamFrameHolderPictureBox2));

            PluginsEditor.LoadPluginsInListBox(
                Environment.CurrentDirectory, this.DLLsList);
        }

        private void GetStreamFrame(bool isStreamActive, bool isFilterActive, string sourceURL, PictureBox streamScreen)
        {
            while (isStreamActive)
            {
                byte[] buffer = new byte[250000];
                int read, total = 0;
                // create HTTP request
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(sourceURL);
                req.Credentials = new NetworkCredential("username", "pass");
                // get response
                WebResponse resp = req.GetResponse();
                // get response stream
                Stream stream = resp.GetResponseStream();
                // read data from stream
                while ((read = stream.Read(buffer, total, 1000)) != 0)
                    total += read;
                // get bitmap
                Bitmap bmp = (Bitmap)Bitmap.FromStream(
                              new MemoryStream(buffer, 0, total));

                if (isFilterActive)
                {
                    streamScreen.Image = PluginsEditor.ApplyPluginAction(
                                DLLsList.SelectedItem.ToString(),
                                (Image)bmp,
                                this.PluginWorkSpaceGroupBox);
                    
                    this.Invoke((MethodInvoker)delegate
                    {
                        streamScreen.Image = PluginsEditor.ApplyPluginAction(
                                DLLsList.SelectedItem.ToString(),
                                (Image)bmp,
                                this.PluginWorkSpaceGroupBox);
                    });
                }
                else streamScreen.Image = bmp;
                stream.Close();
                resp.Close();
                //Thread.Sleep(timer1.Interval);
            }
        }

        private void TimerEnabledButton_Click(object sender, EventArgs e)
        {
            if (isFirstStreamActive)
            {
                isFirstStreamActive = false;
                //timer1.Enabled = false;
                StreamActionButton1.Text = "Возобновить";
                firstStreamThread.Abort();
                //firstStreamThread = new Thread(() => GetStreamFrame(isFirstStreamActive,
                //"http://176.9.251.105/jpg/1/image.jpg", StreamFrameHolderPictureBox1));
            }
            else
            {
                isFirstStreamActive = true;
                //timer1.Enabled = true;
                StreamActionButton1.Text = "Остановить";
                firstStreamThread = new Thread(() => GetStreamFrame(
                    isFirstStreamActive, isFirstFilterActive,
                "http://176.9.251.105/jpg/1/image.jpg", StreamFrameHolderPictureBox1));
                firstStreamThread.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            firstStreamThread.Abort();
            secondstreamThread.Abort();
            Application.Exit();
        }

        private void TimerEnabledButton2_Click(object sender, EventArgs e)
        {
            if (isSecondStreamActive)
            {
                isSecondStreamActive = false;
                //timer1.Enabled = false;
                StreamActionButton2.Text = "Возобновить";
                secondstreamThread.Abort();
                //secondstreamThread = new Thread(() => GetStreamFrame(isSecondStreamActive,
                //"http://180.6.112.86/jpg/1/image.jpg", StreamFrameHolderPictureBox2));
            }
            else
            {
                isSecondStreamActive = true;
                //timer1.Enabled = true;
                StreamActionButton2.Text = "Остановить";
                secondstreamThread = new Thread(() => GetStreamFrame(
                    isSecondStreamActive, isSecondFilterActive,
                "http://213.202.40.157/jpg/1/image.jpg", StreamFrameHolderPictureBox2));
                secondstreamThread.Start();
            }
        }

        private void DLLsList_Click(object sender, EventArgs e)
        {
            ListBox lb = sender as ListBox;

            if (lb.SelectedIndex != -1)
            {
                if (PluginsEditor.currentGUIComponents.Length != 0)
                    PluginsEditor.ClearPluginGui(this.PluginWorkSpaceGroupBox);

                PluginDescriptionLabel.Text = PluginsEditor.GetPluginDescription(
                    DLLsList.SelectedItem.ToString());

                PluginsEditor.DrawPluginGUI(lb.SelectedItem.ToString(),
                    this.PluginWorkSpaceGroupBox);
            }
        }

        private void ApplyFilterButton1_Click(object sender, EventArgs e)
        {
            if (DLLsList.SelectedIndex == -1)
                MessageBox.Show("Выберите плагин из списка!");

            if (isFirstFilterActive)
            {
                isFirstFilterActive = false;
                (sender as Button).Text = "Применить обработку";
            }
            else
            {
                isFirstFilterActive = true;
                (sender as Button).Text = "Отменить обработку";
            }

            if (isFirstStreamActive)
            {
                firstStreamThread.Abort();
                firstStreamThread = new Thread(() => GetStreamFrame(
                    isFirstStreamActive, isFirstFilterActive,
                "http://176.9.251.105/jpg/1/image.jpg", StreamFrameHolderPictureBox1));
                firstStreamThread.Start();
            }
        }

        private void добавитьПлагинToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "dll files (*.dll)|*.dll|All files (*.dll)|*.dll";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DLLsList.Items.Add(Path.GetFileName(openFileDialog1.FileName));
            }
        }

        private void ApplyFilterButton2_Click(object sender, EventArgs e)
        {
            if (DLLsList.SelectedIndex == -1)
                MessageBox.Show("Выберите плагин из списка!");

            if (isSecondFilterActive)
            {
                isSecondFilterActive = false;
                (sender as Button).Text = "Применить обработку";
            }
            else
            {
                isSecondFilterActive = true;
                (sender as Button).Text = "Отменить обработку";
            }

            if (isSecondFilterActive)
            {
                secondstreamThread.Abort();
                secondstreamThread = new Thread(() => GetStreamFrame(
                    isSecondStreamActive, isSecondFilterActive,
                "http://213.202.40.157/jpg/1/image.jpg", StreamFrameHolderPictureBox2));
                secondstreamThread.Start();
            }
        }
    }
}
