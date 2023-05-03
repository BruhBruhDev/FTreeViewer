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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }
        private void About_Load(object sender, EventArgs e)
        {
            linktext = linkLabel1.Text;
            lblAppVersion.Text = "Application Version:\n"+ meta.VERSION + " " + meta.VERSION_TYPE + " - " + meta.VERSION_DATE;
        }
        string linktext;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linktext);
                linkLabel1.Text = linktext;
            }
            catch 
            {
                linkLabel1.Text = linkLabel1.Text + " [ ! ]";
            }
        }

        public static class meta
        {
            public static string VERSION = "0.1.0";
            public static string VERSION_TYPE = "Debug";
            public static string VERSION_DATE = "May 2023";
        }

    }
}
