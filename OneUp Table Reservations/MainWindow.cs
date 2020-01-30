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
    public partial class MainWindow : Form
    {
        DBConnection db;
        MySqlDataAdapter adapter;

        NumberSelector timeSelector = new NumberSelector(7, 21.5, 0.25);
        NumberSelector phoneSelector = new NumberSelector();
        TabPage currentDiaryTab;

        public MainWindow()
        {
            InitializeComponent();
            db = DBConnection.Instance();

            string user = Properties.Settings.Default["DatabaseUser"].ToString();
            string pass = Properties.Settings.Default["DatabasePass"].ToString();
            string host = Properties.Settings.Default["DatabaseHost"].ToString();
            string name = Properties.Settings.Default["DatabaseName"].ToString();

            if (!(user == "" || pass == ""))
                db.Initialise(user, Encryption.DecryptStringAES(pass, Encryption.PasswordHash), name, host);

            Controls.Add(timeSelector);
            Controls.Add(phoneSelector);
            phoneSelector.Visible = false;
            phoneSelector.VisibleChanged += PhoneSelector_VisibleChanged;
            timeSelector.Visible = false;
            timeSelector.VisibleChanged += TimeSelector_VisibleChanged;
        }

        private void PhoneSelector_VisibleChanged(object sender, EventArgs e)
        {
            if (phoneSelector.Visible == false)
                txtContactNumber.Text += phoneSelector.SelectedValue.ToString();
        }

        private void TimeSelector_VisibleChanged(object sender, EventArgs e)
        {
            if (timeSelector.Visible == false)
                txtTime.Text = timeSelector.SelectedValue.ToString();
        }


        private void UpdateDiaryTabs()
        {
            //Reset pages
            tcDiary.TabPages.Clear();

            //Get all restaurants
            List<string[]> restaurants = db.Select("select * from Restaurants");

            for (int i = 0; i < restaurants.Count; i++)
            {
                //For each restaurant, generate a new tabpage and datagridview
                string id = restaurants[i][0];
                string name = restaurants[i][1];

                DataGridView dgv = new DataGridView();
                dgv.Name = "dgv" + name;
                dgv.Tag = id;
                dgv.Dock = DockStyle.Fill;
                dgv.AllowUserToResizeColumns = true;
                dgv.AllowUserToResizeRows = true;
                dgv.RowHeadersVisible = false;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.MultiSelect = false;
                dgv.ReadOnly = true;
                dgv.BackgroundColor = Color.White;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.DoubleClick += Dgv_DoubleClick;
                dgv.Columns.Add("colID", "#");
                dgv.Columns.Add("colTime", "Time");
                dgv.Columns.Add("colName", "Name");
                dgv.Columns.Add("colCovers", "Covers");
                dgv.Columns.Add("colTel", "Contact Number");
                dgv.Columns.Add("colNotes", "Notes");
                dgv.Columns.Add("colGuestNotes", "Guest Notes");

                //Formatting
                dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                dgv.Columns[dgv.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[dgv.Columns.Count - 2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[0].Width = 28;
                dgv.Columns[1].Width = 48;
                dgv.Columns[3].Width = 52;

                TabPage tp = new TabPage(name);
                tp.Controls.Add(dgv);
                tcDiary.TabPages.Add(tp);
            }

            //Set current tab to first tab
            if (tcDiary.TabPages.Count > 0)
                currentDiaryTab = tcDiary.TabPages[0];

            //Get reservations for new current tab
            LoadReservations();
        }

        //DataGridView double click - open reservation editor
        private void Dgv_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            EditReservation form = new EditReservation(dgv.SelectedRows[0].Cells[0].Value.ToString());
            form.FormClosed += SubformClosed;
            form.Show();
        }

        private void LoadReservations()
        {
            if (currentDiaryTab == null)
                return;

            DataGridView dgv = (DataGridView)currentDiaryTab.Controls[0];
            dgv.Rows.Clear();

            string id = (string)dgv.Tag;

            //Pull reservations for current restaurant and current date
            string query = 
                "select * from Reservations where " +
                "RestaurantID = '" + id + "' and " +
                "Date = '" + calendar.SelectionStart.ToShortDateString() + "'";

            List<string[]> reservations = db.Select(query);

            foreach (string[] reservation in reservations)
            {
                string reservationID = reservation[0];
                string guestID = reservation[1];
                string restaurantID = reservation[2];
                string date = reservation[3];
                string time = reservation[4].Remove(5, 3);
                string covers = reservation[5];
                string notes = reservation[6];
                string deposit = reservation[7];
                string preorder = reservation[8];

                List<string[]> guest = db.Select("select Surname, ContactNumber, Notes from Guests where GuestID = '" + guestID + "'");

                string guestName = guest[0][0];
                string guestNumber = guest[0][1];
                string guestNotes = guest[0][2];

                dgv.Rows.Add(new object[] { reservationID, time, guestName, covers, guestNumber, notes, guestNotes });
            }

            //Sort by time
            dgv.Sort(dgv.Columns[1], ListSortDirection.Ascending);

            //Deselct all rows
            for (int i = 0; i < dgv.Rows.Count; i++)
                dgv.Rows[i].Selected = false;
        }

        private List<string[]> GetGuests()
        {
            return db.Select("select * from Guests");
        }

        private List<string> FindGuestsBySurname(string surname)
        {
            List<string[]> guests = GetGuests();
            List<string> found = new List<string>();

            foreach (string s in guests[1])
            {
                if (s.ToLower() == surname.ToLower())
                    found.Add(s);
            }

            return found;
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDiaryTabs();
        }

        private void viewGuestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuestDatabaseViewer form = new GuestDatabaseViewer();
            form.FormClosed += SubformClosed;
            form.Show();
        }

        private void editRestaurantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RestaurantEditor form = new RestaurantEditor();
            form.FormClosed += SubformClosed;
            form.Show();
        }

        private void SubformClosed(object sender, FormClosedEventArgs e)
        {
            UpdateDiaryTabs();
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            LoadReservations();
        }

        private void btnQuickReservation_Click(object sender, EventArgs e)
        {
            string statement = "insert into Guests (Surname, ContactNumber) " +
                "values ('" + txtName.Text + "','" +
                txtContactNumber.Text + "')";

            db.ExecuteNonQuery(statement);

            statement = "select max(GuestID) from Guests where Surname = '" + txtName.Text + "'";
            string id = db.Select(statement)[0][0];

            statement =
                "insert into Reservations (GuestID, RestaurantID, Date, Time, Covers) values" +
                "('" + id + "','" +
                currentDiaryTab.Controls[0].Tag.ToString() + "','" +
                calendar.SelectionStart.ToShortDateString() + "','" +
                txtTime.Text + "','" +
                txtCovers.Text + "')";

            db.ExecuteNonQuery(statement);

            LoadReservations();
        }

        private void btnDetailedReservation_Click(object sender, EventArgs e)
        {
            /////////////////////////HEREREEEEEEEE
        }

        private void tcDiary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcDiary.SelectedTab != null)
            {
                currentDiaryTab = tcDiary.SelectedTab;
                LoadReservations();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)currentDiaryTab.Controls[0];

            if (dgv.SelectedRows.Count == 0)
                return;

            db.ExecuteNonQuery("delete from Reservations where ReservationID = '" + dgv.SelectedRows[0].Cells[0].Value.ToString() + "'");

            LoadReservations();
        }

        private void txtTime_Enter(object sender, EventArgs e)
        {
            timeSelector.Location = new Point(txtTime.Location.X + txtTime.Width, txtTime.Location.Y - (timeSelector.Height / 2));
            timeSelector.BringToFront();
            timeSelector.Show();
        }

        private void txtTime_Leave(object sender, EventArgs e)
        {
            timeSelector.Visible = false;
        }

        private void TxtContactNumber_Enter(object sender, EventArgs e)
        {
            phoneSelector.Location = new Point(txtContactNumber.Right, txtContactNumber.Bottom);
            phoneSelector.BringToFront();
            phoneSelector.Show();
        }

        private void SettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingsForm frm = new SettingsForm();
            frm.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
