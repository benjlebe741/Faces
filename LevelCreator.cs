using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Faces
{
    public partial class LevelCreator : UserControl
    {
        //Mouse Stuff
        PointF cursorPos;
        Color cursorColor = Color.White;
        Color determineColor = Color.White;

        //Points, Assets, Faces
        string mode = "SelectMode";
        int currentAsset = 0;
        List<PointF> points = new List<PointF>();
        PointF cornerOne = new PointF();
        PointF cornerTwo = new PointF();
        List<Face> faces = new List<Face>();


        //Lighting
        bool lighting = false;
        bool surfaceLights = true;
        List<Light> lights= new List<Light>();
        List<Light> primaryLights = new List<Light>();
        List<Light> secondaryLights = new List<Light>();
        List<Light> tertiaryLights = new List<Light>();
        public LevelCreator()
        {
            InitializeComponent();
            checkAsset();
            ModeCheck();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PolygonMode_Click(object sender, EventArgs e)
        {
            mode = "PolygonMode";
            ModeCheck();
        }

        private void RectangleMode_Click(object sender, EventArgs e)
        {
            mode = "RectangleMode";
            ModeCheck();
        }

        private void SelectMode_Click(object sender, EventArgs e)
        {
            mode = "SelectMode";
            ModeCheck();
        }

        void ModeCheck()
        {
            RectangleMode.BackColor = (mode != "RectangleMode") ? Color.LightGray : Color.White;
            PolygonMode.BackColor = (mode != "PolygonMode") ? Color.LightGray : Color.White;
            SelectMode.BackColor = (mode != "SelectMode") ? Color.LightGray : Color.White;
            scaleLabel5.Visible = scaleLabel6.Visible = (mode == "SelectMode");
        }

        private void LightsToggle_Click(object sender, EventArgs e)
        {
            lighting = !lighting;
            LightsToggle.BackColor = (lighting) ? Color.White : Color.LightGray;
            SurfaceLightsToggle.BackColor = (lighting) ? (surfaceLights) ? Color.White : Color.LightGray : Color.LightGray;
        }

        private void SurfaceLightsToggle_Click(object sender, EventArgs e)
        {
            surfaceLights = !surfaceLights;
            SurfaceLightsToggle.BackColor = (surfaceLights && lighting) ? Color.White : Color.LightGray;
        }
        void checkAsset()
        {
            bool assetHasFaces = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets.xml");
            XmlNodeList loadAsset = doc.GetElementsByTagName("Asset" + currentAsset);

            foreach (XmlNode n in loadAsset)
            {
                if (Convert.ToInt64(n.Attributes["FaceCount"].Value) > 0)
                {
                    assetHasFaces = true;
                    break;
                }
            }
            currentAssetLabel.ForeColor = (assetHasFaces) ? Color.Green : Color.Red;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            cursorPos = PointToClient(Cursor.Position);
            currentAssetLabel.Text = "" + currentAsset;
            determineNextColor();
            currentColor.BackColor = cursorColor;
            nextColor.BackColor = determineColor;

            lights.Clear();
            secondaryLights.Clear();
            tertiaryLights.Clear();

            lights.AddRange(primaryLights);
            foreach (Face f in faces)
            {
                Color color = f.colorValue(lights);
                secondaryLights.Add(new Light(color, new PointF(f.tiltedReciever.X + f.horizontalTilt, f.tiltedReciever.Y + f.verticalTilt)));
            }

            //primaryLights[0] = new Light(cursorColor, cursorPos);

            if (surfaceLights)
            {
                lights.AddRange(secondaryLights);
                foreach (Face f in faces)
                {
                    Color color = f.colorValue(lights);
                    tertiaryLights.Add(new Light(color, new PointF(f.tiltedReciever.X + f.horizontalTilt, f.tiltedReciever.Y + f.verticalTilt)));
                }

                lights.AddRange(tertiaryLights);
            }
            Refresh();
        }
        void determineNextColor()
        {
            int totalXdifference = this.Width;
            float percentage = (totalXdifference - cursorPos.X) / totalXdifference;
            percentage = (percentage < 0) ? 0 : percentage;
            percentage = (percentage > 1) ? 1 : percentage;
            determineColor = Color.FromArgb((int)(percentage * (float)255), (int)(percentage * (float)255), (int)(percentage * (float)255), (int)(percentage * (float)255));
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this,new MenuScreen());
        }

        private void LevelCreator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Y:
                    primaryLights.Add(new Light(cursorColor, cursorPos));
                    break;
                case Keys.R:
                    cursorColor = Color.FromArgb(cursorColor.A, determineColor.R, cursorColor.G, cursorColor.B);
                    break;
                case Keys.G:
                    cursorColor = Color.FromArgb(cursorColor.A, cursorColor.R, determineColor.G, cursorColor.B);
                    break;
                case Keys.B:
                    cursorColor = Color.FromArgb(cursorColor.A, cursorColor.R, cursorColor.G, determineColor.B);
                    break;
                case Keys.A:
                    cursorColor = Color.FromArgb(determineColor.A, cursorColor.R, cursorColor.G, determineColor.B);
                    break;
                case Keys.Space:
                    //if (points.Count > 2)
                    //{
                    //    List<PointF> _points = new List<PointF>();
                    //    _points.AddRange(points);
                    //    faces.Add(new Face(_points, cursorPos, cursorColor));
                    //    points.Clear();
                    //}
                    break;
                case Keys.Up:
                    currentAsset++;
                    checkAsset();
                    break;
                case Keys.Down:
                    currentAsset--;
                    checkAsset();
                    break;
            }
        }

        private void loadLabel_Click(object sender, EventArgs e)
        {
            //Clear the faces list
            faces.Clear();

            XmlDocument doc = new XmlDocument();
            doc.Load("Assets.xml");

            //Get the current asset, using a list so that if there is no asset we just have no items to work from in a foreach loop
            XmlNodeList loadAsset = doc.GetElementsByTagName("Asset" + currentAsset);

            foreach (XmlNode n in loadAsset)
            {
                //For each face inside the asset
                foreach (XmlNode f in n.ChildNodes)
                {
                    List<PointF> facePoints = new List<PointF>();
                    float xTilt = (float)Convert.ToDouble(f.Attributes["xTilt"].Value);
                    float yTilt = (float)Convert.ToDouble(f.Attributes["yTilt"].Value);
                    Color color = Color.FromArgb(Convert.ToInt16(f.Attributes["a"].Value), Convert.ToInt16(f.Attributes["r"].Value), Convert.ToInt16(f.Attributes["g"].Value), Convert.ToInt16(f.Attributes["b"].Value));

                    //For each point inside the face
                    foreach (XmlNode p in f.ChildNodes)
                    {
                        float x = (float)Convert.ToDouble(p.Attributes["x"].Value);
                        float y = (float)Convert.ToDouble(p.Attributes["y"].Value);

                        facePoints.Add(new PointF(x, y));
                    }

                    faces.Add(new Face(facePoints, new PointF(xTilt, yTilt), color));
                }
            }


        }

        private void LevelCreator_Paint(object sender, PaintEventArgs e)
        {
            //Fill the faces
            if (lighting)
            {
                foreach (Face f in faces)
                {
                    Color color = f.colorValue(lights);
                    e.Graphics.FillPolygon(new SolidBrush(color), f.points.ToArray());
                }
                foreach (Light l in primaryLights)
                {
                    e.Graphics.FillEllipse(new SolidBrush(l.color), new Rectangle((int)l.position.X - 4, (int)l.position.Y - 4, 8, 8));
                }
            }
            else
            {
                foreach (Face f in faces)
                {
                    Color color = f.initialColor;
                    e.Graphics.FillPolygon(new SolidBrush(color), f.points.ToArray());
                }
                foreach (Light l in lights)
                {
                    e.Graphics.FillEllipse(new SolidBrush(l.color), new Rectangle((int)l.position.X - 4, (int)l.position.Y - 4, 8, 8));
                }
            }

            //Show the current Points that are NOT faces YET
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

        private void regionBackground_Click(object sender, EventArgs e)
        {

        }

        private void regionMidground_Click(object sender, EventArgs e)
        {

        }

        private void regionForeground_Click(object sender, EventArgs e)
        {

        }
    }
}
