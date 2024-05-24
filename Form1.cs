using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Faces
{
    public partial class Form1 : Form
    {
        List<Light> lights = new List<Light>();
        List<Face> faces = new List<Face>();
        Point cursorPos;
        List<PointF> points = new List<PointF>();

        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            lights.Add(new Light(Color.FromArgb(255, 150, 200, 10), cursorPos));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            cursorPos = PointToClient(Cursor.Position);
            lights[0] = new Light(Color.FromArgb(255, 150, 200, 10), cursorPos);
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
                Color color = f.colorValue(lights);
                e.Graphics.FillPolygon(new SolidBrush(color), f.points.ToArray());

              //  e.Graphics.FillEllipse(brush, new RectangleF(f.receiver.X - 2, f.receiver.Y - 2, 4, 4));
              //  e.Graphics.FillEllipse(brush, new RectangleF(f.tiltedReciever.X - 2, f.tiltedReciever.Y - 2, 4, 4));
            }

            label1.Text = "";
            foreach (Light l in lights)
            {
                e.Graphics.FillEllipse(brush, new RectangleF(l.position.X - 2, l.position.Y - 2, 4, 4));

                label1.Text += $"R:{l.color.R}G:{l.color.G}B:{l.color.B}\n";
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
                case Keys.Y:
                    lights.Add(new Light(Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)), cursorPos));
                    break;
                case Keys.X:
                    lights.Clear();
                    lights.Add(new Light(Color.FromArgb(255, 255, 255, 255), cursorPos));
                    break;
                case Keys.Space:
                    if (points.Count > 2)
                    {
                        List<PointF> _points = new List<PointF>();
                        _points.AddRange(points);
                        faces.Add(new Face(_points, cursorPos));
                        points.Clear();
                    }
                    break;
                case Keys.S:
                    save();
                    break;
                case Keys.L:
                    load();
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void load()
        {
            faces.Clear();
            string[] file = File.ReadAllLines("Asset.txt").ToArray();

            for (int s = 0; s < file.Length; s++)
            {
                if (file[s] == "New Face:")
                {
                    int pointCount = Convert.ToInt16(file[s + 1]);
                    List<PointF> _points = new List<PointF>();

                    //Add all the points
                    for (int p = 0; p < (pointCount * 2); p+=2)
                    {
                        _points.Add(new PointF((float)Convert.ToDouble(file[s + p + 3]), (float)Convert.ToDouble(file[s + p + 4])));
                    }

                    int tiltLine =  s + (pointCount * 2) + 2;
                    PointF tiltPoint = new PointF((float)Convert.ToDouble(file[tiltLine + 2]), (float)Convert.ToDouble(file[tiltLine + 3]));

                    faces.Add(new Face(_points, tiltPoint));
                }
            }
        }
        private void save()
        {
            List<string> ghostList = new List<string>();
            foreach (Face f in faces)
            {
                ghostList.Add($"New Face:");
                ghostList.Add($"{f.points.Count}");

                ghostList.Add($"Points:");
                foreach (PointF p in f.points)
                {
                    ghostList.Add($"{p.X}");
                    ghostList.Add($"{p.Y}");
                }

                ghostList.Add($"Tilt Point:");
                ghostList.Add($"{f.tiltedReciever.X}");
                ghostList.Add($"{f.tiltedReciever.Y}");
            }
            File.WriteAllLines("Asset.txt", ghostList);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
