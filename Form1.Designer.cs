namespace WeightingMachine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lc1 = new UI.Controls.LoadingCircle();
            this.led1 = new UI.LxLedControl();
            this.ledStationID = new UI.LxLedControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSecondWeight = new System.Windows.Forms.TextBox();
            this.txtFirstWeight = new System.Windows.Forms.TextBox();
            this.txtVehicleNO = new System.Windows.Forms.TextBox();
            this.timer4ComMonitor = new System.Windows.Forms.Timer(this.components);
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this._txtMsg = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.barTruck = new System.Windows.Forms.ToolStrip();
            this.btnSearchTruck = new System.Windows.Forms.ToolStripButton();
            this.btnInTruck = new System.Windows.Forms.ToolStripButton();
            this.btnOutTruck = new System.Windows.Forms.ToolStripButton();
            this.btnWeightTruck = new System.Windows.Forms.ToolStripButton();
            this.btnPrintTruck = new System.Windows.Forms.ToolStripButton();
            this.btnBackTruck = new System.Windows.Forms.ToolStripButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.led1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledStationID)).BeginInit();
            this.panel1.SuspendLayout();
            this.barTruck.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lc1);
            this.panel2.Controls.Add(this.led1);
            this.panel2.Controls.Add(this.ledStationID);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(903, 86);
            this.panel2.TabIndex = 43;
            // 
            // lc1
            // 
            this.lc1.Active = true;
            this.lc1.Color = System.Drawing.Color.Red;
            this.lc1.InnerCircleRadius = 8;
            this.lc1.Location = new System.Drawing.Point(340, 3);
            this.lc1.Name = "lc1";
            this.lc1.NumberSpoke = 24;
            this.lc1.OuterCircleRadius = 9;
            this.lc1.RotationSpeed = 100;
            this.lc1.Size = new System.Drawing.Size(70, 72);
            this.lc1.SpokeThickness = 4;
            this.lc1.StylePreset = UI.Controls.LoadingCircle.StylePresets.IE7;
            this.lc1.TabIndex = 44;
            this.lc1.Text = "lcFirst";
            // 
            // led1
            // 
            this.led1.BackColor = System.Drawing.Color.Transparent;
            this.led1.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.led1.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.led1.BevelRate = 0.5F;
            this.led1.BorderColor = System.Drawing.Color.Transparent;
            this.led1.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(170)))), ((int)(((byte)(200)))));
            this.led1.ForeColor = System.Drawing.Color.Yellow;
            this.led1.HighlightOpaque = ((byte)(50));
            this.led1.Location = new System.Drawing.Point(0, 0);
            this.led1.Name = "led1";
            this.led1.Size = new System.Drawing.Size(308, 75);
            this.led1.TabIndex = 41;
            this.led1.Text = "     0.0";
            this.led1.TotalCharCount = 8;
            // 
            // ledStationID
            // 
            this.ledStationID.BackColor = System.Drawing.Color.Transparent;
            this.ledStationID.BackColor_1 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID.BackColor_2 = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID.BevelRate = 0.5F;
            this.ledStationID.BorderColor = System.Drawing.Color.Transparent;
            this.ledStationID.FadedColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ledStationID.ForeColor = System.Drawing.Color.White;
            this.ledStationID.HighlightOpaque = ((byte)(50));
            this.ledStationID.Location = new System.Drawing.Point(751, 0);
            this.ledStationID.Name = "ledStationID";
            this.ledStationID.Size = new System.Drawing.Size(152, 75);
            this.ledStationID.TabIndex = 40;
            this.ledStationID.Text = "201";
            this.ledStationID.TotalCharCount = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label3.Location = new System.Drawing.Point(51, 295);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 27);
            this.label3.TabIndex = 35;
            this.label3.Text = "Lần cân 2:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label2.Location = new System.Drawing.Point(51, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 27);
            this.label2.TabIndex = 36;
            this.label2.Text = "Lần cân 1:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.label1.Location = new System.Drawing.Point(51, 177);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 38);
            this.label1.TabIndex = 37;
            this.label1.Text = "Số xe:";
            // 
            // txtSecondWeight
            // 
            this.txtSecondWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.txtSecondWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSecondWeight.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtSecondWeight.Location = new System.Drawing.Point(193, 292);
            this.txtSecondWeight.MinimumSize = new System.Drawing.Size(292, 30);
            this.txtSecondWeight.Name = "txtSecondWeight";
            this.txtSecondWeight.Size = new System.Drawing.Size(713, 30);
            this.txtSecondWeight.TabIndex = 31;
            // 
            // txtFirstWeight
            // 
            this.txtFirstWeight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.txtFirstWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFirstWeight.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtFirstWeight.Location = new System.Drawing.Point(193, 237);
            this.txtFirstWeight.MinimumSize = new System.Drawing.Size(292, 30);
            this.txtFirstWeight.Name = "txtFirstWeight";
            this.txtFirstWeight.Size = new System.Drawing.Size(713, 30);
            this.txtFirstWeight.TabIndex = 30;
            // 
            // txtVehicleNO
            // 
            this.txtVehicleNO.Font = new System.Drawing.Font("Tahoma", 14F);
            this.txtVehicleNO.Location = new System.Drawing.Point(193, 177);
            this.txtVehicleNO.MinimumSize = new System.Drawing.Size(292, 30);
            this.txtVehicleNO.Name = "txtVehicleNO";
            this.txtVehicleNO.Size = new System.Drawing.Size(713, 30);
            this.txtVehicleNO.TabIndex = 29;
            this.txtVehicleNO.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleNO_KeyDown);
            // 
            // timer4ComMonitor
            // 
            this.timer4ComMonitor.Enabled = true;
            this.timer4ComMonitor.Interval = 500;
            this.timer4ComMonitor.Tick += new System.EventHandler(this.timer4ComMonitor_Tick);
            // 
            // serialPort
            // 
            this.serialPort.PortName = "COM4";
            // 
            // _txtMsg
            // 
            this._txtMsg.AutoSize = true;
            this._txtMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._txtMsg.Location = new System.Drawing.Point(0, 558);
            this._txtMsg.Name = "_txtMsg";
            this._txtMsg.Size = new System.Drawing.Size(21, 13);
            this._txtMsg.TabIndex = 32;
            this._txtMsg.Text = "*_*";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSecondWeight);
            this.panel1.Controls.Add(this.txtFirstWeight);
            this.panel1.Controls.Add(this.txtVehicleNO);
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(940, 503);
            this.panel1.TabIndex = 34;
            // 
            // barTruck
            // 
            this.barTruck.Font = new System.Drawing.Font("Microsoft YaHei", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barTruck.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSearchTruck,
            this.btnInTruck,
            this.btnOutTruck,
            this.btnWeightTruck,
            this.btnPrintTruck,
            this.btnBackTruck});
            this.barTruck.Location = new System.Drawing.Point(0, 0);
            this.barTruck.Name = "barTruck";
            this.barTruck.Size = new System.Drawing.Size(955, 53);
            this.barTruck.TabIndex = 35;
            this.barTruck.Text = "toolStrip2";
            // 
            // btnSearchTruck
            // 
            this.btnSearchTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchTruck.Image")));
            this.btnSearchTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchTruck.Name = "btnSearchTruck";
            this.btnSearchTruck.Size = new System.Drawing.Size(102, 50);
            this.btnSearchTruck.Text = "Tìm";
            // 
            // btnInTruck
            // 
            this.btnInTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnInTruck.Image")));
            this.btnInTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInTruck.Name = "btnInTruck";
            this.btnInTruck.Size = new System.Drawing.Size(152, 50);
            this.btnInTruck.Text = "Xe vào";
            // 
            // btnOutTruck
            // 
            this.btnOutTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnOutTruck.Image")));
            this.btnOutTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOutTruck.Name = "btnOutTruck";
            this.btnOutTruck.Size = new System.Drawing.Size(125, 50);
            this.btnOutTruck.Text = "Xe ra";
            // 
            // btnWeightTruck
            // 
            this.btnWeightTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnWeightTruck.Image")));
            this.btnWeightTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnWeightTruck.Name = "btnWeightTruck";
            this.btnWeightTruck.Size = new System.Drawing.Size(104, 50);
            this.btnWeightTruck.Text = "Cân";
            // 
            // btnPrintTruck
            // 
            this.btnPrintTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintTruck.Image")));
            this.btnPrintTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintTruck.Name = "btnPrintTruck";
            this.btnPrintTruck.Size = new System.Drawing.Size(72, 50);
            this.btnPrintTruck.Text = "In";
            // 
            // btnBackTruck
            // 
            this.btnBackTruck.Image = ((System.Drawing.Image)(resources.GetObject("btnBackTruck.Image")));
            this.btnBackTruck.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackTruck.Name = "btnBackTruck";
            this.btnBackTruck.Size = new System.Drawing.Size(160, 50);
            this.btnBackTruck.Text = "Làm lại";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(178)))), ((int)(((byte)(195)))));
            this.ClientSize = new System.Drawing.Size(955, 571);
            this.Controls.Add(this.barTruck);
            this.Controls.Add(this._txtMsg);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.led1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ledStationID)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.barTruck.ResumeLayout(false);
            this.barTruck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private UI.LxLedControl led1;
        private UI.LxLedControl ledStationID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSecondWeight;
        private System.Windows.Forms.TextBox txtFirstWeight;
        private System.Windows.Forms.TextBox txtVehicleNO;
        private System.Windows.Forms.Timer timer4ComMonitor;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.Label _txtMsg;
        private System.Windows.Forms.Panel panel1;
        private UI.Controls.LoadingCircle lc1;
        private System.Windows.Forms.ToolStrip barTruck;
        private System.Windows.Forms.ToolStripButton btnSearchTruck;
        private System.Windows.Forms.ToolStripButton btnInTruck;
        private System.Windows.Forms.ToolStripButton btnOutTruck;
        private System.Windows.Forms.ToolStripButton btnWeightTruck;
        private System.Windows.Forms.ToolStripButton btnPrintTruck;
        private System.Windows.Forms.ToolStripButton btnBackTruck;
    }
}

