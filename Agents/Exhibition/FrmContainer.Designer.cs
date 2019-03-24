namespace Exhibition
{
    partial class FrmContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContainer));
            this.button2 = new System.Windows.Forms.Button();
            this.axOfficeViewer1 = new AxOfficeViewer.AxOfficeViewer();
            ((System.ComponentModel.ISupportInitialize)(this.axOfficeViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(737, 360);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // axOfficeViewer1
            // 
            this.axOfficeViewer1.Enabled = true;
            this.axOfficeViewer1.Location = new System.Drawing.Point(-5, 25);
            this.axOfficeViewer1.Name = "axOfficeViewer1";
            this.axOfficeViewer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axOfficeViewer1.OcxState")));
            this.axOfficeViewer1.Size = new System.Drawing.Size(578, 400);
            this.axOfficeViewer1.TabIndex = 0;
            // 
            // FrmContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1035, 649);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.axOfficeViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmContainer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axOfficeViewer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Button button1;
        private AxOfficeViewer.AxOfficeViewer axOfficeViewer1;
        private System.Windows.Forms.Button button2;
    }
}

