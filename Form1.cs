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
        List<Face> faces = new List<Face>();
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
            foreach (Face f in faces)
            {

                float b = f.lightValue(cursorPos);
                int c = (int)(255 / 2 * b);
                c += (255 / 2);
                c = (c > 255) ? 255 : c;
                c = (c < 0) ? 0 : c;

                e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(255, c, c, c)), f.points.ToArray());
                e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.FromArgb(205, c, c, c))), f.points.ToArray());
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(cursorPos);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (points.Count > 2)
                    {
                        List<PointF> _points = new List<PointF>();
                        _points.AddRange(points);
                        faces.Add(new Face(_points, cursorPos));
                        points.Clear();
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}
