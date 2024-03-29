﻿namespace ImageBatch
{
    partial class MainForm
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
            this.foldersToScanListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.operationCheckbox = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.fileLabelTextbox = new System.Windows.Forms.TextBox();
            this.outputFolderTextbox = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.totalBatchManagers = new System.Windows.Forms.Label();
            this.amountProcessedLabel = new System.Windows.Forms.Label();
            this.imagesToProcessLabel = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.inputImageButton = new System.Windows.Forms.Button();
            this.aspectRatioCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.widthNumeric = new System.Windows.Forms.NumericUpDown();
            this.heightNumeric = new System.Windows.Forms.NumericUpDown();
            this.additionalImageTextbox = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.globalToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.infoTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // foldersToScanListBox
            // 
            this.foldersToScanListBox.FormattingEnabled = true;
            this.foldersToScanListBox.Location = new System.Drawing.Point(6, 19);
            this.foldersToScanListBox.Name = "foldersToScanListBox";
            this.foldersToScanListBox.Size = new System.Drawing.Size(120, 108);
            this.foldersToScanListBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.deleteButton);
            this.groupBox1.Controls.Add(this.addButton);
            this.groupBox1.Controls.Add(this.foldersToScanListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image Folders";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(132, 48);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(132, 19);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add ";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.operationCheckbox);
            this.groupBox2.Location = new System.Drawing.Point(277, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 130);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Batch Operations";
            // 
            // operationCheckbox
            // 
            this.operationCheckbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationCheckbox.FormattingEnabled = true;
            this.operationCheckbox.Location = new System.Drawing.Point(3, 16);
            this.operationCheckbox.MultiColumn = true;
            this.operationCheckbox.Name = "operationCheckbox";
            this.operationCheckbox.Size = new System.Drawing.Size(324, 111);
            this.operationCheckbox.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.fileLabelTextbox);
            this.groupBox3.Controls.Add(this.outputFolderTextbox);
            this.groupBox3.Location = new System.Drawing.Point(13, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Options";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(5, 47);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "Output";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "File Label";
            // 
            // fileLabelTextbox
            // 
            this.fileLabelTextbox.Location = new System.Drawing.Point(83, 20);
            this.fileLabelTextbox.Name = "fileLabelTextbox";
            this.fileLabelTextbox.Size = new System.Drawing.Size(177, 20);
            this.fileLabelTextbox.TabIndex = 5;
            this.globalToolTip.SetToolTip(this.fileLabelTextbox, "What do we ultimately name the base name of the file");
            this.fileLabelTextbox.TextChanged += new System.EventHandler(this.fileLabelTextbox_TextChanged);
            // 
            // outputFolderTextbox
            // 
            this.outputFolderTextbox.Location = new System.Drawing.Point(83, 49);
            this.outputFolderTextbox.Name = "outputFolderTextbox";
            this.outputFolderTextbox.Size = new System.Drawing.Size(177, 20);
            this.outputFolderTextbox.TabIndex = 1;
            this.globalToolTip.SetToolTip(this.outputFolderTextbox, "Output directory location");
            this.outputFolderTextbox.TextChanged += new System.EventHandler(this.outputFolderTextbox_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.totalBatchManagers);
            this.groupBox4.Controls.Add(this.amountProcessedLabel);
            this.groupBox4.Controls.Add(this.imagesToProcessLabel);
            this.groupBox4.Location = new System.Drawing.Point(18, 266);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(261, 116);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Process Information";
            // 
            // totalBatchManagers
            // 
            this.totalBatchManagers.AutoSize = true;
            this.totalBatchManagers.Location = new System.Drawing.Point(7, 71);
            this.totalBatchManagers.Name = "totalBatchManagers";
            this.totalBatchManagers.Size = new System.Drawing.Size(115, 13);
            this.totalBatchManagers.TabIndex = 2;
            this.totalBatchManagers.Text = "Total Batch Managers:";
            // 
            // amountProcessedLabel
            // 
            this.amountProcessedLabel.AutoSize = true;
            this.amountProcessedLabel.Location = new System.Drawing.Point(7, 43);
            this.amountProcessedLabel.Name = "amountProcessedLabel";
            this.amountProcessedLabel.Size = new System.Drawing.Size(99, 13);
            this.amountProcessedLabel.TabIndex = 1;
            this.amountProcessedLabel.Text = "Amount Processed:";
            // 
            // imagesToProcessLabel
            // 
            this.imagesToProcessLabel.AutoSize = true;
            this.imagesToProcessLabel.Location = new System.Drawing.Point(7, 20);
            this.imagesToProcessLabel.Name = "imagesToProcessLabel";
            this.imagesToProcessLabel.Size = new System.Drawing.Size(97, 13);
            this.imagesToProcessLabel.TabIndex = 0;
            this.imagesToProcessLabel.Text = "Images to Process:";
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(445, 359);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 5;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(526, 359);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.inputImageButton);
            this.groupBox5.Controls.Add(this.aspectRatioCheckBox);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.widthNumeric);
            this.groupBox5.Controls.Add(this.heightNumeric);
            this.groupBox5.Controls.Add(this.additionalImageTextbox);
            this.groupBox5.Location = new System.Drawing.Point(286, 159);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(321, 100);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Built in Operations Options";
            // 
            // inputImageButton
            // 
            this.inputImageButton.Location = new System.Drawing.Point(6, 18);
            this.inputImageButton.Name = "inputImageButton";
            this.inputImageButton.Size = new System.Drawing.Size(75, 23);
            this.inputImageButton.TabIndex = 6;
            this.inputImageButton.Text = "Input";
            this.inputImageButton.UseVisualStyleBackColor = true;
            this.inputImageButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // aspectRatioCheckBox
            // 
            this.aspectRatioCheckBox.AutoSize = true;
            this.aspectRatioCheckBox.Location = new System.Drawing.Point(185, 63);
            this.aspectRatioCheckBox.Name = "aspectRatioCheckBox";
            this.aspectRatioCheckBox.Size = new System.Drawing.Size(130, 17);
            this.aspectRatioCheckBox.TabIndex = 11;
            this.aspectRatioCheckBox.Text = "Maintain Aspect Ratio";
            this.aspectRatioCheckBox.UseVisualStyleBackColor = true;
            this.aspectRatioCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Width";
            // 
            // widthNumeric
            // 
            this.widthNumeric.Location = new System.Drawing.Point(59, 46);
            this.widthNumeric.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.widthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumeric.Name = "widthNumeric";
            this.widthNumeric.Size = new System.Drawing.Size(120, 20);
            this.widthNumeric.TabIndex = 8;
            this.widthNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.widthNumeric.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // heightNumeric
            // 
            this.heightNumeric.Location = new System.Drawing.Point(59, 74);
            this.heightNumeric.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.heightNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumeric.Name = "heightNumeric";
            this.heightNumeric.Size = new System.Drawing.Size(120, 20);
            this.heightNumeric.TabIndex = 7;
            this.heightNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.heightNumeric.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // additionalImageTextbox
            // 
            this.additionalImageTextbox.Location = new System.Drawing.Point(95, 20);
            this.additionalImageTextbox.Name = "additionalImageTextbox";
            this.additionalImageTextbox.Size = new System.Drawing.Size(212, 20);
            this.additionalImageTextbox.TabIndex = 0;
            this.globalToolTip.SetToolTip(this.additionalImageTextbox, "Supply an additional image. EG: for watermarking");
            this.additionalImageTextbox.TextChanged += new System.EventHandler(this.additionalImageTextbox_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(286, 266);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(318, 84);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Additional Operation Options";
            // 
            // globalToolTip
            // 
            this.globalToolTip.AutomaticDelay = 250;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(286, 358);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(153, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // infoTimer
            // 
            this.infoTimer.Interval = 500;
            this.infoTimer.Tick += new System.EventHandler(this.infoTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 391);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Image Batcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.widthNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox foldersToScanListBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox operationCheckbox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox outputFolderTextbox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Label amountProcessedLabel;
        private System.Windows.Forms.Label imagesToProcessLabel;
        private System.Windows.Forms.TextBox fileLabelTextbox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button inputImageButton;
        private System.Windows.Forms.TextBox additionalImageTextbox;
        private System.Windows.Forms.NumericUpDown widthNumeric;
        private System.Windows.Forms.NumericUpDown heightNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox aspectRatioCheckBox;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip globalToolTip;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label totalBatchManagers;
        private System.Windows.Forms.Timer infoTimer;
    }
}

