namespace FTreeViewer
{
    partial class FConfirmSaveFile
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
            this.btnNo = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.cBx_DontAsk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(52, 136);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 0;
            this.btnNo.Text = "Back";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(259, 136);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(78, 23);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Confirm";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // lblText
            // 
            this.lblText.AutoEllipsis = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.Location = new System.Drawing.Point(12, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(369, 124);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "a";
            this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBx_DontAsk
            // 
            this.cBx_DontAsk.AutoSize = true;
            this.cBx_DontAsk.Location = new System.Drawing.Point(144, 165);
            this.cBx_DontAsk.Name = "cBx_DontAsk";
            this.cBx_DontAsk.Size = new System.Drawing.Size(98, 17);
            this.cBx_DontAsk.TabIndex = 3;
            this.cBx_DontAsk.Text = "don\'t ask again";
            this.cBx_DontAsk.UseVisualStyleBackColor = true;
            this.cBx_DontAsk.CheckedChanged += new System.EventHandler(this.cBx_DontAsk_CheckedChanged);
            // 
            // FConfirmSaveFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 184);
            this.Controls.Add(this.cBx_DontAsk);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FConfirmSaveFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FConfirm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.CheckBox cBx_DontAsk;
    }
}