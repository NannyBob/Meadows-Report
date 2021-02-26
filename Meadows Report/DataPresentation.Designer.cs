namespace Meadows_Report
{
    partial class DataPresentation
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CurrentCheckBox = new System.Windows.Forms.CheckBox();
            this.PreviousCheckBox = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CurrentAverageLabel = new System.Windows.Forms.Label();
            this.PreviousAverageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentCheckBox
            // 
            this.CurrentCheckBox.AutoSize = true;
            this.CurrentCheckBox.Location = new System.Drawing.Point(12, 84);
            this.CurrentCheckBox.Name = "CurrentCheckBox";
            this.CurrentCheckBox.Size = new System.Drawing.Size(110, 17);
            this.CurrentCheckBox.TabIndex = 0;
            this.CurrentCheckBox.Text = "Current Residents";
            this.CurrentCheckBox.UseVisualStyleBackColor = true;
            this.CurrentCheckBox.CheckedChanged += new System.EventHandler(this.CurrentCheckBox_CheckedChanged);
            // 
            // PreviousCheckBox
            // 
            this.PreviousCheckBox.AutoSize = true;
            this.PreviousCheckBox.Location = new System.Drawing.Point(12, 61);
            this.PreviousCheckBox.Name = "PreviousCheckBox";
            this.PreviousCheckBox.Size = new System.Drawing.Size(117, 17);
            this.PreviousCheckBox.TabIndex = 1;
            this.PreviousCheckBox.Text = "Previous Residents";
            this.PreviousCheckBox.UseVisualStyleBackColor = true;
            this.PreviousCheckBox.CheckedChanged += new System.EventHandler(this.PreviousCheckBox_CheckedChanged);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(12, 107);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series3.Legend = "Legend1";
            series3.Name = "Current";
            series3.YValuesPerPoint = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series4.Legend = "Legend1";
            series4.Name = "Previous";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(1312, 454);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // CurrentAverageLabel
            // 
            this.CurrentAverageLabel.AutoSize = true;
            this.CurrentAverageLabel.Location = new System.Drawing.Point(202, 88);
            this.CurrentAverageLabel.Name = "CurrentAverageLabel";
            this.CurrentAverageLabel.Size = new System.Drawing.Size(177, 13);
            this.CurrentAverageLabel.TabIndex = 3;
            this.CurrentAverageLabel.Text = "Average Stay for Current residents =";
            this.CurrentAverageLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PreviousAverageLabel
            // 
            this.PreviousAverageLabel.AutoSize = true;
            this.PreviousAverageLabel.Location = new System.Drawing.Point(459, 88);
            this.PreviousAverageLabel.Name = "PreviousAverageLabel";
            this.PreviousAverageLabel.Size = new System.Drawing.Size(175, 13);
            this.PreviousAverageLabel.TabIndex = 4;
            this.PreviousAverageLabel.Text = "Average Stay for Previous residents";
            // 
            // DataPresentation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1390, 788);
            this.Controls.Add(this.PreviousAverageLabel);
            this.Controls.Add(this.CurrentAverageLabel);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.PreviousCheckBox);
            this.Controls.Add(this.CurrentCheckBox);
            this.Name = "DataPresentation";
            this.Text = "DataPresentation";
            this.Load += new System.EventHandler(this.DataPresentation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CurrentCheckBox;
        private System.Windows.Forms.CheckBox PreviousCheckBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label CurrentAverageLabel;
        private System.Windows.Forms.Label PreviousAverageLabel;
    }
}