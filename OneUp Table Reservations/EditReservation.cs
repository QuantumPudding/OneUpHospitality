using HelperClasses;
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
    public partial class EditReservation : Form
    {
        DBConnection db;
        List<string[]> Reservation;
        List<string[]> Restaurants;
        string ReservationRef = "";
        GuestInfo Guest;

        public EditReservation()
        {
            InitializeComponent();
        }

        public EditReservation(string reservationRef)
        {
            InitializeComponent();
            ReservationRef = reservationRef;
        }

        private void EditReservation_Load(object sender, EventArgs e)
        {
            db = DBConnection.Instance();

            Reservation = db.Select("select * from Reservations where ReservationID = '" + ReservationRef + "'");

            if (Reservation.Count > 0)
            {
                List<string[]> guest = db.Select("select * from Guests where GuestID = '" + Reservation[0][1] + "'");

                Restaurants = db.Select("select * from Restaurants");

                Guest = new GuestInfo();
                Guest.ID = guest[0][0];
                Guest.Surname = guest[0][1];
                Guest.Forename = guest[0][2];
                Guest.ContactNumber = guest[0][3];
                Guest.Email = guest[0][4];
                Guest.Notes = guest[0][5];

                txtRef.Text = ReservationRef;
                txtGuest.Text = Guest.Surname;
                txtCovers.Text = Reservation[0][5];
                txtTime.Text = Reservation[0][4];
                txtNotes.Text = Reservation[0][7];
                dtPicker.Value = DateTime.Parse(Reservation[0][3]);

                foreach (string[] restaurant in Restaurants)
                {
                    cbRestaurants.Items.Add(restaurant[1]);

                    if (restaurant[0] == Reservation[0][2])
                        cbRestaurants.Text = restaurant[1];
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string statement = "update Reservations set GuestID = '" + Guest.ID + "'," +
                "RestaurantID = '" + Restaurants[cbRestaurants.SelectedIndex][0] + "'," +
                "Date = '" + dtPicker.Value.ToShortDateString() + "'," +
                "Time = '" + txtTime.Text + "'," +
                "Covers = '" + txtCovers.Text + "'," +
                "Notes = '" + txtNotes.Text + "' " +
                "where ReservationID = '" + txtRef.Text + "'";

            db.ExecuteNonQuery(statement);
            Close();
        }

        private void btnSelectGuest_Click(object sender, EventArgs e)
        {
            GuestDatabaseViewer form = new GuestDatabaseViewer();
            form.Controls["dgvGuests"].DoubleClick += GuestSelectionForm_DoubleClick;
            form.Show();
        }

        private void GuestSelectionForm_DoubleClick(object sender, EventArgs e)
        {
            GuestDatabaseViewer form = (GuestDatabaseViewer)((DataGridView)sender).Parent;
            GuestInfo guest = form.SelectedGuest;

            Guest = guest;
            txtGuest.Text = Guest.Surname;
        }
    }
}
