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
using System.Xml;

namespace Faces
{
    public partial class AssetCreator : UserControl
    {
        int currentAsset = 0;
        bool lighting = false;
        bool surfaceLights = true;
        List<Face> faces = new List<Face>();

        //Lighting 
        List<Light> lights = new List<Light>();
        List<Light> primaryLights = new List<Light>();
        List<Light> secondaryLights = new List<Light>();
        List<Light> tertiaryLights = new List<Light>();

        //Points that will be saved as faces
        List<PointF> points = new List<PointF>();

        //Mouse Stuff
        PointF cursorPos;
        Color cursorColor = Color.White;
        Color determineColor = Color.White;

        //What way are you adding polygons
        string createMode = "Polygons";
        PointF cornerOne = new PointF();
        PointF cornerTwo = new PointF();

        public AssetCreator()
        {
            InitializeComponent();
            primaryLights.Add(new Light(Color.White, new PointF(0, 0)));
            checkAsset();
        }

        private void timer1_Tick(object sender, EventArgs e)
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

            primaryLights[0] = new Light(cursorColor, cursorPos);

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

        private void AssetCreator_Paint(object sender, PaintEventArgs e)
        {
            //Fill the faces
            if (lighting)
            {
                foreach (Face f in faces)
                {
                    Color color = f.colorValue(lights);
                    e.Graphics.FillPolygon(new SolidBrush(color), f.points.ToArray());
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

        private void AssetCreator_MouseClick(object sender, MouseEventArgs e)
        {
            if (createMode == "Polygons")
            {
                points.Add(cursorPos);
            }
        }

        private void AssetCreator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Y:
                    primaryLights.Add(new Light(cursorColor, cursorPos));
                    break;
                case Keys.X:
                    primaryLights.Clear();
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
                    if (points.Count > 2)
                    {
                        List<PointF> _points = new List<PointF>();
                        _points.AddRange(points);
                        faces.Add(new Face(_points, cursorPos, cursorColor));
                        points.Clear();
                    }
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

        private void label1_Click(object sender, EventArgs e)
        {
            //Back to Menu Screen
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Toggle Lights
            lighting = !lighting;
        }

        private void AssetCreator_Load(object sender, EventArgs e)
        {

        }

        private void saveLabel_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets.xml");

            //Remove all assets with the current ID
            XmlNodeList nodes = doc.GetElementsByTagName("Asset" + currentAsset);
            for (int n = 0; n < nodes.Count; n++)
            {
                nodes[n].ParentNode.RemoveChild(nodes[n]);
            }

            XmlElement root = doc.DocumentElement;

            //Add a new asset with this ID 
            XmlElement newAsset = doc.CreateElement("Asset" + currentAsset);
            newAsset.SetAttribute("FaceCount", "" + faces.Count);

            //Add the faces to the asset
            foreach (Face f in faces)
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

                newAsset.AppendChild(face);
            }


            root.AppendChild(newAsset);
            doc.Save("Assets.xml");

            checkAsset();
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

        private void currentAssetLabel_Click(object sender, EventArgs e)
        {

        }

        private void PolygoneMode_Click(object sender, EventArgs e)
        {
            createMode = "Polygons";
            PolygoneMode.BackColor = Color.White;
            RectangleMode.BackColor = Color.LightGray;
        }

        private void RectangleMode_Click(object sender, EventArgs e)
        {
            createMode = "Rectangles";
            RectangleMode.BackColor = Color.White;
            PolygoneMode.BackColor = Color.LightGray;
        }

        private void AssetCreator_MouseUp(object sender, MouseEventArgs e)
        {
            if (createMode == "Rectangles")
            {
                cornerTwo = cursorPos;
                points.Add(cornerOne);
                points.Add(new PointF(cornerOne.X, cornerTwo.Y));
                points.Add(cornerTwo);
                points.Add(new PointF(cornerTwo.X, cornerOne.Y));
            }
        }

        private void AssetCreator_MouseDown(object sender, MouseEventArgs e)
        {
            if (createMode == "Rectangles")
            {
                cornerOne = cursorPos;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            surfaceLights = !surfaceLights;
            label3.BackColor = (surfaceLights) ? Color.White : Color.LightGray;
        }
    }
}
