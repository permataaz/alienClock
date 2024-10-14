namespace AlienClockApp
{
    partial class AlienClockForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelCustomTime;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelCustomTime = new System.Windows.Forms.Label();
            this.alienLabel = new System.Windows.Forms.Label();
            this.setTimebtn = new System.Windows.Forms.Button();
            this.earthlbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCustomTime
            // 
            this.labelCustomTime.AutoSize = true;
            this.labelCustomTime.BackColor = System.Drawing.SystemColors.MenuText;
            this.labelCustomTime.Font = new System.Drawing.Font("NSimSun", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomTime.ForeColor = System.Drawing.Color.ForestGreen;
            this.labelCustomTime.Location = new System.Drawing.Point(162, 77);
            this.labelCustomTime.Name = "labelCustomTime";
            this.labelCustomTime.Size = new System.Drawing.Size(485, 80);
            this.labelCustomTime.TabIndex = 0;
            this.labelCustomTime.Text = "Custom Time";
            // 
            // alienLabel
            // 
            this.alienLabel.AutoSize = true;
            this.alienLabel.Font = new System.Drawing.Font("NSimSun", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alienLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.alienLabel.Location = new System.Drawing.Point(267, 19);
            this.alienLabel.Name = "alienLabel";
            this.alienLabel.Size = new System.Drawing.Size(272, 43);
            this.alienLabel.TabIndex = 1;
            this.alienLabel.Text = "Alien Clock";
            // 
            // setTimebtn
            // 
            this.setTimebtn.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.setTimebtn.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setTimebtn.ForeColor = System.Drawing.Color.DarkGreen;
            this.setTimebtn.Location = new System.Drawing.Point(298, 370);
            this.setTimebtn.Name = "setTimebtn";
            this.setTimebtn.Size = new System.Drawing.Size(191, 38);
            this.setTimebtn.TabIndex = 2;
            this.setTimebtn.Text = "Set Alien Time";
            this.setTimebtn.UseVisualStyleBackColor = false;
            this.setTimebtn.Click += new System.EventHandler(this.setTimebtn_Click);
            // 
            // earthlbl
            // 
            this.earthlbl.AutoSize = true;
            this.earthlbl.Font = new System.Drawing.Font("NSimSun", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.earthlbl.ForeColor = System.Drawing.Color.Blue;
            this.earthlbl.Location = new System.Drawing.Point(315, 300);
            this.earthlbl.Name = "earthlbl";
            this.earthlbl.Size = new System.Drawing.Size(140, 23);
            this.earthlbl.TabIndex = 3;
            this.earthlbl.Text = "Earth Time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("NSimSun", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(256, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Earth Time (GMT +8)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.earthlbl);
            this.Controls.Add(this.setTimebtn);
            this.Controls.Add(this.alienLabel);
            this.Controls.Add(this.labelCustomTime);
            this.Name = "AlienClockForm";
            this.Text = "Alien Clock";
            this.Load += new System.EventHandler(this.AlienClockForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label alienLabel;
        private System.Windows.Forms.Button setTimebtn;
        private System.Windows.Forms.Label earthlbl;
        private System.Windows.Forms.Label label1;
    }
}
