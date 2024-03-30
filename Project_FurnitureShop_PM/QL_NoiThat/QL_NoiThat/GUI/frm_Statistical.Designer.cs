namespace QL_NoiThat.GUI
{
	partial class frm_Statistical
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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			this.label1 = new System.Windows.Forms.Label();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.btn_max = new System.Windows.Forms.Button();
			this.btn_min = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.btn_ds = new System.Windows.Forms.Button();
			this.btn_dsQuy = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(367, 9);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(103, 27);
			this.label1.TabIndex = 4;
			this.label1.Text = "Thống kê";
			// 
			// chart1
			// 
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			legend1.Name = "Legend1";
			this.chart1.Legends.Add(legend1);
			this.chart1.Location = new System.Drawing.Point(23, 56);
			this.chart1.Name = "chart1";
			series1.ChartArea = "ChartArea1";
			series1.Legend = "Legend1";
			series1.Name = "Series1";
			this.chart1.Series.Add(series1);
			this.chart1.Size = new System.Drawing.Size(999, 520);
			this.chart1.TabIndex = 5;
			this.chart1.Text = "chart1";
			this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseClick);
			this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
			// 
			// btn_max
			// 
			this.btn_max.Location = new System.Drawing.Point(1060, 430);
			this.btn_max.Name = "btn_max";
			this.btn_max.Size = new System.Drawing.Size(121, 36);
			this.btn_max.TabIndex = 6;
			this.btn_max.Text = "Tìm từ trên xuống";
			this.btn_max.UseVisualStyleBackColor = true;
			this.btn_max.Click += new System.EventHandler(this.btn_max_Click);
			// 
			// btn_min
			// 
			this.btn_min.Location = new System.Drawing.Point(1202, 430);
			this.btn_min.Name = "btn_min";
			this.btn_min.Size = new System.Drawing.Size(103, 36);
			this.btn_min.TabIndex = 7;
			this.btn_min.Text = "Tìm từ dưới lên";
			this.btn_min.UseVisualStyleBackColor = true;
			this.btn_min.Click += new System.EventHandler(this.btn_min_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(1202, 487);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(113, 36);
			this.button1.TabIndex = 8;
			this.button1.Text = "Sản phẩm bán chạy";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(1054, 56);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(241, 315);
			this.dataGridView1.TabIndex = 9;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(1060, 383);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
			this.dateTimePicker1.TabIndex = 10;
			// 
			// btn_ds
			// 
			this.btn_ds.Location = new System.Drawing.Point(1060, 487);
			this.btn_ds.Name = "btn_ds";
			this.btn_ds.Size = new System.Drawing.Size(113, 36);
			this.btn_ds.TabIndex = 11;
			this.btn_ds.Text = "Doanh số theo tháng";
			this.btn_ds.UseVisualStyleBackColor = true;
			this.btn_ds.Click += new System.EventHandler(this.btn_ds_Click);
			// 
			// btn_dsQuy
			// 
			this.btn_dsQuy.Location = new System.Drawing.Point(1060, 540);
			this.btn_dsQuy.Name = "btn_dsQuy";
			this.btn_dsQuy.Size = new System.Drawing.Size(113, 36);
			this.btn_dsQuy.TabIndex = 12;
			this.btn_dsQuy.Text = "Doanh số theo quý";
			this.btn_dsQuy.UseVisualStyleBackColor = true;
			this.btn_dsQuy.Click += new System.EventHandler(this.btn_dsQuy_Click);
			// 
			// frm_Statistical
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1374, 690);
			this.Controls.Add(this.btn_dsQuy);
			this.Controls.Add(this.btn_ds);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.btn_min);
			this.Controls.Add(this.btn_max);
			this.Controls.Add(this.chart1);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frm_Statistical";
			this.Text = "frm_Statistical";
			this.Load += new System.EventHandler(this.frm_Statistical_Load);
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button btn_max;
		private System.Windows.Forms.Button btn_min;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Button btn_ds;
		private System.Windows.Forms.Button btn_dsQuy;
	}
}