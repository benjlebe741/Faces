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
        Color cursorColor = Color.White;
        List<Light> lights = new List<Light>();
        List<Light> primaryLights = new List<Light>();
        List<Light> secondaryLights = new List<Light>();
        List<Face> faces = new List<Face>();
        Point cursorPos;
        List<PointF> points = new List<PointF>();
        double time = 0;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            ChangeScreen(this, new MenuScreen());
            primaryLights.Add(new Light(Color.FromArgb(255, 150, 200, 10), cursorPos));
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
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
                    primaryLights.Add(new Light(cursorColor, cursorPos));
                    break;
                case Keys.X:
                    primaryLights.Clear();
                    cursorColor = Color.FromArgb(255, 0, 0, 0);
                    primaryLights.Add(new Light(cursorColor, cursorPos));
                    break;
                case Keys.Space:
                    if (points.Count > 2)
                    {
                        List<PointF> _points = new List<PointF>();
                        _points.AddRange(points);
                        faces.Add(new Face(_points, cursorPos, cursorColor));
                        points.Clear();
                    }
                    break;
                case Keys.S:
                    cursorColor = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                    //save();
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
                    for (int p = 0; p < (pointCount * 2); p += 2)
                    {
                        _points.Add(new PointF((float)Convert.ToDouble(file[s + p + 3]), (float)Convert.ToDouble(file[s + p + 4])));
                    }

                    int tiltLine = s + (pointCount * 2) + 2;
                    PointF tiltPoint = new PointF((float)Convert.ToDouble(file[tiltLine + 2]), (float)Convert.ToDouble(file[tiltLine + 3]));

                    faces.Add(new Face(_points, tiltPoint, Color.Red));
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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
        public static void ChangeScreen(object sender, UserControl next)
        {

            Form f; // will either be the sender or parent of sender 

            if (sender is Form)
            {
                f = (Form)sender;
            }
            else
            {
                UserControl current = (UserControl)sender;
                f = current.FindForm();
                f.Controls.Remove(current);
            }

            next.Location = new Point((f.ClientSize.Width - next.Width) / 2, (f.ClientSize.Height - next.Height) / 2);
            f.Controls.Add(next);

            next.Focus();
        }
    }
}
