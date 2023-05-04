using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FTreeViewer.Form1;

namespace FTreeViewer
{
    public partial class FIdManagement : Form
    {
        Form1 parent;
        public FIdManagement(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }
        private void IdManagement_Load(object sender, EventArgs e)
        {
            rB_ressurect.PerformClick();
        }

        #region radio
        private void rB_ressurect_Click(object sender, EventArgs e)
        {
            rB_shift.Checked = false;
            rB_ressurect.Checked = true;

            LoadDeletedNodes();
        }

        private void rB_shift_Click(object sender, EventArgs e)
        {
            rB_shift.Checked = true;
            rB_ressurect.Checked = false;

            LoadNodeRanges();
        }
        #endregion

        List<int> deletedIds = new List<int>();
        private void LoadDeletedNodes()
        {
            deletedIds.Clear();
            listBx.Items.Clear();
            for (int i = 0; i < Data.GetAmountPeople(); i++)
                if (Data.People[i] == null)
                {
                    listBx.Items.Add(i.ToString());
                    deletedIds.Add(i);
                }
            
        }
        List<(int low, int up)> ranges = new List<(int low, int up)>();
        private void LoadNodeRanges()
        {
            listBx.Items.Clear();
            ranges.Clear();
            List<int> range = new List<int>();
            int low, up;
            int entries = Data.GetAmountPeople();
            for (int i = 0; i < entries; i++)
            {
                if (Data.People[i] != null)
                    range.Add(i);
                if (range.Count != 0 && (Data.People[i] == null || i == entries - 1)) ;
                else continue;
                low = range[0];
                up = range[range.Count() - 1];
                ranges.Add((low, up));
                if (low == up)
                    listBx.Items.Add("< " + low.ToString() + " >");
                else
                    listBx.Items.Add("< " + low.ToString() + " - " + up.ToString() + " >");
                range.Clear();
            }
        }
        private void btnRessurect_Click(object sender, EventArgs e) //
        {
            var items = listBx.CheckedIndices;
            for (int i = 0; i < items.Count; i++)
            {
                parent.FormCreatePerson(deletedIds[items[i]]);
            }
            rB_ressurect.PerformClick();
        }

        private void btnUnselect_Click(object sender, EventArgs e)
        {
            listBx.ClearSelected();
            for (int i = 0; i < listBx.Items.Count; i++)
                listBx.SetItemChecked(i, false);
        }

        private void btnShiftUp_Click(object sender, EventArgs e)
        {
            var items = listBx.CheckedIndices;
            for (int i = 0; i < items.Count; i++)
            {
                var range = ranges[items[i]];
                if (Data.People[range.up + 1] != null) continue;
                for (int id = range.up; id >= range.low; id--)
                    Data.PersonChangeId(id, id + 1);
            }
            rB_shift.PerformClick();
            parent.Invalidate();
        }
        private void btnShiftDown_Click(object sender, EventArgs e)
        {
            var items = listBx.CheckedIndices;
            for (int i = 0; i < items.Count; i++)
            {
                var range = ranges[items[i]];
                if (range.low == 0 || Data.People[range.low - 1] != null) continue;
                for (int id = range.low; id <= range.up; id++)
                    Data.PersonChangeId(id, id - 1);
            }
            rB_shift.PerformClick();
            parent.Invalidate();
        }
    }
}
