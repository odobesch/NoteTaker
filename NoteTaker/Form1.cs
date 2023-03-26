using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTaker
{
    public partial class NoteTaker : Form
    {
       DataTable notes = new DataTable();
        bool editing = false;

        public NoteTaker()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            tbTitle.Text = notes.Rows[previousNotesGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
            tbMsg.Text = notes.Rows[previousNotesGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                notes.Rows[previousNotesGrid.CurrentCell.RowIndex]["Title"] = tbTitle.Text;
                notes.Rows[previousNotesGrid.CurrentCell.RowIndex]["Note"] = tbTitle.Text;
            }
            else
            {
               notes.Rows.Add(tbTitle.Text, tbMsg.Text);
            }
            tbMsg.Text = "";
            tbTitle.Text = "";
            editing = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            tbMsg.Text = "";
            tbTitle.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                notes.Rows[previousNotesGrid.CurrentCell.RowIndex].Delete();
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid note");
            }

        }

        private void NoteTaker_Load(object sender, EventArgs e)
        {
            notes.Columns.Add("Title");
            notes.Columns.Add("Note");

            previousNotesGrid.DataSource = notes;
        }

        private void previousNotesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tbTitle.Text = notes.Rows[previousNotesGrid.CurrentCell.RowIndex].ItemArray[0].ToString();
            tbMsg.Text = notes.Rows[previousNotesGrid.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}
