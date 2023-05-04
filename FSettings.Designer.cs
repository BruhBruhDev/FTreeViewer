namespace FTreeViewer
{
    partial class Settings
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
            this.cBx_arrowShowsGender = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cBx_arrowShowsGender
            // 
            this.cBx_arrowShowsGender.AutoSize = true;
            this.cBx_arrowShowsGender.Location = new System.Drawing.Point(64, 66);
            this.cBx_arrowShowsGender.Name = "cBx_arrowShowsGender";
            this.cBx_arrowShowsGender.Size = new System.Drawing.Size(177, 17);
            this.cBx_arrowShowsGender.TabIndex = 0;
            this.cBx_arrowShowsGender.Text = "Arrows color is based on gender";
            this.cBx_arrowShowsGender.UseVisualStyleBackColor = true;
            this.cBx_arrowShowsGender.CheckedChanged += new System.EventHandler(this.cBx_arrowShowsGender_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cBx_arrowShowsGender);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cBx_arrowShowsGender;
    }
}