using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneUp_Table_Reservations
{
    public class CustomListView : ListView
    {
        public CustomListView()
        {
            OwnerDraw = true; ;
            View = View.List;
            FullRowSelect = true;
            DoubleBuffered = true;
            HeaderStyle = ColumnHeaderStyle.None;

            this.DrawColumnHeader += CustomListView_DrawColumnHeader;
            this.DrawItem += CustomListView_DrawItem;
            this.DrawSubItem += CustomListView_DrawSubItem;

            DrawItem += CustomListView_DrawItem;

        }

        private void CustomListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            
        }

        private void CustomListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        protected override System.Windows.Forms.CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style & ~0x200000;
                return cp;
            }
        }

        private void CustomListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if ((e.State & ListViewItemStates.Selected) != 0)
            {
                // Draw the background and focus rectangle for a selected item.
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);
                e.Graphics.DrawString(e.Item.Text, Font, Brushes.White, new PointF(e.Bounds.X + 2, e.Bounds.Y));
            }
            else
            {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
                e.Graphics.DrawString(e.Item.Text, Font, Brushes.Black, new PointF(e.Bounds.X + 2, e.Bounds.Y));
            }
        }
    }
}
