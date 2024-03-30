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
    public partial class FrmUsers : Form
    {
        private int? Id;
        public FrmUsers(int? Id=null)
        {
            InitializeComponent();
            this.Id = Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dsCRUDTableAdapters.UsersTableAdapter ta = 
                new dsCRUDTableAdapters.UsersTableAdapter();
            if(Id == null)
            {
                ta.Add(txtName.Text.Trim(), (int)txtAge.Value);
            }
            else
            {
                ta.Edit(txtName.Text.Trim(), (int)txtAge.Value, (int)Id);
            }
            this.Close();
        }

        private void FrmUsers_Load(object sender, EventArgs e)
        {
            if(Id != null)
            {
                dsCRUDTableAdapters.UsersTableAdapter ta =
                    new dsCRUDTableAdapters.UsersTableAdapter();
                dsCRUD.UsersDataTable dt =  ta.GetDataByID((int)Id);
                dsCRUD.UsersRow row = (dsCRUD.UsersRow)dt.Rows[0];
                txtName.Text = row.name;
                txtAge.Value = row.age;
            }
        }
    }
}
