namespace FTreeViewer
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
            this.Timer_Ticker = new System.Windows.Forms.Timer(this.components);
            this.btnNewLayout = new System.Windows.Forms.Button();
            this.btnSaveLayout = new System.Windows.Forms.Button();
            this.lblIdSelected = new System.Windows.Forms.Label();
            this.nUD_Id = new System.Windows.Forms.NumericUpDown();
            this.btnIdReset = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnLoadLayout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Id)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer_Ticker
            // 
            this.Timer_Ticker.Tick += new System.EventHandler(this.Timer_Ticker_Tick);
            // 
            // btnNewLayout
            // 
            this.btnNewLayout.Location = new System.Drawing.Point(12, 35);
            this.btnNewLayout.Name = "btnNewLayout";
            this.btnNewLayout.Size = new System.Drawing.Size(75, 23);
            this.btnNewLayout.TabIndex = 0;
            this.btnNewLayout.Text = "New layout";
            this.btnNewLayout.UseVisualStyleBackColor = true;
            this.btnNewLayout.Click += new System.EventHandler(this.btnNewLayout_Click);
            // 
            // btnSaveLayout
            // 
            this.btnSaveLayout.Location = new System.Drawing.Point(12, 64);
            this.btnSaveLayout.Name = "btnSaveLayout";
            this.btnSaveLayout.Size = new System.Drawing.Size(75, 23);
            this.btnSaveLayout.TabIndex = 1;
            this.btnSaveLayout.Text = "Save layout";
            this.btnSaveLayout.UseVisualStyleBackColor = true;
            this.btnSaveLayout.Click += new System.EventHandler(this.btnSaveLayout_Click);
            // 
            // lblIdSelected
            // 
            this.lblIdSelected.AutoSize = true;
            this.lblIdSelected.Location = new System.Drawing.Point(9, 131);
            this.lblIdSelected.Name = "lblIdSelected";
            this.lblIdSelected.Size = new System.Drawing.Size(10, 13);
            this.lblIdSelected.TabIndex = 3;
            this.lblIdSelected.Text = "-";
            // 
            // nUD_Id
            // 
            this.nUD_Id.Location = new System.Drawing.Point(12, 147);
            this.nUD_Id.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nUD_Id.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nUD_Id.Name = "nUD_Id";
            this.nUD_Id.Size = new System.Drawing.Size(35, 20);
            this.nUD_Id.TabIndex = 4;
            this.nUD_Id.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nUD_Id.ValueChanged += new System.EventHandler(this.nUD_Id_ValueChanged);
            // 
            // btnIdReset
            // 
            this.btnIdReset.Location = new System.Drawing.Point(50, 145);
            this.btnIdReset.Name = "btnIdReset";
            this.btnIdReset.Size = new System.Drawing.Size(16, 23);
            this.btnIdReset.TabIndex = 5;
            this.btnIdReset.Text = "R";
            this.btnIdReset.UseVisualStyleBackColor = true;
            this.btnIdReset.Click += new System.EventHandler(this.btnIdReset_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnLoadLayout
            // 
            this.btnLoadLayout.Location = new System.Drawing.Point(12, 93);
            this.btnLoadLayout.Name = "btnLoadLayout";
            this.btnLoadLayout.Size = new System.Drawing.Size(75, 23);
            this.btnLoadLayout.TabIndex = 2;
            this.btnLoadLayout.Text = "Load layout";
            this.btnLoadLayout.UseVisualStyleBackColor = true;
            this.btnLoadLayout.Click += new System.EventHandler(this.btnLoadLayout_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadLayout);
            this.Controls.Add(this.btnIdReset);
            this.Controls.Add(this.nUD_Id);
            this.Controls.Add(this.lblIdSelected);
            this.Controls.Add(this.btnSaveLayout);
            this.Controls.Add(this.btnNewLayout);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Id)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer_Ticker;
        private System.Windows.Forms.Button btnNewLayout;
        private System.Windows.Forms.Button btnSaveLayout;
        private System.Windows.Forms.Label lblIdSelected;
        private System.Windows.Forms.NumericUpDown nUD_Id;
        private System.Windows.Forms.Button btnIdReset;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnLoadLayout;
    }
}

