using HelperClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneUp_Table_Reservations
{
    public partial class EditDatabase : Form
    {
        DBConnection db;
        private MySqlDataAdapter adapter;
        private MySqlCommandBuilder cmdBuilder;
        private BindingSource bindingSrc;
        private DataTable dt;

        public EditDatabase()
        {
            InitializeComponent();
            db = DBConnection.Instance();

        }
        private void UpdateDGV(string table)
        {
            if (db.Open())
            {
                adapter = new MySqlDataAdapter("select * from " + table, db.Connection);
                cmdBuilder = new MySqlCommandBuilder(adapter);

                adapter.UpdateCommand = cmdBuilder.GetUpdateCommand();
                adapter.DeleteCommand = cmdBuilder.GetDeleteCommand();
                adapter.InsertCommand = cmdBuilder.GetInsertCommand();

                dt = new DataTable();
                adapter.Fill(dt);

                bindingSrc = new BindingSource();
                bindingSrc.DataSource = dt;

                DGV.DataSource = bindingSrc;

                for (int i = 0; i < DGV.Columns.Count; i++)
                    DGV.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                db.Close();
            }
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void EditDatabase_Load(object sender, EventArgs e)
        {
            
        }

        private void CbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTables.Text == "")
                return;

            UpdateDGV(cbTables.Text);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (adapter == null)
                return;

            adapter.Update(dt);

            UpdateDGV(cbTables.Text);
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            string uid = txtUser.Text;
            string pass = txtPass.Text;
            string host = txtHost.Text;

            db.Initialise(uid, pass, "MainDatabase", host);

            if (btnConnect.Text == "Connect")
            {
                if (db.Open())
                {
                    //If we can connect, load tables
                    btnConnect.Text = "Disconnect";
                    txtUser.Enabled = false;
                    txtPass.Enabled = false;
                    txtHost.Enabled = false;
                    btnUpdate.Enabled = true;
                    db.Close();

                    List<string[]> tables = db.Select("SHOW TABLES");

                    foreach (string[] s in tables)
                        cbTables.Items.Add(s[0]);
                }
            }
            else
            {
                db.Close();
                txtPass.Enabled = true;
                txtUser.Enabled = true;
                txtHost.Enabled = true;
                btnUpdate.Enabled = false;
                txtPass.Clear();
                txtUser.Clear();
                cbTables.Items.Clear();
                DGV.DataSource = null;
                adapter = null;
                bindingSrc = null;
                dt = null;
                cmdBuilder = null;
            }
        }
    }
}
