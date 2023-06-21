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
    public partial class Settings : Form
    {
        Form1 parent;
        public Settings(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
            cBx_arrowShowsGender.Checked = Config.UserSettings.isArrowShowsGender;
            cBx_dontAskAgainSaveIncompatible.Checked = Config.UserSettings.saveIncompatible_dontAskAgain;
        }
        private void cBx_arrowShowsGender_CheckedChanged(object sender, EventArgs e)
        {
            Config.UserSettings.isArrowShowsGender = cBx_arrowShowsGender.Checked;
            parent.Invalidate();
        }
        private void cBx_dontAskAgainSaveIncompatible_CheckedChanged(object sender, EventArgs e)
        {
            Config.UserSettings.saveIncompatible_dontAskAgain = cBx_dontAskAgainSaveIncompatible.Checked;
        }
    }
}
