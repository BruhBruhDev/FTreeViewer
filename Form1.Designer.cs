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
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fatherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.motherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewPerson = new System.Windows.Forms.Button();
            this.nUD_NLStartNode = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnJump = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnIdManagement = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Id)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_NLStartNode)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer_Ticker
            // 
            this.Timer_Ticker.Interval = 1000;
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
            this.btnSaveLayout.TabIndex = 2;
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
            this.btnLoadLayout.TabIndex = 3;
            this.btnLoadLayout.Text = "Load layout";
            this.btnLoadLayout.UseVisualStyleBackColor = true;
            this.btnLoadLayout.Click += new System.EventHandler(this.btnLoadLayout_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fatherToolStripMenuItem,
            this.motherToolStripMenuItem,
            this.fullNameToolStripMenuItem,
            this.nameToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 120);
            this.contextMenuStrip1.Text = "Object X blabla";
            this.contextMenuStrip1.Closing += new System.Windows.Forms.ToolStripDropDownClosingEventHandler(this.contextMenuStrip1_Closing);
            // 
            // fatherToolStripMenuItem
            // 
            this.fatherToolStripMenuItem.Name = "fatherToolStripMenuItem";
            this.fatherToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.fatherToolStripMenuItem.Text = "Father";
            this.fatherToolStripMenuItem.Click += new System.EventHandler(this.fatherToolStripMenuItem_Click);
            // 
            // motherToolStripMenuItem
            // 
            this.motherToolStripMenuItem.Name = "motherToolStripMenuItem";
            this.motherToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.motherToolStripMenuItem.Text = "Mother";
            this.motherToolStripMenuItem.Click += new System.EventHandler(this.motherToolStripMenuItem_Click);
            // 
            // fullNameToolStripMenuItem
            // 
            this.fullNameToolStripMenuItem.Name = "fullNameToolStripMenuItem";
            this.fullNameToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.fullNameToolStripMenuItem.Text = "Full name";
            this.fullNameToolStripMenuItem.Click += new System.EventHandler(this.fullNameToolStripMenuItem_Click);
            // 
            // nameToolStripMenuItem
            // 
            this.nameToolStripMenuItem.Name = "nameToolStripMenuItem";
            this.nameToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.nameToolStripMenuItem.Text = "Name";
            this.nameToolStripMenuItem.Click += new System.EventHandler(this.nameToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(123, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // btnNewPerson
            // 
            this.btnNewPerson.Location = new System.Drawing.Point(12, 174);
            this.btnNewPerson.Name = "btnNewPerson";
            this.btnNewPerson.Size = new System.Drawing.Size(75, 35);
            this.btnNewPerson.TabIndex = 7;
            this.btnNewPerson.Text = "Add new Person";
            this.btnNewPerson.UseVisualStyleBackColor = true;
            this.btnNewPerson.Click += new System.EventHandler(this.btnNewPerson_Click);
            // 
            // nUD_NLStartNode
            // 
            this.nUD_NLStartNode.Location = new System.Drawing.Point(93, 38);
            this.nUD_NLStartNode.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nUD_NLStartNode.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nUD_NLStartNode.Name = "nUD_NLStartNode";
            this.nUD_NLStartNode.Size = new System.Drawing.Size(35, 20);
            this.nUD_NLStartNode.TabIndex = 1;
            this.nUD_NLStartNode.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nUD_NLStartNode.ValueChanged += new System.EventHandler(this.nUD_NLStartNode_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Start Node";
            // 
            // btnJump
            // 
            this.btnJump.Location = new System.Drawing.Point(68, 145);
            this.btnJump.Name = "btnJump";
            this.btnJump.Size = new System.Drawing.Size(16, 23);
            this.btnJump.TabIndex = 6;
            this.btnJump.Text = "J";
            this.btnJump.UseVisualStyleBackColor = true;
            this.btnJump.Click += new System.EventHandler(this.btnJump_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.Location = new System.Drawing.Point(902, 506);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 9;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnIdManagement
            // 
            this.btnIdManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIdManagement.Location = new System.Drawing.Point(12, 506);
            this.btnIdManagement.Name = "btnIdManagement";
            this.btnIdManagement.Size = new System.Drawing.Size(94, 23);
            this.btnIdManagement.TabIndex = 10;
            this.btnIdManagement.Text = "Id Management";
            this.btnIdManagement.UseVisualStyleBackColor = true;
            this.btnIdManagement.Click += new System.EventHandler(this.btnIdManagement_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 541);
            this.Controls.Add(this.btnIdManagement);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnJump);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nUD_NLStartNode);
            this.Controls.Add(this.btnNewPerson);
            this.Controls.Add(this.btnLoadLayout);
            this.Controls.Add(this.btnIdReset);
            this.Controls.Add(this.nUD_Id);
            this.Controls.Add(this.lblIdSelected);
            this.Controls.Add(this.btnSaveLayout);
            this.Controls.Add(this.btnNewLayout);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "FTreeViewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Id)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nUD_NLStartNode)).EndInit();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fatherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem motherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nameToolStripMenuItem;
        private System.Windows.Forms.Button btnNewPerson;
        private System.Windows.Forms.NumericUpDown nUD_NLStartNode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnJump;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnIdManagement;
    }
}

