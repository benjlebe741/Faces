using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faces
{
    public partial class Form1 : Form
    {
        Point cursorPos;
        List<PointF> points = new List<PointF>();
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            cursorPos = PointToClient(Cursor.Position);
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            //Unnasigned Points
            SolidBrush brush = new SolidBrush(Color.FromArgb(205, 255, 0, 255));
            if (points.Count > 2)
            {
                e.Graphics.FillPolygon(brush, points.ToArray());
            }
            foreach (PointF p in points)
            {
                e.Graphics.FillEllipse(brush, new Rectangle((int)p.X - 4, (int)p.Y - 4, 8, 8));
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(cursorPos);
        }
    }
}
