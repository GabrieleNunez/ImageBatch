using ImageBatch.Core;
using ImageBatch.ImageOperations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImageBatch
{
    public partial class MainForm : Form
    {
        private BatchSettings batchSettings;
        private ControlCenter controlCenter;
        private delegate void SimpleInvokeHandler();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WatermarkOperation watermarkOp = new WatermarkOperation();
            operationCheckbox.Items.Add(watermarkOp);

            ShrinkOperation resizeOperation = new ShrinkOperation();
            operationCheckbox.Items.Add(resizeOperation);

            batchSettings = new BatchSettings();
            widthNumeric.Value = batchSettings.Width;
            heightNumeric.Value = batchSettings.Height;
            aspectRatioCheckBox.Checked = batchSettings.MaintainAspectRatio;
            outputFolderTextbox.Text = batchSettings.OutputDirectory;
            fileLabelTextbox.Text = batchSettings.FileLabel;
            additionalImageTextbox.Text = batchSettings.AdditionalImage;
            
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = true;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    outputFolderTextbox.Text = dialog.SelectedPath;
                }
            }
        }

        private void fileLabelTextbox_TextChanged(object sender, EventArgs e)
        {
            batchSettings.FileLabel = fileLabelTextbox.Text;
        }

        private void outputFolderTextbox_TextChanged(object sender, EventArgs e)
        {
            batchSettings.OutputDirectory = outputFolderTextbox.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "All Images|*.jpg;*.jpeg;*.tiff;*.png;*.gif";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    additionalImageTextbox.Text = dialog.FileName;
                }
            }
        }

        private void additionalImageTextbox_TextChanged(object sender, EventArgs e)
        {
            batchSettings.AdditionalImage = additionalImageTextbox.Text;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            batchSettings.MaintainAspectRatio = aspectRatioCheckBox.Checked;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            batchSettings.Width = (int)widthNumeric.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            batchSettings.Height = (int)heightNumeric.Value;
        }

        private void outputOptionsListbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.ShowNewFolderButton = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foldersToScanListBox.Items.Add(dialog.SelectedPath);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                foldersToScanListBox.Items.RemoveAt(foldersToScanListBox.SelectedIndex);
            }
            catch { }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            controlCenter = new ControlCenter(batchSettings);
            List<ImageOperation> operations = new List<ImageOperation>();
            foreach (string folder in foldersToScanListBox.Items)
            {
                controlCenter.AddFolder(folder);
            }
            foreach (ImageOperation operation in operationCheckbox.CheckedItems)
            {

                Debug.WriteLine("Added operation");
                operation.Load(batchSettings);
                operations.Add(operation);
            }
            imagesToProcessLabel.Text = string.Format("Images to process: {0}", controlCenter.TotalFiles);
            totalBatchManagers.Text = string.Format("Total Batch Managers: {0}", controlCenter.BatchManagerCount);
            foreach (Control control in this.Controls)
                control.Enabled = false;
            stopButton.Enabled = true;
            infoTimer.Enabled = true;
            progressBar1.Enabled = true;
            infoTimer.Start();
            controlCenter.Start(operations.ToArray());
            controlCenter.Done += controlCenter_Done;
            this.Cursor = Cursors.Arrow;
        }
        private void EnableControls()
        {
            infoTimer.Stop();
            foreach (Control control in this.Controls)
                control.Enabled = true;
            stopButton.Enabled = false;
            infoTimer.Enabled = false;
            progressBar1.Enabled = false;
            imagesToProcessLabel.Text = string.Format("Images to process: {0}", controlCenter.TotalFiles);
            totalBatchManagers.Text = string.Format("Total Batch Managers: {0}", controlCenter.BatchManagerCount);
            amountProcessedLabel.Text = string.Format("Amount Processed: {0}", controlCenter.TotalProcessed);
        }
        private void controlCenter_Done(object sender, EventArgs e)
        {
            this.Invoke(new SimpleInvokeHandler(EnableControls));
        }

        private void infoTimer_Tick(object sender, EventArgs e)
        {
            imagesToProcessLabel.Text = string.Format("Images to process: {0}", controlCenter.TotalFiles);
            totalBatchManagers.Text = string.Format("Total Batch Managers: {0}", controlCenter.BatchManagerCount);
            amountProcessedLabel.Text = string.Format("Amount Processed: {0}", controlCenter.TotalProcessed);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            foreach (Control control in this.Controls)
                control.Enabled = true;
            stopButton.Enabled = false;
            infoTimer.Enabled = false;
            progressBar1.Enabled = false;
            infoTimer.Stop();
            controlCenter.Stop();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (controlCenter != null)
                controlCenter.Stop();
            infoTimer.Stop();
        }
    }
}
