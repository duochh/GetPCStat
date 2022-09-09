namespace GetPCStat
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.label1 = new System.Windows.Forms.Label();
            this.tb_connection_string = new System.Windows.Forms.TextBox();
            this.bt_connect_to_IoT = new System.Windows.Forms.Button();
            this.gb_pc_name = new System.Windows.Forms.GroupBox();
            this.lb_larggest_processes = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lb_gpu_usage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_gpu_name = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_memory_usage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_cpu_temperature = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_cpu_usage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_cpu_name = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_log_message = new System.Windows.Forms.ListBox();
            this.bt_import_connection_string_csv = new System.Windows.Forms.Button();
            this.bt_disconnect_to_iot = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.gb_pc_name.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String";
            // 
            // tb_connection_string
            // 
            this.tb_connection_string.Enabled = false;
            this.tb_connection_string.Location = new System.Drawing.Point(154, 17);
            this.tb_connection_string.Name = "tb_connection_string";
            this.tb_connection_string.Size = new System.Drawing.Size(601, 23);
            this.tb_connection_string.TabIndex = 1;
            // 
            // bt_connect_to_IoT
            // 
            this.bt_connect_to_IoT.Enabled = false;
            this.bt_connect_to_IoT.Location = new System.Drawing.Point(355, 50);
            this.bt_connect_to_IoT.Name = "bt_connect_to_IoT";
            this.bt_connect_to_IoT.Size = new System.Drawing.Size(190, 23);
            this.bt_connect_to_IoT.TabIndex = 2;
            this.bt_connect_to_IoT.Text = "Connect To IoT";
            this.bt_connect_to_IoT.UseVisualStyleBackColor = true;
            this.bt_connect_to_IoT.Click += new System.EventHandler(this.bt_connect_to_IoT_Click);
            // 
            // gb_pc_name
            // 
            this.gb_pc_name.Controls.Add(this.lb_larggest_processes);
            this.gb_pc_name.Controls.Add(this.label6);
            this.gb_pc_name.Controls.Add(this.lb_gpu_usage);
            this.gb_pc_name.Controls.Add(this.label4);
            this.gb_pc_name.Controls.Add(this.lb_gpu_name);
            this.gb_pc_name.Controls.Add(this.label9);
            this.gb_pc_name.Controls.Add(this.lb_memory_usage);
            this.gb_pc_name.Controls.Add(this.label7);
            this.gb_pc_name.Controls.Add(this.lb_cpu_temperature);
            this.gb_pc_name.Controls.Add(this.label5);
            this.gb_pc_name.Controls.Add(this.lb_cpu_usage);
            this.gb_pc_name.Controls.Add(this.label3);
            this.gb_pc_name.Controls.Add(this.lb_cpu_name);
            this.gb_pc_name.Controls.Add(this.label2);
            this.gb_pc_name.Location = new System.Drawing.Point(20, 79);
            this.gb_pc_name.Name = "gb_pc_name";
            this.gb_pc_name.Size = new System.Drawing.Size(735, 359);
            this.gb_pc_name.TabIndex = 3;
            this.gb_pc_name.TabStop = false;
            this.gb_pc_name.Text = "--";
            // 
            // lb_larggest_processes
            // 
            this.lb_larggest_processes.FormattingEnabled = true;
            this.lb_larggest_processes.ItemHeight = 15;
            this.lb_larggest_processes.Location = new System.Drawing.Point(134, 230);
            this.lb_larggest_processes.Name = "lb_larggest_processes";
            this.lb_larggest_processes.Size = new System.Drawing.Size(581, 109);
            this.lb_larggest_processes.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(278, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Larggest processes are using above 1GB of memory";
            // 
            // lb_gpu_usage
            // 
            this.lb_gpu_usage.AutoSize = true;
            this.lb_gpu_usage.Location = new System.Drawing.Point(134, 180);
            this.lb_gpu_usage.Name = "lb_gpu_usage";
            this.lb_gpu_usage.Size = new System.Drawing.Size(30, 15);
            this.lb_gpu_usage.TabIndex = 11;
            this.lb_gpu_usage.Text = "-- %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "GPU Usage";
            // 
            // lb_gpu_name
            // 
            this.lb_gpu_name.AutoSize = true;
            this.lb_gpu_name.Location = new System.Drawing.Point(134, 150);
            this.lb_gpu_name.Name = "lb_gpu_name";
            this.lb_gpu_name.Size = new System.Drawing.Size(17, 15);
            this.lb_gpu_name.TabIndex = 9;
            this.lb_gpu_name.Text = "--";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 150);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "GPU Name";
            // 
            // lb_memory_usage
            // 
            this.lb_memory_usage.AutoSize = true;
            this.lb_memory_usage.Location = new System.Drawing.Point(134, 120);
            this.lb_memory_usage.Name = "lb_memory_usage";
            this.lb_memory_usage.Size = new System.Drawing.Size(56, 15);
            this.lb_memory_usage.TabIndex = 7;
            this.lb_memory_usage.Text = "-- / -- GB";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Memory";
            // 
            // lb_cpu_temperature
            // 
            this.lb_cpu_temperature.AutoSize = true;
            this.lb_cpu_temperature.Location = new System.Drawing.Point(134, 90);
            this.lb_cpu_temperature.Name = "lb_cpu_temperature";
            this.lb_cpu_temperature.Size = new System.Drawing.Size(33, 15);
            this.lb_cpu_temperature.TabIndex = 5;
            this.lb_cpu_temperature.Text = "-- °C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "CPU Temperature";
            // 
            // lb_cpu_usage
            // 
            this.lb_cpu_usage.AutoSize = true;
            this.lb_cpu_usage.Location = new System.Drawing.Point(134, 60);
            this.lb_cpu_usage.Name = "lb_cpu_usage";
            this.lb_cpu_usage.Size = new System.Drawing.Size(30, 15);
            this.lb_cpu_usage.TabIndex = 3;
            this.lb_cpu_usage.Text = "-- %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "CPU Usage";
            // 
            // lb_cpu_name
            // 
            this.lb_cpu_name.AutoSize = true;
            this.lb_cpu_name.Location = new System.Drawing.Point(134, 30);
            this.lb_cpu_name.Name = "lb_cpu_name";
            this.lb_cpu_name.Size = new System.Drawing.Size(17, 15);
            this.lb_cpu_name.TabIndex = 1;
            this.lb_cpu_name.Text = "--";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "CPU Name";
            // 
            // lb_log_message
            // 
            this.lb_log_message.FormattingEnabled = true;
            this.lb_log_message.ItemHeight = 15;
            this.lb_log_message.Location = new System.Drawing.Point(20, 457);
            this.lb_log_message.Name = "lb_log_message";
            this.lb_log_message.Size = new System.Drawing.Size(735, 169);
            this.lb_log_message.TabIndex = 14;
            // 
            // bt_import_connection_string_csv
            // 
            this.bt_import_connection_string_csv.Location = new System.Drawing.Point(154, 50);
            this.bt_import_connection_string_csv.Name = "bt_import_connection_string_csv";
            this.bt_import_connection_string_csv.Size = new System.Drawing.Size(190, 23);
            this.bt_import_connection_string_csv.TabIndex = 15;
            this.bt_import_connection_string_csv.Text = "Import Connection String CSV";
            this.bt_import_connection_string_csv.UseVisualStyleBackColor = true;
            this.bt_import_connection_string_csv.Click += new System.EventHandler(this.bt_import_connection_string_csv_Click);
            // 
            // bt_disconnect_to_iot
            // 
            this.bt_disconnect_to_iot.Enabled = false;
            this.bt_disconnect_to_iot.Location = new System.Drawing.Point(555, 50);
            this.bt_disconnect_to_iot.Name = "bt_disconnect_to_iot";
            this.bt_disconnect_to_iot.Size = new System.Drawing.Size(200, 23);
            this.bt_disconnect_to_iot.TabIndex = 16;
            this.bt_disconnect_to_iot.Text = "Disconnect To IoT";
            this.bt_disconnect_to_iot.UseVisualStyleBackColor = true;
            this.bt_disconnect_to_iot.Click += new System.EventHandler(this.bt_disconnect_to_iot_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipTitle = "GetPCStat";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "GetPCStat";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(773, 642);
            this.Controls.Add(this.bt_disconnect_to_iot);
            this.Controls.Add(this.bt_import_connection_string_csv);
            this.Controls.Add(this.lb_log_message);
            this.Controls.Add(this.gb_pc_name);
            this.Controls.Add(this.bt_connect_to_IoT);
            this.Controls.Add(this.tb_connection_string);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GetPCStats";
            this.gb_pc_name.ResumeLayout(false);
            this.gb_pc_name.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_connection_string;
        private System.Windows.Forms.Button bt_connect_to_IoT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_cpu_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_larggest_processes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lb_gpu_usage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_gpu_name;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_memory_usage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_cpu_temperature;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_cpu_usage;
        private System.Windows.Forms.GroupBox gb_pc_name;
        private System.Windows.Forms.ListBox lb_log_message;
        private System.Windows.Forms.Button bt_import_connection_string_csv;
        private System.Windows.Forms.Button bt_disconnect_to_iot;
        private System.Windows.Forms.NotifyIcon notifyIcon;
    }
}