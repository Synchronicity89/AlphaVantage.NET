namespace WinFormExus
{
    partial class Exus
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
            this.btnFetchData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFetchData
            // 
            this.btnFetchData.Location = new System.Drawing.Point(60, 22);
            this.btnFetchData.Name = "btnFetchData";
            this.btnFetchData.Size = new System.Drawing.Size(75, 23);
            this.btnFetchData.TabIndex = 0;
            this.btnFetchData.Text = "Fetch Data";
            this.btnFetchData.UseVisualStyleBackColor = true;
            this.btnFetchData.Click += new System.EventHandler(this.btnFetchData_Click);
            // 
            // Exus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFetchData);
            this.Name = "Exus";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Exus_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFetchData;
    }
}

