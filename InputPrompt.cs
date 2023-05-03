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
    public partial class InputPrompt : Form
    {
        public InputPrompt()
        {
            InitializeComponent();
        }
        public bool ApplyFlag = false;
        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplyFlag = true;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
