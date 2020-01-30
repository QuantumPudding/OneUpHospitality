using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneUp_Table_Reservations
{
    public partial class NumberSelector : UserControl
    {
        public List<Button> Buttons;

        public double SelectedValue;
        public double MinValue;
        public double MaxValue;
        public double Increment;

        public int Columns;
        public int Rows;

        public int ButtonWidth;
        public int ButtonHeight;

        private int buttonWidthPadding = 2;
        private int buttonHeightPadding = 2;

        public NumberSelector(double minValue = 0, double maxValue = 9, double interval = 1, int rows = 1, int columns = 10, int buttonWidth = 24, int buttonHeight = 24)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            Increment = interval;
            Columns = columns;
            Rows = rows;
            ButtonWidth = buttonWidth;
            ButtonHeight = buttonHeight;
            Buttons = new List<Button>();

            InitializeComponent();
            CreateButtons();
            ResizeRedraw = true;
        }

        private void CreateButtons()
        {
            double currentValue = MinValue;
            int xoffset = 2;

            for (int y = 0; y < Columns; y++)
            {
                
                for (int x = 0; x < Rows; x++)
                {
                    if (currentValue > MaxValue)
                        break;

                    int offset = (y == 0) ? buttonWidthPadding : buttonWidthPadding * 2;

                    Button b = new Button();
                    b.Size = new Size(ButtonWidth, ButtonHeight);
                    b.Location = new Point(xoffset, (x * ButtonHeight) + buttonHeightPadding);
                    b.Click += B_Click;
                    b.Tag = currentValue;
                    b.Text = currentValue.ToString();

                    Controls.Add(b);
                    Buttons.Add(b);
                    b.Show();

                    currentValue += Increment;
                    
                }
                xoffset += ButtonWidth + 2;
                if (currentValue > MaxValue)
                    break;
            }
        }

        public void B_Click(object sender, EventArgs e)
        {
            SelectedValue = (Double)((Button)sender).Tag;
            this.Visible = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void NumberSelector_Load(object sender, EventArgs e)
        {
            Width = buttonWidthPadding + (ButtonWidth + buttonWidthPadding) * Columns;
            Height = buttonHeightPadding + (ButtonHeight + buttonHeightPadding) * Rows;
            BorderStyle = BorderStyle.None;
        }
    }
}
