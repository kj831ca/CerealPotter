namespace CerealPotter
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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.comboBoxAvailableSerial = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStartPlot = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(262, 38);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(699, 362);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // comboBoxAvailableSerial
            // 
            this.comboBoxAvailableSerial.FormattingEnabled = true;
            this.comboBoxAvailableSerial.Location = new System.Drawing.Point(24, 54);
            this.comboBoxAvailableSerial.Name = "comboBoxAvailableSerial";
            this.comboBoxAvailableSerial.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAvailableSerial.TabIndex = 1;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(24, 94);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(121, 40);
            this.buttonConnect.TabIndex = 2;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.Location = new System.Drawing.Point(83, 464);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.Size = new System.Drawing.Size(878, 57);
            this.textBoxReceive.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 446);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Read";
            // 
            // buttonStartPlot
            // 
            this.buttonStartPlot.Location = new System.Drawing.Point(24, 156);
            this.buttonStartPlot.Name = "buttonStartPlot";
            this.buttonStartPlot.Size = new System.Drawing.Size(121, 43);
            this.buttonStartPlot.TabIndex = 5;
            this.buttonStartPlot.Text = "Start Plot";
            this.buttonStartPlot.UseVisualStyleBackColor = true;
            this.buttonStartPlot.Click += new System.EventHandler(this.buttonStartPlot_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 533);
            this.Controls.Add(this.buttonStartPlot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxReceive);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxAvailableSerial);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Cereal Potter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ComboBox comboBoxAvailableSerial;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textBoxReceive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStartPlot;
    }
}

