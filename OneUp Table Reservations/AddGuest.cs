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
    public struct GuestInfo
    {
        public string ID;
        public string Surname;
        public string Forename;
        public string ContactNumber;
        public string Email;
        public string Notes;
    }

    public partial class GuestDatabaseViewer : Form
    {
        public GuestInfo SelectedGuest;
        DBConnection db;
        MySqlDataAdapter adapter;

        public GuestDatabaseViewer()
        {
            InitializeComponent();
        }

        private void AddGuest_Load(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void UpdateDGV()
        {
            db = DBConnection.Instance();

            if (db.Open())
            {
                adapter = new MySqlDataAdapter("select * from Guests", db.Connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvGuests.DataSource = ds.Tables[0];

                for (int i = 0; i < dgvGuests.Columns.Count; i++)
                    dgvGuests.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                db.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string statement =
                "insert into Guests (Surname, Forename, Phone, Email, Notes) " +
                "values ('" + txtSurname.Text + "','" +
                txtForename.Text + "','" +
                txtContactNumber.Text + "','" +
                txtEmail.Text + "','" +
                txtNotes.Text + "');";

            db.ExecuteNonQuery(statement);

            UpdateDGV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGuests.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                string statement = "delete from Guests where ID = '" + id + "'";

                db.ExecuteNonQuery(statement);
            }

            UpdateDGV();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvGuests.SelectedRows[0];

            string id = row.Cells[0].Value.ToString();

            string statement = "update Guests set Surname = '" + txtSurname.Text + "'," +
                "Forename = '" + txtForename.Text + "'," +
                "Phone = '" + txtContactNumber.Text + "'," +
                "Email = '" + txtEmail.Text + "'," +
                "Notes = '" + txtNotes.Text + "'" +
                "where ID = '" + id + "'";

            db.ExecuteNonQuery(statement);

            UpdateDGV();
        }

        private void dgvGuests_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvGuests.SelectedRows.Count == 0)
                return;

            DataGridViewRow row = dgvGuests.SelectedRows[0];

            string surname = row.Cells[1].Value.ToString();
            string forename = row.Cells[2].Value.ToString();
            string tel = row.Cells[3].Value.ToString();
            string email = row.Cells[4].Value.ToString();
            string notes = row.Cells[5].Value.ToString();

            txtSurname.Text = surname;
            txtForename.Text = forename;
            txtContactNumber.Text = tel;
            txtEmail.Text = email;
            txtNotes.Text = notes;

            SelectedGuest = new GuestInfo();
            SelectedGuest.ID = row.Cells[0].Value.ToString();
            SelectedGuest.Surname = surname;
            SelectedGuest.Forename = forename;
            SelectedGuest.ContactNumber = tel;
            SelectedGuest.Email = email;
            SelectedGuest.Notes = notes;
        }
    }
}
