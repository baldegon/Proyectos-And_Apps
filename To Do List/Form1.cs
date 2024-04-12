using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    public partial class ToDoList : Form
    {
        public ToDoList()
        {
            InitializeComponent();
        }

        DataTable todolist = new DataTable();
        bool isEditing = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Create Columns
            todolist.Columns.Add("NameTask");
            todolist.Columns.Add("DescriptionTask");

            //Point our datagridview to our datasource
            toDoListView.DataSource = todolist;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NameTask_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Nametxt.Text = "";
            Descriptiontxt.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            isEditing = true;
            // Fill text fields with data from table
            Nametxt.Text = todolist.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            Descriptiontxt.Text = todolist.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                todolist.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todolist.Rows[toDoListView.CurrentCell.RowIndex]["NameTask"] = Nametxt.Text;
                todolist.Rows[toDoListView.CurrentCell.RowIndex]["DescriptionTask"] = Descriptiontxt.Text;
            }
            else
            {
                todolist.Rows.Add(Nametxt.Text, Descriptiontxt.Text);
            }
            // Clear Fields
            Nametxt.Text = "";
            Descriptiontxt.Text = "";
            isEditing = false;  
        }
    }
}
