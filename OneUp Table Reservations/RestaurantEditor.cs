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
    public partial class RestaurantEditor : Form
    {
        DBConnection db;
        MySqlDataAdapter adapter;

        public RestaurantEditor()
        {
            InitializeComponent();
        }

        private void RestaurantEditor_Load(object sender, EventArgs e)
        {
            UpdateDGV();
        }

        private void UpdateDGV()
        {
            db = DBConnection.Instance();
            db.DatabaseName = "mydb";

            if (db.Open())
            {
                adapter = new MySqlDataAdapter("select * from Restaurants", db.Connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvRestaurants.DataSource = ds.Tables[0];

                for (int i = 0; i < dgvRestaurants.Columns.Count; i++)
                    dgvRestaurants.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                db.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //string statement =
            //    "insert into Restaurants (Name, MaxCovers, SunTimes, MonTimes, TueTimes, WedTimes, ThuTimes, FriTimes, SatTimes) " +
            //    "values ('" + txtName.Text + "','" +
            //    txtMaxCovers.Text + "','" +
            //    txtSunTimes.Text + "','" +
            //    txtMonTimes.Text + "','" +
            //    txtTueTimes.Text + "','" +
            //    txtWedTimes.Text + "','" +
            //    txtThuTimes.Text + "','" +
            //    txtFriTimes.Text + "','" +
            //    txtSatTimes.Text + "');";

            //db.ExecuteNonQuery(statement);

            //UpdateDGV();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //if (dgvRestaurants.SelectedRows.Count == 0)
            //    return;

            //DataGridViewRow row = dgvRestaurants.SelectedRows[0];

            //string id = row.Cells[0].Value.ToString();

            //string statement = "update Restaurants set Name = '" + txtName.Text + "'," +
            //    "MaxCovers = '" + txtMaxCovers.Text + "'," +
            //    "SunTimes = '" + txtSunTimes.Text + "'," +
            //    "MonTimes = '" + txtMonTimes.Text + "'," +
            //    "TueTimes = '" + txtTueTimes.Text + "'," +
            //    "WedTimes = '" + txtWedTimes.Text + "'," +
            //    "ThuTimes = '" + txtThuTimes.Text + "'," +
            //    "FriTimes = '" + txtFriTimes.Text + "'," +
            //    "SatTimes = '" + txtSatTimes.Text + "' " +
            //    "where RestaurantID = '" + id + "'";

            //db.ExecuteNonQuery(statement);

            //UpdateDGV();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvRestaurants.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                string statement = "delete from Restaurants where RestaurantID = '" + id + "'";

                db.ExecuteNonQuery(statement);
            }

            UpdateDGV();
        }

        private void dgvRestaurants_SelectionChanged(object sender, EventArgs e)
        {
            //if (dgvRestaurants.SelectedRows.Count == 0)
            //    return;

            //DataGridViewRow row = dgvRestaurants.SelectedRows[0];

            //string name = row.Cells[1].Value.ToString();
            //string maxcovers = row.Cells[2].Value.ToString();
            //string sun = row.Cells[3].Value.ToString();
            //string mon = row.Cells[4].Value.ToString();
            //string tue = row.Cells[5].Value.ToString();
            //string wed = row.Cells[6].Value.ToString();
            //string thu = row.Cells[7].Value.ToString();
            //string fri = row.Cells[8].Value.ToString();
            //string sat = row.Cells[9].Value.ToString();

            //txtName.Text = name;
            //txtMaxCovers.Text = maxcovers;
            //txtSunTimes.Text = sun;
            //txtMonTimes.Text = mon;
            //txtTueTimes.Text = tue;
            //txtWedTimes.Text = wed;
            //txtThuTimes.Text = thu;
            //txtFriTimes.Text = fri;
            //txtSatTimes.Text = sat;
        }
    }
}
