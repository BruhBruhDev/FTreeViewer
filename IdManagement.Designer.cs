namespace FTreeViewer
{
    partial class IdManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.listBx = new System.Windows.Forms.CheckedListBox();
            this.btnRessurect = new System.Windows.Forms.Button();
            this.rB_ressurect = new System.Windows.Forms.RadioButton();
            this.rB_shift = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnShiftUp = new System.Windows.Forms.Button();
            this.btnUnselect = new System.Windows.Forms.Button();
            this.btnShiftDown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(158, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode selection";
            // 
            // listBx
            // 
            this.listBx.CheckOnClick = true;
            this.listBx.FormattingEnabled = true;
            this.listBx.Items.AddRange(new object[] {
            "< 0 - 3 >",
            "4",
            "< 5 - 6 >",
            "7",
            "8",
            "9",
            "10",
            "11",
            "< 12 - 34 >"});
            this.listBx.Location = new System.Drawing.Point(147, 93);
            this.listBx.Name = "listBx";
            this.listBx.ScrollAlwaysVisible = true;
            this.listBx.Size = new System.Drawing.Size(140, 274);
            this.listBx.TabIndex = 2;
            // 
            // btnRessurect
            // 
            this.btnRessurect.Location = new System.Drawing.Point(12, 332);
            this.btnRessurect.Name = "btnRessurect";
            this.btnRessurect.Size = new System.Drawing.Size(78, 23);
            this.btnRessurect.TabIndex = 3;
            this.btnRessurect.Text = "Ressurect";
            this.btnRessurect.UseVisualStyleBackColor = true;
            this.btnRessurect.Click += new System.EventHandler(this.btnRessurect_Click);
            // 
            // rB_ressurect
            // 
            this.rB_ressurect.AutoSize = true;
            this.rB_ressurect.Location = new System.Drawing.Point(35, 73);
            this.rB_ressurect.Name = "rB_ressurect";
            this.rB_ressurect.Size = new System.Drawing.Size(73, 17);
            this.rB_ressurect.TabIndex = 7;
            this.rB_ressurect.TabStop = true;
            this.rB_ressurect.Text = "Ressurect";
            this.rB_ressurect.UseVisualStyleBackColor = true;
            this.rB_ressurect.Click += new System.EventHandler(this.rB_ressurect_Click);
            // 
            // rB_shift
            // 
            this.rB_shift.AutoSize = true;
            this.rB_shift.Location = new System.Drawing.Point(332, 73);
            this.rB_shift.Name = "rB_shift";
            this.rB_shift.Size = new System.Drawing.Size(46, 17);
            this.rB_shift.TabIndex = 8;
            this.rB_shift.TabStop = true;
            this.rB_shift.Text = "Shift";
            this.rB_shift.UseVisualStyleBackColor = true;
            this.rB_shift.Click += new System.EventHandler(this.rB_shift_Click);
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(426, 31);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "It is recommended to do a backup save. Undoing changes may be a hussle.\r\nChanges " +
    "are applied immediatly.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnShiftUp
            // 
            this.btnShiftUp.Location = new System.Drawing.Point(314, 204);
            this.btnShiftUp.Name = "btnShiftUp";
            this.btnShiftUp.Size = new System.Drawing.Size(75, 23);
            this.btnShiftUp.TabIndex = 11;
            this.btnShiftUp.Text = "Shift up";
            this.btnShiftUp.UseVisualStyleBackColor = true;
            this.btnShiftUp.Click += new System.EventHandler(this.btnShiftUp_Click);
            // 
            // btnUnselect
            // 
            this.btnUnselect.Location = new System.Drawing.Point(178, 67);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(75, 23);
            this.btnUnselect.TabIndex = 12;
            this.btnUnselect.Text = "Unselect all";
            this.btnUnselect.UseVisualStyleBackColor = true;
            this.btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // btnShiftDown
            // 
            this.btnShiftDown.Location = new System.Drawing.Point(314, 233);
            this.btnShiftDown.Name = "btnShiftDown";
            this.btnShiftDown.Size = new System.Drawing.Size(75, 23);
            this.btnShiftDown.TabIndex = 13;
            this.btnShiftDown.Text = "shift down";
            this.btnShiftDown.UseVisualStyleBackColor = true;
            this.btnShiftDown.Click += new System.EventHandler(this.btnShiftDown_Click);
            // 
            // IdManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 367);
            this.Controls.Add(this.btnShiftDown);
            this.Controls.Add(this.btnUnselect);
            this.Controls.Add(this.btnShiftUp);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rB_shift);
            this.Controls.Add(this.rB_ressurect);
            this.Controls.Add(this.btnRessurect);
            this.Controls.Add(this.listBx);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "IdManagement";
            this.Text = "IdManagement";
            this.Load += new System.EventHandler(this.IdManagement_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox listBx;
        private System.Windows.Forms.Button btnRessurect;
        private System.Windows.Forms.RadioButton rB_ressurect;
        private System.Windows.Forms.RadioButton rB_shift;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnShiftUp;
        private System.Windows.Forms.Button btnUnselect;
        private System.Windows.Forms.Button btnShiftDown;
    }
}