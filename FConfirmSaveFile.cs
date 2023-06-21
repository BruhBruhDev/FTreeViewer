using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTreeViewer
{
    public partial class FConfirmSaveFile : Form
    {
        public FConfirmSaveFile(string text)
        {
            InitializeComponent();
            this.lblText.Text = text;
        }
        private void FConfirm_Load(object sender, EventArgs e)
        {
            btnYes.Select();
        }
        public bool flagConfirm = false;
        public bool flagDontAskAgain = false;
        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            flagConfirm = true;
            this.Close();
        }
        private void cBx_DontAsk_CheckedChanged(object sender, EventArgs e)
        {
            flagDontAskAgain = cBx_DontAsk.Checked;
        }
    }
}
