namespace EyeDiagramWithGraph
{
    partial class GraphBackplaneResultsForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.eyeDiagram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphEyeDiagram = new System.Windows.Forms.Button();
            this.GraphTimeSeries = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numberLevelsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.eyeDiagram)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberLevelsNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // eyeDiagram
            // 
            chartArea3.Name = "ChartArea1";
            this.eyeDiagram.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.Name = "Legend1";
            this.eyeDiagram.Legends.Add(legend3);
            this.eyeDiagram.Location = new System.Drawing.Point(12, 84);
            this.eyeDiagram.Name = "eyeDiagram";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "EyeDiagramData";
            this.eyeDiagram.Series.Add(series3);
            this.eyeDiagram.Size = new System.Drawing.Size(1108, 494);
            this.eyeDiagram.TabIndex = 0;
            this.eyeDiagram.Text = "eyeDiagram";
            this.eyeDiagram.Click += new System.EventHandler(this.chart1_Click);
            // 
            // graphEyeDiagram
            // 
            this.graphEyeDiagram.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.graphEyeDiagram.Location = new System.Drawing.Point(625, 599);
            this.graphEyeDiagram.Name = "graphEyeDiagram";
            this.graphEyeDiagram.Size = new System.Drawing.Size(230, 62);
            this.graphEyeDiagram.TabIndex = 1;
            this.graphEyeDiagram.Text = "Graph Eye Diagram";
            this.graphEyeDiagram.UseVisualStyleBackColor = true;
            this.graphEyeDiagram.Click += new System.EventHandler(this.graphEyeDiagram_Click);
            // 
            // GraphTimeSeries
            // 
            this.GraphTimeSeries.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GraphTimeSeries.Location = new System.Drawing.Point(890, 599);
            this.GraphTimeSeries.Name = "GraphTimeSeries";
            this.GraphTimeSeries.Size = new System.Drawing.Size(230, 62);
            this.GraphTimeSeries.TabIndex = 2;
            this.GraphTimeSeries.Text = "Graph Time Series";
            this.GraphTimeSeries.UseVisualStyleBackColor = true;
            this.GraphTimeSeries.Click += new System.EventHandler(this.GraphTimeSeries_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(74, 619);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number of levels (PAM-xx)";
            // 
            // numberLevelsNumeric
            // 
            this.numberLevelsNumeric.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLevelsNumeric.Location = new System.Drawing.Point(306, 615);
            this.numberLevelsNumeric.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numberLevelsNumeric.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numberLevelsNumeric.Name = "numberLevelsNumeric";
            this.numberLevelsNumeric.Size = new System.Drawing.Size(58, 27);
            this.numberLevelsNumeric.TabIndex = 5;
            this.numberLevelsNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(103, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(903, 72);
            this.label3.TabIndex = 8;
            this.label3.Text = "This simulation suggests that a backplane that performs OK at 2 Ghz PAM2 is not a" +
    "dequate for 2 Ghz PAM4";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(36, 694);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1084, 23);
            this.progressBar1.TabIndex = 9;
            // 
            // GraphBackplaneResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 769);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberLevelsNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GraphTimeSeries);
            this.Controls.Add(this.graphEyeDiagram);
            this.Controls.Add(this.eyeDiagram);
            this.Name = "GraphBackplaneResultsForm";
            this.Text = "GraphBackplaneResults";
            ((System.ComponentModel.ISupportInitialize)(this.eyeDiagram)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberLevelsNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart eyeDiagram;
        private System.Windows.Forms.Button graphEyeDiagram;
        private System.Windows.Forms.Button GraphTimeSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberLevelsNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

