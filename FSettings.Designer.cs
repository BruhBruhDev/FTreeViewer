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
            this.cBx_dontAskAgainSaveIncompatible = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cBx_arrowShowsGender
            // 
            this.cBx_arrowShowsGender.AutoSize = true;
            this.cBx_arrowShowsGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBx_arrowShowsGender.Location = new System.Drawing.Point(6, 41);
            this.cBx_arrowShowsGender.Name = "cBx_arrowShowsGender";
            this.cBx_arrowShowsGender.Size = new System.Drawing.Size(254, 24);
            this.cBx_arrowShowsGender.TabIndex = 0;
            this.cBx_arrowShowsGender.Text = "Arrows color is based on gender";
            this.cBx_arrowShowsGender.UseVisualStyleBackColor = true;
            this.cBx_arrowShowsGender.CheckedChanged += new System.EventHandler(this.cBx_arrowShowsGender_CheckedChanged);
            // 
            // cBx_dontAskAgainSaveIncompatible
            // 
            this.cBx_dontAskAgainSaveIncompatible.AutoSize = true;
            this.cBx_dontAskAgainSaveIncompatible.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBx_dontAskAgainSaveIncompatible.Location = new System.Drawing.Point(6, 39);
            this.cBx_dontAskAgainSaveIncompatible.Name = "cBx_dontAskAgainSaveIncompatible";
            this.cBx_dontAskAgainSaveIncompatible.Size = new System.Drawing.Size(339, 24);
            this.cBx_dontAskAgainSaveIncompatible.TabIndex = 1;
            this.cBx_dontAskAgainSaveIncompatible.Text = "Don\'t ask again if .csv format is incompatible";
            this.cBx_dontAskAgainSaveIncompatible.UseVisualStyleBackColor = true;
            this.cBx_dontAskAgainSaveIncompatible.CheckedChanged += new System.EventHandler(this.cBx_dontAskAgainSaveIncompatible_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cBx_arrowShowsGender);
            this.groupBox1.Location = new System.Drawing.Point(64, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 98);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Visuals";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cBx_dontAskAgainSaveIncompatible);
            this.groupBox2.Location = new System.Drawing.Point(64, 261);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Misc";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 416);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cBx_arrowShowsGender;
        private System.Windows.Forms.CheckBox cBx_dontAskAgainSaveIncompatible;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}