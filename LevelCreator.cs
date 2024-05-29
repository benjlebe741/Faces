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
using System.Xml.Linq;

namespace Faces
{
    public partial class LevelCreator : UserControl
    {
        //Mouse Stuff
        PointF cursorPos;
        Color cursorColor = Color.White;
        Color determineColor = Color.White;

        //Points, Assets, Faces
        string mode = "Not Set";
        int currentAsset = 0;
        List<PointF> points = new List<PointF>();
        PointF cornerOne = new PointF();
        PointF cornerTwo = new PointF();


        //Lighting
        bool lighting = false;
        bool surfaceLights = true;

        //Planes
        List<Plane> planes = new List<Plane> { new Plane(), new Plane(), new Plane() };
        int planeDepth = 1;
        string regionDepth = "Not Set";
        string additionType = "Not Set";
        public LevelCreator()
        {
            InitializeComponent();
            checkAsset();
            checKLevel();
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
            describeThis();
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
            currentAssetLabel.Text = "" + currentAsset;
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
        void checKLevel()
        {
            currentLevelLabel.Text = "" + currentAsset;
            bool LevelExists = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("Levels.xml");
            XmlNodeList loadAsset = doc.GetElementsByTagName("Level" + currentAsset);

            foreach (XmlNode n in loadAsset)
            {
                LevelExists = true;
            }
            currentLevelLabel.ForeColor = (LevelExists) ? Color.Green : Color.Red;
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            cursorPos = PointToClient(Cursor.Position);
            determineNextColor();
            currentColor.BackColor = cursorColor;
            nextColor.BackColor = determineColor;
            foreach (Plane p in planes)
            {
                p.tick(surfaceLights);
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
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void LevelCreator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Y:
                    planes[planeDepth].primaryLights.Add(new Light(cursorColor, cursorPos));
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
                    if (points.Count > 2)
                    {
                        List<PointF> _points = new List<PointF>();
                        _points.AddRange(points);
                        planes[planeDepth].faces.Add(new Face(_points, cursorPos, cursorColor));
                        points.Clear();
                    }
                    break;
                case Keys.Up:
                    currentAsset++;
                    checkAsset();
                    checKLevel();
                    break;
                case Keys.Down:
                    currentAsset--;
                    checkAsset();
                    checKLevel();
                    break;
            }
        }

        private void loadLabel_Click(object sender, EventArgs e)
        {
            //Clear the faces list
            planes[planeDepth].faces.Clear();

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

                    planes[planeDepth].faces.Add(new Face(facePoints, new PointF(xTilt, yTilt), color));
                }
            }


        }

        private void LevelCreator_Paint(object sender, PaintEventArgs e)
        {
            foreach (Plane plane in planes)
            {
                #region Shaded
                //Fill the faces
                if (lighting)
                {
                    foreach (Face f in plane.faces)
                    {
                        Color color = f.colorValue(plane.lights);
                        e.Graphics.FillPolygon(new SolidBrush(color), f.points.ToArray());
                    }
                    foreach (Light l in plane.lights)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(l.color), new Rectangle((int)l.position.X - 4, (int)l.position.Y - 4, 8, 8));
                    }
                }
                #endregion
                #region UnShaded
                else
                {
                    foreach (Face f in plane.faces)
                    {
                        Color color = f.initialColor;
                        e.Graphics.FillPolygon(new SolidBrush(color), f.points.ToArray());
                    }
                    foreach (Light l in plane.lights)
                    {
                        e.Graphics.FillEllipse(new SolidBrush(l.color), new Rectangle((int)l.position.X - 4, (int)l.position.Y - 4, 8, 8));
                    }
                }
                #endregion
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
            regionDepth = "Background";
            planeDepth = 0;
            regionDepthCheck();
        }

        private void regionMidground_Click(object sender, EventArgs e)
        {
            regionDepth = "Midground";
            planeDepth = 1;
            regionDepthCheck();
        }

        private void regionForeground_Click(object sender, EventArgs e)
        {
            regionDepth = "Foreground";
            planeDepth = 2;
            regionDepthCheck();
        }

        private void regionArt_Click(object sender, EventArgs e)
        {
            additionType = "Art";
            additionTypeCheck();
        }

        private void regionLights_Click(object sender, EventArgs e)
        {
            additionType = "Light";
            additionTypeCheck();
        }

        private void regionCollisions_Click(object sender, EventArgs e)
        {
            additionType = "Collisions";
            additionTypeCheck();
        }

        void regionDepthCheck()
        {
            regionBackground.BackColor = (regionDepth == "Background") ? Color.White : Color.LightGray;
            regionMidground.BackColor = (regionDepth == "Midground") ? Color.White : Color.LightGray;
            regionForeground.BackColor = (regionDepth == "Foreground") ? Color.White : Color.LightGray;
            describeThis();
        }
        void additionTypeCheck()
        {
            regionArt.BackColor = (additionType == "Art") ? Color.White : Color.LightGray;
            regionCollisions.BackColor = (additionType == "Collisions") ? Color.White : Color.LightGray;
            describeThis();
        }

        void describeThis()
        {
            describeCurrent.Text = $"Changing {additionType} in {regionDepth} with {mode}";
        }

        private void LevelCreator_MouseDown(object sender, MouseEventArgs e)
        {
            switch (additionType)
            {
                case "Art":
                    switch (mode)
                    {
                        case "RectangleMode":
                            cornerOne = cursorPos;
                            break;
                    }
                    break;
            }
        }

        private void LevelCreator_MouseUp(object sender, MouseEventArgs e)
        {
            switch (additionType)
            {
                case "Art":
                    switch (mode)
                    {
                        case "RectangleMode":
                            cornerTwo = cursorPos;
                            points.Add(cornerOne);
                            points.Add(new PointF(cornerOne.X, cornerTwo.Y));
                            points.Add(cornerTwo);
                            points.Add(new PointF(cornerTwo.X, cornerOne.Y));
                            break;
                        case "PolygonMode":
                            points.Add(cursorPos);
                            break;
                        case "SelectMode":
                            break;
                    }
                    break;
            }
        }

        private void saveLevel_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Levels.xml");

            //Remove all levels with the current ID
            XmlNodeList nodes = doc.GetElementsByTagName("Level" + currentAsset);
            for (int n = 0; n < nodes.Count; n++)
            {
                nodes[n].ParentNode.RemoveChild(nodes[n]);
            }

            XmlElement root = doc.DocumentElement;

            //Add a new level with this ID 
            XmlElement newLevel = doc.CreateElement("Level" + currentAsset);
            newLevel.SetAttribute("PlaneCount", "" + planes.Count);

            //Add the faces to the levels planes
            foreach (Plane pl in planes)
            {
                XmlElement plane = doc.CreateElement("Face");
                foreach (Face f in pl.faces)
                {
                    XmlElement face = doc.CreateElement("Face");
                    face.SetAttribute("PointCount", "" + f.points.Count);

                    //Add the points of each face to the face
                    foreach (PointF p in f.points)
                    {
                        XmlElement point = doc.CreateElement("PointF");
                        point.SetAttribute("x", "" + p.X);
                        point.SetAttribute("y", "" + p.Y);
                        face.AppendChild(point);
                    }

                    //Add the tilt of the face
                    face.SetAttribute("xTilt", "" + f.tiltedReciever.X);
                    face.SetAttribute("yTilt", "" + f.tiltedReciever.Y);

                    //Add the initial color of the face
                    face.SetAttribute("a", "" + f.initialColor.A);
                    face.SetAttribute("r", "" + f.initialColor.R);
                    face.SetAttribute("g", "" + f.initialColor.G);
                    face.SetAttribute("b", "" + f.initialColor.B);

                    plane.AppendChild(face);
                }
                foreach (Light l in pl.primaryLights) 
                {
                    XmlElement light = doc.CreateElement("Light");
                    light.SetAttribute("a", "" + l.color.A);
                    light.SetAttribute("r", "" + l.color.R);
                    light.SetAttribute("g", "" + l.color.G);
                    light.SetAttribute("b", "" + l.color.B);

                    light.SetAttribute("x", "" + l.position.X);
                    light.SetAttribute("y", "" + l.position.Y);

                    plane.AppendChild(light);
                }

                newLevel.AppendChild(plane);
            }
            root.AppendChild(newLevel);
            doc.Save("Levels.xml");

            checKLevel();
        }

        private void loadLevel_Click(object sender, EventArgs e)
        {
            foreach (Plane pl in planes)
            {
                pl.faces.Clear();
                pl.lights.Clear();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load("Levels.xml");

            //Get the current level, using a list so that if there is no level we just have no items to work from in a foreach loop
            XmlNodeList loadAsset = doc.GetElementsByTagName("Level" + currentAsset);

            planes.Clear();
            foreach (XmlNode level in loadAsset)
            {
                foreach (XmlNode pl in level.ChildNodes)
                {
                    Plane plane = new Plane();
                    //For each plane inside the level
                    foreach (XmlNode f in pl.SelectNodes("Face"))
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

                        plane.faces.Add(new Face(facePoints, new PointF(xTilt, yTilt), color));
                    }
                    foreach (XmlNode l in pl.SelectNodes("Light"))
                    {
                        Color color = Color.FromArgb(Convert.ToInt16(l.Attributes["a"].Value), Convert.ToInt16(l.Attributes["r"].Value), Convert.ToInt16(l.Attributes["g"].Value), Convert.ToInt16(l.Attributes["b"].Value));
                        PointF position = new PointF((float)Convert.ToDouble(l.Attributes["x"].Value), (float)Convert.ToDouble(l.Attributes["y"].Value));
                        plane.primaryLights.Add(new Light(color,position));
                    }
                    planes.Add(plane);
                }
            }
        }
    }
}
