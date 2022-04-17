
namespace SoftEngineering_lab_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StreamFrameHolderPictureBox1 = new System.Windows.Forms.PictureBox();
            this.StreamActionButton1 = new System.Windows.Forms.Button();
            this.StreamPartPanel1 = new System.Windows.Forms.Panel();
            this.StreamActionsPanel1 = new System.Windows.Forms.Panel();
            this.ApplyFilterButton1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьПлагинToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PluginsTree = new System.Windows.Forms.GroupBox();
            this.DLLsList = new System.Windows.Forms.ListBox();
            this.PluginDescription = new System.Windows.Forms.GroupBox();
            this.PluginDescriptionLabel = new System.Windows.Forms.Label();
            this.StreamPartPanel2 = new System.Windows.Forms.Panel();
            this.StreamFrameHolderPictureBox2 = new System.Windows.Forms.PictureBox();
            this.StreamActionsPanel2 = new System.Windows.Forms.Panel();
            this.ApplyFilterButton2 = new System.Windows.Forms.Button();
            this.StreamActionButton2 = new System.Windows.Forms.Button();
            this.PluginWorkSpaceGroupBox = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.StreamFrameHolderPictureBox1)).BeginInit();
            this.StreamPartPanel1.SuspendLayout();
            this.StreamActionsPanel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.PluginsTree.SuspendLayout();
            this.PluginDescription.SuspendLayout();
            this.StreamPartPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StreamFrameHolderPictureBox2)).BeginInit();
            this.StreamActionsPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StreamFrameHolderPictureBox1
            // 
            this.StreamFrameHolderPictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreamFrameHolderPictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StreamFrameHolderPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StreamFrameHolderPictureBox1.Location = new System.Drawing.Point(3, 45);
            this.StreamFrameHolderPictureBox1.Name = "StreamFrameHolderPictureBox1";
            this.StreamFrameHolderPictureBox1.Size = new System.Drawing.Size(558, 518);
            this.StreamFrameHolderPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StreamFrameHolderPictureBox1.TabIndex = 0;
            this.StreamFrameHolderPictureBox1.TabStop = false;
            // 
            // StreamActionButton1
            // 
            this.StreamActionButton1.BackColor = System.Drawing.Color.PaleGreen;
            this.StreamActionButton1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StreamActionButton1.Location = new System.Drawing.Point(3, 6);
            this.StreamActionButton1.Name = "StreamActionButton1";
            this.StreamActionButton1.Size = new System.Drawing.Size(99, 32);
            this.StreamActionButton1.TabIndex = 1;
            this.StreamActionButton1.Text = "Возобновить";
            this.StreamActionButton1.UseVisualStyleBackColor = false;
            this.StreamActionButton1.Click += new System.EventHandler(this.TimerEnabledButton_Click);
            // 
            // StreamPartPanel1
            // 
            this.StreamPartPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.StreamPartPanel1.Controls.Add(this.StreamFrameHolderPictureBox1);
            this.StreamPartPanel1.Controls.Add(this.StreamActionsPanel1);
            this.StreamPartPanel1.Location = new System.Drawing.Point(263, 36);
            this.StreamPartPanel1.Name = "StreamPartPanel1";
            this.StreamPartPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StreamPartPanel1.Size = new System.Drawing.Size(564, 566);
            this.StreamPartPanel1.TabIndex = 2;
            // 
            // StreamActionsPanel1
            // 
            this.StreamActionsPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreamActionsPanel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StreamActionsPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StreamActionsPanel1.Controls.Add(this.ApplyFilterButton1);
            this.StreamActionsPanel1.Controls.Add(this.StreamActionButton1);
            this.StreamActionsPanel1.Location = new System.Drawing.Point(3, 0);
            this.StreamActionsPanel1.Name = "StreamActionsPanel1";
            this.StreamActionsPanel1.Size = new System.Drawing.Size(558, 46);
            this.StreamActionsPanel1.TabIndex = 1;
            // 
            // ApplyFilterButton1
            // 
            this.ApplyFilterButton1.BackColor = System.Drawing.Color.PaleGreen;
            this.ApplyFilterButton1.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyFilterButton1.Location = new System.Drawing.Point(108, 6);
            this.ApplyFilterButton1.Name = "ApplyFilterButton1";
            this.ApplyFilterButton1.Size = new System.Drawing.Size(149, 32);
            this.ApplyFilterButton1.TabIndex = 2;
            this.ApplyFilterButton1.Text = "Применить обработку";
            this.ApplyFilterButton1.UseVisualStyleBackColor = false;
            this.ApplyFilterButton1.Click += new System.EventHandler(this.ApplyFilterButton1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LimeGreen;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1404, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьПлагинToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // добавитьПлагинToolStripMenuItem
            // 
            this.добавитьПлагинToolStripMenuItem.Name = "добавитьПлагинToolStripMenuItem";
            this.добавитьПлагинToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.добавитьПлагинToolStripMenuItem.Text = "Добавить плагин";
            this.добавитьПлагинToolStripMenuItem.Click += new System.EventHandler(this.добавитьПлагинToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            // 
            // PluginsTree
            // 
            this.PluginsTree.Controls.Add(this.DLLsList);
            this.PluginsTree.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PluginsTree.Location = new System.Drawing.Point(13, 27);
            this.PluginsTree.Name = "PluginsTree";
            this.PluginsTree.Size = new System.Drawing.Size(244, 370);
            this.PluginsTree.TabIndex = 4;
            this.PluginsTree.TabStop = false;
            this.PluginsTree.Text = "Плагины";
            // 
            // DLLsList
            // 
            this.DLLsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DLLsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DLLsList.FormattingEnabled = true;
            this.DLLsList.ItemHeight = 15;
            this.DLLsList.Location = new System.Drawing.Point(3, 19);
            this.DLLsList.Name = "DLLsList";
            this.DLLsList.Size = new System.Drawing.Size(238, 348);
            this.DLLsList.TabIndex = 0;
            this.DLLsList.Click += new System.EventHandler(this.DLLsList_Click);
            // 
            // PluginDescription
            // 
            this.PluginDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PluginDescription.Controls.Add(this.PluginDescriptionLabel);
            this.PluginDescription.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PluginDescription.Location = new System.Drawing.Point(12, 403);
            this.PluginDescription.Name = "PluginDescription";
            this.PluginDescription.Size = new System.Drawing.Size(244, 370);
            this.PluginDescription.TabIndex = 5;
            this.PluginDescription.TabStop = false;
            this.PluginDescription.Text = "Описание";
            // 
            // PluginDescriptionLabel
            // 
            this.PluginDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PluginDescriptionLabel.Location = new System.Drawing.Point(3, 19);
            this.PluginDescriptionLabel.Name = "PluginDescriptionLabel";
            this.PluginDescriptionLabel.Size = new System.Drawing.Size(238, 348);
            this.PluginDescriptionLabel.TabIndex = 0;
            // 
            // StreamPartPanel2
            // 
            this.StreamPartPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreamPartPanel2.Controls.Add(this.StreamFrameHolderPictureBox2);
            this.StreamPartPanel2.Controls.Add(this.StreamActionsPanel2);
            this.StreamPartPanel2.Location = new System.Drawing.Point(830, 36);
            this.StreamPartPanel2.Name = "StreamPartPanel2";
            this.StreamPartPanel2.Size = new System.Drawing.Size(564, 566);
            this.StreamPartPanel2.TabIndex = 3;
            // 
            // StreamFrameHolderPictureBox2
            // 
            this.StreamFrameHolderPictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreamFrameHolderPictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.StreamFrameHolderPictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StreamFrameHolderPictureBox2.Location = new System.Drawing.Point(3, 45);
            this.StreamFrameHolderPictureBox2.Name = "StreamFrameHolderPictureBox2";
            this.StreamFrameHolderPictureBox2.Size = new System.Drawing.Size(558, 518);
            this.StreamFrameHolderPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.StreamFrameHolderPictureBox2.TabIndex = 0;
            this.StreamFrameHolderPictureBox2.TabStop = false;
            // 
            // StreamActionsPanel2
            // 
            this.StreamActionsPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StreamActionsPanel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StreamActionsPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StreamActionsPanel2.Controls.Add(this.ApplyFilterButton2);
            this.StreamActionsPanel2.Controls.Add(this.StreamActionButton2);
            this.StreamActionsPanel2.Location = new System.Drawing.Point(3, 0);
            this.StreamActionsPanel2.Name = "StreamActionsPanel2";
            this.StreamActionsPanel2.Size = new System.Drawing.Size(558, 46);
            this.StreamActionsPanel2.TabIndex = 1;
            // 
            // ApplyFilterButton2
            // 
            this.ApplyFilterButton2.BackColor = System.Drawing.Color.PaleGreen;
            this.ApplyFilterButton2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplyFilterButton2.Location = new System.Drawing.Point(108, 6);
            this.ApplyFilterButton2.Name = "ApplyFilterButton2";
            this.ApplyFilterButton2.Size = new System.Drawing.Size(149, 32);
            this.ApplyFilterButton2.TabIndex = 3;
            this.ApplyFilterButton2.Text = "Применить обработку";
            this.ApplyFilterButton2.UseVisualStyleBackColor = false;
            this.ApplyFilterButton2.Click += new System.EventHandler(this.ApplyFilterButton2_Click);
            // 
            // StreamActionButton2
            // 
            this.StreamActionButton2.BackColor = System.Drawing.Color.PaleGreen;
            this.StreamActionButton2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StreamActionButton2.Location = new System.Drawing.Point(3, 6);
            this.StreamActionButton2.Name = "StreamActionButton2";
            this.StreamActionButton2.Size = new System.Drawing.Size(99, 32);
            this.StreamActionButton2.TabIndex = 1;
            this.StreamActionButton2.Text = "Возобновить";
            this.StreamActionButton2.UseVisualStyleBackColor = false;
            this.StreamActionButton2.Click += new System.EventHandler(this.TimerEnabledButton2_Click);
            // 
            // PluginWorkSpaceGroupBox
            // 
            this.PluginWorkSpaceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PluginWorkSpaceGroupBox.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.PluginWorkSpaceGroupBox.Location = new System.Drawing.Point(263, 608);
            this.PluginWorkSpaceGroupBox.Name = "PluginWorkSpaceGroupBox";
            this.PluginWorkSpaceGroupBox.Size = new System.Drawing.Size(1134, 165);
            this.PluginWorkSpaceGroupBox.TabIndex = 6;
            this.PluginWorkSpaceGroupBox.TabStop = false;
            this.PluginWorkSpaceGroupBox.Text = "Интерфейс плагина";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1404, 779);
            this.Controls.Add(this.PluginWorkSpaceGroupBox);
            this.Controls.Add(this.StreamPartPanel2);
            this.Controls.Add(this.PluginDescription);
            this.Controls.Add(this.PluginsTree);
            this.Controls.Add(this.StreamPartPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "StreamEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.StreamFrameHolderPictureBox1)).EndInit();
            this.StreamPartPanel1.ResumeLayout(false);
            this.StreamActionsPanel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PluginsTree.ResumeLayout(false);
            this.PluginDescription.ResumeLayout(false);
            this.StreamPartPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StreamFrameHolderPictureBox2)).EndInit();
            this.StreamActionsPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox StreamFrameHolderPictureBox1;
        private System.Windows.Forms.Button StreamActionButton1;
        private System.Windows.Forms.Panel StreamPartPanel1;
        private System.Windows.Forms.Panel StreamActionsPanel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьПлагинToolStripMenuItem;
        private System.Windows.Forms.GroupBox PluginsTree;
        private System.Windows.Forms.GroupBox PluginDescription;
        private System.Windows.Forms.Label PluginDescriptionLabel;
        private System.Windows.Forms.Panel StreamPartPanel2;
        private System.Windows.Forms.PictureBox StreamFrameHolderPictureBox2;
        private System.Windows.Forms.Panel StreamActionsPanel2;
        private System.Windows.Forms.Button StreamActionButton2;
        private System.Windows.Forms.GroupBox PluginWorkSpaceGroupBox;
        private System.Windows.Forms.ListBox DLLsList;
        private System.Windows.Forms.Button ApplyFilterButton1;
        private System.Windows.Forms.Button ApplyFilterButton2;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
    }
}

