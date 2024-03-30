using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDwinformdataset
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }


        private void Refresh()
        {
            dsCRUDTableAdapters.UsersTableAdapter ta = 
                new dsCRUDTableAdapters.UsersTableAdapter();
            dsCRUD.UsersDataTable dt = ta.GetData();

            dataGridView1.DataSource = dt;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmUsers frm = new FrmUsers();
            frm.ShowDialog();
            Refresh();
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {

                return null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if (Id != null)
            {
                FrmUsers frm = new FrmUsers(Id);
                frm.ShowDialog();
                Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int? Id = GetId();
            if(Id != null)
            {
                dsCRUDTableAdapters.UsersTableAdapter ta = new dsCRUDTableAdapters.UsersTableAdapter();
                ta.Remove((int)Id);
                Refresh();
            }
        }
    }
}
