﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Faces
{
    public partial class LevelCreator : UserControl
    {
        //Player Stuff
        public static bool[] WSAD = new bool[4] { false, false, false, false };
        public static bool jumpPressed = false;
        public static bool airBorn = false;
        public static double ySpeed = 0;

        //Mouse Stuff
        PointF cursorPos;
        Color cursorColor = Color.White;
        Color determineColor = Color.White;
        PointF selectionPointOne = new PointF();

        //Points, Assets, Faces
        string mode = "Not Set";
        int currentAsset = 0;
        List<PointF> points = new List<PointF>();
        PointF cornerOne = new PointF();
        PointF cornerTwo = new PointF();

        //Lighting
        bool lighting = false;
        bool surfaceLights = true;
        Color backgroundColor = Color.FromArgb(0, 127, 127, 127);

        //Paralaxing
        PointF paralaxPoint = new PointF();
        PointF paralaxCursorPoint = new PointF();
        PointF movementPoint = new PointF(0, 0);
        PointF desiredParalaxPoint = new PointF();
        PointF desiredMovementPoint = new PointF();
        bool paralax = false;

        List<RectangleF> screenBounds = new List<RectangleF>();

        //Planes
        List<Plane> planes = new List<Plane> { new Plane(), new Plane(), new Plane() };
        int playerPlaneDepth = 0;
        int planeDepth = 1;
        string regionDepth = "Not Set";
        string additionType = "Not Set";
        bool outline = true;

        //Selections
        bool shiftPressed = false;
        bool ctrlPressed = false;
        string selectionOption = "Not Set";

        public LevelCreator()
        {
            InitializeComponent();
            checkAsset();
            checKLevel();
            ModeCheck();
            paralaxPoint = paralaxCursorPoint = new PointF(this.Width / 2, this.Height / 2);
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
            #region Selecting
            if (mode == "SelectMode")
            {
                switch (selectionOption)
                {
                    case "Scale": //Scale
                        PointF scalePoint = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                        foreach (Plane pl in planes)
                        {
                            foreach (Asset a in pl.assets)
                            {
                                if (a.selected)
                                {
                                    float scaleFactor = (float)1 + (float)(0.02 * ((shiftPressed) ? 1 : -1));
                                    a.ScaleFaces(selectionPointOne, scalePoint, (ctrlPressed) ? 1 : scaleFactor, (ctrlPressed) ? (float)0.05 * ((shiftPressed) ? 1 : -1) : 0);
                                }
                            }
                        }
                        break;
                    case "Rotate": //Rotate
                        foreach (Plane pl in planes)
                        {
                            foreach (Asset a in pl.assets)
                            {
                                if (a.selected)
                                {
                                    a.RotateFaces(selectionPointOne, ((ctrlPressed) ? (float)Math.PI / 2 : (float)0.04) * ((shiftPressed) ? 1 : -1));
                                }
                            }
                        }
                        selectionOption = (ctrlPressed) ? "Not Set" : "Rotate";
                        break;
                    case "Move": //Translate
                        PointF movePoint = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                        foreach (Plane pl in planes)
                        {
                            foreach (Asset a in pl.assets)
                            {
                                if (a.selected)
                                {
                                    a.TranslateFaces(selectionPointOne, movePoint);
                                }
                            }
                        }
                        selectionPointOne = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                        break;
                }
            }
            #endregion

            label1.Text = "" + shiftPressed;

            float xTilt = (desiredParalaxPoint.X - paralaxPoint.X) / 2;
            float yTilt = (desiredParalaxPoint.Y - 100 - paralaxPoint.Y) / 2;
            paralaxCursorPoint.X -= (paralaxCursorPoint.X - this.Width / 2 + (xTilt)) / 240;
            paralaxCursorPoint.Y -= (paralaxCursorPoint.Y - this.Height / 2 + (yTilt)) / 240;

            //paralaxCursorPoint.X -= (paralaxCursorPoint.X - cursorPos.X) / 40;
            //paralaxCursorPoint.Y -= (paralaxCursorPoint.Y - cursorPos.Y) / 40;

            paralaxPoint.X -= (paralaxPoint.X - desiredParalaxPoint.X) / 40;
            paralaxPoint.Y -= (paralaxPoint.Y - desiredParalaxPoint.Y) / 40;

            cursorPos = PointToClient(Cursor.Position);
            determineNextColor();
            currentColor.BackColor = cursorColor;
            nextColor.BackColor = determineColor;
            foreach (Plane p in planes)
            {
                p.tick(surfaceLights);
            }

            foreach (PhysicsObject po in planes[playerPlaneDepth].physicsObjects)
            {
                if (po.id == "Player")
                {
                    po.Move(planes[playerPlaneDepth].collisionPolygons);
                    desiredParalaxPoint = new PointF(po.body.X + (po.body.Width / 2) + ((WSAD[2]) ? -300 : 0) + ((WSAD[3]) ? 300 : 0), po.body.Y + (po.body.Height / 2) + ((WSAD[0]) ? -300 : 0) + ((WSAD[1]) ? 300 : 0));

                    if (screenBounds.Count != 0)
                    {
                        //Now see if this paralaxPoint fits within the screen bounds
                        desiredParalaxPoint.X = ((desiredParalaxPoint.X - (this.Width / 2) < screenBounds[0].X) ? screenBounds[0].X + (this.Width / 2) : desiredParalaxPoint.X);
                        desiredParalaxPoint.X = ((desiredParalaxPoint.X + (this.Width / 2) > screenBounds[0].X + screenBounds[0].Width) ? screenBounds[0].X + screenBounds[0].Width - (this.Width / 2) : desiredParalaxPoint.X);
                        desiredParalaxPoint.Y = ((desiredParalaxPoint.Y - (this.Height / 2) < screenBounds[0].Y) ? screenBounds[0].Y + (this.Height / 2) : desiredParalaxPoint.Y);
                        desiredParalaxPoint.Y = ((desiredParalaxPoint.Y + (this.Height / 2) > screenBounds[0].Y + screenBounds[0].Height) ? screenBounds[0].Y + screenBounds[0].Height - (this.Height / 2) : desiredParalaxPoint.Y);

                    }
                }
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
            int moveSpeed = 8;
            switch (e.KeyCode)
            {
                case Keys.ShiftKey:
                    shiftPressed = true;
                    break;
                case Keys.ControlKey:
                    ctrlPressed = !ctrlPressed;
                    break;
                case Keys.C:
                    foreach (Plane pl in planes)
                    {
                        foreach (Asset a in pl.assets)
                        {
                            if (a.selected)
                            {
                                a.ColorFaces(cursorColor, (float)determineColor.R / (float)255);
                            }
                        }
                    }
                    break;
                case Keys.M:
                    selectionOption = (selectionOption == "Move") ? "Not Set" : "Move";
                    selectionPointOne = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                    break;
                case Keys.Enter:
                    selectionOption = "Not Set";
                    break;
                case Keys.V:
                    selectionOption = (selectionOption == "Scale") ? "Not Set" : "Scale";
                    selectionPointOne = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                    break;
                case Keys.F:
                    selectionOption = (selectionOption == "Rotate") ? "Not Set" : "Rotate";
                    selectionPointOne = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                    break;
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
                case Keys.Space:
                    if (points.Count > 2)
                    {
                        PointF[] ghostPoints = points.ToArray();
                        if (additionType == "Art")
                        {
                            planes[planeDepth].faces.Add(new Face(ghostPoints.ToList(), cursorPos, cursorColor));
                        }
                        if (additionType == "Collisions")
                        {
                            planes[planeDepth].collisionPolygons.Add(ghostPoints);
                        }
                        if (additionType == "Screen Bounds")
                        {
                            screenBounds.Clear();
                            float left, right;
                            left = right = points[0].X;
                            float up, down;
                            up = down = points[0].Y;
                            for (int p = 1; p < points.Count; p++)
                            {
                                left = (points[p].X < left) ? points[p].X : left;
                                right = (points[p].X > right) ? points[p].X : right;
                                up = (points[p].Y < up) ? points[p].Y : up;
                                down = (points[p].Y > down) ? points[p].Y : down;
                            }

                            screenBounds.Add(new RectangleF(left, up, right - left, down - up));
                        }
                        points.Clear();
                    }
                    else
                    {
                        if (airBorn == false)
                        {
                            jumpPressed = true;
                            airBorn = true;
                        }
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

                //Planes
                case Keys.Oemplus:
                    planes.Add(new Plane());
                    regionDepthCheck();
                    break;
                case Keys.Oemtilde:
                    planeDepth++;
                    planeDepth = (planeDepth > planes.Count - 1) ? 0 : planeDepth;
                    regionDepthCheck();
                    break;

                //Temporary Movement Keys
                case Keys.W:
                    WSAD[0] = paralax;
                    movementPoint.Y += (paralax ? 0 : -30);
                    break;
                case Keys.S:
                    WSAD[1] = paralax;
                    movementPoint.Y += (paralax ? 0 : 30);
                    break;
                case Keys.A:
                    WSAD[2] = paralax;
                    movementPoint.X += (paralax ? 0 : -30);
                    break;
                case Keys.D:
                    WSAD[3] = paralax;
                    movementPoint.X += (paralax ? 0 : 30);
                    break;
            }
        }

        private void loadLabel_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("Assets.xml");

            //Get the current asset, using a list so that if there is no asset we just have no items to work from in a foreach loop
            XmlNodeList loadAsset = doc.GetElementsByTagName("Asset" + currentAsset);

            foreach (XmlNode n in loadAsset)
            {
                List<Face> faces = new List<Face>();
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
                planes[planeDepth].assets.Add(new Asset(faces));
            }
        }

        private void LevelCreator_Paint(object sender, PaintEventArgs e)
        {
            float posPlaneDepth = planes.Count;
            float negPlaneDepth = 1;
            float negParalaxDifference = 1;
            float posParalaxDifference = 3 / (planes.Count + 1);
            foreach (Plane plane in planes)
            {
                posPlaneDepth--;
                negPlaneDepth++;
                //Fill the faces

                foreach (Asset a in plane.assets)
                {
                    foreach (Face f in a.faces)
                    {
                        PointF[] _points = f.points.ToArray();
                        if (paralax)
                        {
                            for (int p = 0; p < _points.Length; p++)
                            {
                                _points[p] = paralaxThisPoint(_points[p], posPlaneDepth + a.depthBoost);
                            }
                        }
                        else
                        {
                            for (int p = 0; p < _points.Length; p++)
                            {
                                _points[p].X -= movementPoint.X;
                                _points[p].Y -= movementPoint.Y;
                            }
                        }
                        Color color = f.initialColor;
                        if (lighting)
                        {
                            color = f.colorValue(plane.lights, posPlaneDepth / planes.Count, backgroundColor);
                        }
                        e.Graphics.FillPolygon(new SolidBrush(color), _points);
                        if (outline && plane == planes[planeDepth])
                        {
                            e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.Pink)), _points);
                        }
                        if (a.selected)
                        {
                            e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.White), 2), _points);
                        }
                    }
                }
                foreach (Face f in plane.faces)
                {
                    PointF[] _points = f.points.ToArray();
                    if (paralax)
                    {
                        for (int p = 0; p < _points.Length; p++)
                        {
                            _points[p] = paralaxThisPoint(_points[p], posPlaneDepth);
                        }
                    }
                    else
                    {
                        for (int p = 0; p < _points.Length; p++)
                        {
                            _points[p].X -= movementPoint.X;
                            _points[p].Y -= movementPoint.Y;
                        }
                    }
                    Color color = f.initialColor;
                    if (lighting)
                    {
                        color = f.colorValue(plane.lights, posPlaneDepth / planes.Count, backgroundColor);
                    }
                    e.Graphics.FillPolygon(new SolidBrush(color), _points);
                    if (outline && plane == planes[planeDepth])
                    {
                        e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.Pink)), _points);
                    }
                }

                foreach (PhysicsObject po in plane.physicsObjects)
                {
                    PointF[] _points = new PointF[4]
                    {
                        new PointF(po.body.X,po.body.Y ),
                        new PointF(po.body.X + po.body.Width,po.body.Y ),
                        new PointF(po.body.X + po.body.Width,po.body.Y + po.body.Height),
                        new PointF(po.body.X,po.body.Y + po.body.Height ),
                    };
                    if (paralax)
                    {
                        for (int p = 0; p < _points.Length; p++)
                        {
                            _points[p] = paralaxThisPoint(_points[p], posPlaneDepth);
                        }
                    }
                    else
                    {
                        for (int p = 0; p < _points.Length; p++)
                        {
                            _points[p].X -= movementPoint.X;
                            _points[p].Y -= movementPoint.Y;
                        }
                    }
                    Color color = Color.LimeGreen;
                    e.Graphics.FillPolygon(new SolidBrush(color), _points);
                }
            }
            #region Show Collision Lines

            foreach (PointF[] poly in planes[planeDepth].collisionPolygons)
            {
                PointF[] _points = (PointF[])poly.Clone();
                if (paralax)
                {
                    for (int p = 0; p < _points.Length; p++)
                    {
                        _points[p] = paralaxThisPoint(_points[p], posPlaneDepth);
                    }
                }
                else
                {
                    for (int p = 0; p < _points.Length; p++)
                    {
                        _points[p].X -= movementPoint.X;
                        _points[p].Y -= movementPoint.Y;
                    }
                }
                e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.Lime)), _points);
            }

            foreach (RectangleF bounds in screenBounds)
            {
                PointF[] _points = new PointF[4]
                {
                        new PointF(bounds.X,bounds.Y ),
                        new PointF(bounds.X + bounds.Width,bounds.Y ),
                        new PointF(bounds.X + bounds.Width,bounds.Y + bounds.Height),
                        new PointF(bounds.X,bounds.Y + bounds.Height ),
                };
                if (paralax)
                {
                    for (int p = 0; p < _points.Length; p++)
                    {
                        _points[p] = paralaxThisPoint(_points[p], posPlaneDepth);
                    }
                }
                else
                {
                    for (int p = 0; p < _points.Length; p++)
                    {
                        _points[p].X -= movementPoint.X;
                        _points[p].Y -= movementPoint.Y;
                    }
                }

                e.Graphics.DrawPolygon(new Pen(new SolidBrush(Color.Red)), _points);
            }
            #endregion

            //Show the current Points that are NOT faces YET
            SolidBrush brush = new SolidBrush(Color.FromArgb(205, 255, 0, 255));
            if (points.Count > 2)
            {
                PointF[] _points = points.ToArray();
                for (int p = 0; p < _points.Length; p++)
                {
                    _points[p].X -= movementPoint.X;
                    _points[p].Y -= movementPoint.Y;
                }
                e.Graphics.FillPolygon(brush, _points);
            }
            foreach (PointF p in points)
            {
                e.Graphics.FillEllipse(brush, new Rectangle((int)(p.X - movementPoint.X - 4), (int)(p.Y - movementPoint.Y - 4), 8, 8));
            }

            //show the centerpoint of paralax       
            PointF paralaxGhost = new PointF(paralaxPoint.X, paralaxPoint.Y);

            paralaxGhost.X -= (paralaxPoint.X - this.Width / 2);
            paralaxGhost.Y -= (paralaxPoint.Y - this.Height / 2);

            e.Graphics.FillEllipse(new SolidBrush(Color.Pink), new Rectangle((int)paralaxGhost.X - 4, (int)paralaxGhost.Y - 4, 8, 8));
            PointF ghostCursorPoint = cursorPos;
            if (paralax)
            {
                ghostCursorPoint = paralaxThisPoint(cursorPos, planeDepth);
                ghostCursorPoint = paralaxThisPoint(cursorPos, planeDepth);
            }
            e.Graphics.FillEllipse(new SolidBrush(Color.DarkGoldenrod), new Rectangle((int)ghostCursorPoint.X - 3, (int)ghostCursorPoint.Y - 3, 8, 8));

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
            currentPlane.Text = "Current Plane:" + planeDepth;
            planeCount.Text = "Max Plane:" + (planes.Count - 1);
            describeThis();
        }
        void additionTypeCheck()
        {
            regionArt.BackColor = (additionType == "Art") ? Color.White : Color.LightGray;
            regionCollisions.BackColor = (additionType == "Collisions") ? Color.White : Color.LightGray;
            label4.BackColor = (additionType == "Screen Bounds") ? Color.White : Color.LightGray;
            describeThis();
        }

        void describeThis()
        {
            describeCurrent.Text = $"Changing {additionType} in {regionDepth} with {mode}";
        }

        private void LevelCreator_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void LevelCreator_MouseUp(object sender, MouseEventArgs e)
        {
            switch (additionType)
            {
                case "Art":
                case "Collisions":
                case "Screen Bounds":
                    switch (mode)
                    {
                        case "RectangleMode":
                            if (e.Button == MouseButtons.Left)
                            { cornerOne = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y); }
                            else
                            {
                                points.Clear();
                                cornerTwo = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                                points.Add(cornerOne);
                                points.Add(new PointF(cornerOne.X, cornerTwo.Y));
                                points.Add(cornerTwo);
                                points.Add(new PointF(cornerTwo.X, cornerOne.Y));
                            }

                            break;
                        case "PolygonMode":
                            points.Add(new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y));
                            break;
                        case "SelectMode":
                            foreach (Asset a in planes[planeDepth].assets)
                            {
                                PointF _point = new PointF(cursorPos.X + movementPoint.X, cursorPos.Y + movementPoint.Y);
                                if (paralax) { _point = paralaxThisPoint(cursorPos, planeDepth); }
                                a.SelectAsset(_point);
                            }
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

            //Add the screen bounds to the level
            foreach (RectangleF bounds in screenBounds)
            {
                XmlElement sb = doc.CreateElement("ScreenBounds");
                sb.SetAttribute("x", "" + bounds.X);
                sb.SetAttribute("y", "" + bounds.Y);
                sb.SetAttribute("width", "" + bounds.Width);
                sb.SetAttribute("height", "" + bounds.Height);

                newLevel.AppendChild(sb);
            }

            newLevel.SetAttribute("PlaneCount", "" + planes.Count);
            //Add the faces to the levels planes
            foreach (Plane pl in planes)
            {
                XmlElement plane = doc.CreateElement("Plane");
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
                foreach (Asset a in pl.assets)
                {
                    XmlElement asset = doc.CreateElement("Asset");

                    foreach (Face f in a.faces)
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

                        asset.AppendChild(face);
                    }
                    plane.AppendChild(asset);
                }
                foreach (PointF[] c in pl.collisionPolygons)
                {
                    XmlElement polygon = doc.CreateElement("CollisionPolygon");

                    //Add the points of each face to the face
                    foreach (PointF p in c)
                    {
                        XmlElement point = doc.CreateElement("PointF");
                        point.SetAttribute("x", "" + p.X);
                        point.SetAttribute("y", "" + p.Y);
                        polygon.AppendChild(point);
                    }
                    plane.AppendChild(polygon);
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
                foreach (PhysicsObject po in pl.physicsObjects)
                {
                    XmlElement physicsObject = doc.CreateElement("PhysicsObject");
                    physicsObject.SetAttribute("x", "" + po.body.X);
                    physicsObject.SetAttribute("y", "" + po.body.Y);
                    physicsObject.SetAttribute("width", "" + po.body.Width);
                    physicsObject.SetAttribute("height", "" + po.body.Height);
                    physicsObject.SetAttribute("id", "" + po.id);
                    plane.AppendChild(physicsObject);
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
                pl.collisionPolygons.Clear();
            }

            XmlDocument doc = new XmlDocument();
            doc.Load("Levels.xml");

            //Get the current level, using a list so that if there is no level we just have no items to work from in a foreach loop
            XmlNodeList loadAsset = doc.GetElementsByTagName("Level" + currentAsset);

            planes.Clear();
            foreach (XmlNode level in loadAsset)
            {
                foreach (XmlNode sb in level.SelectNodes("ScreenBounds"))
                {
                    screenBounds.Clear();
                    float _x = (float)Convert.ToDouble(sb.Attributes["x"].Value);
                    float _y = (float)Convert.ToDouble(sb.Attributes["y"].Value);
                    float _width = (float)Convert.ToDouble(sb.Attributes["width"].Value);
                    float _height = (float)Convert.ToDouble(sb.Attributes["height"].Value);
                    screenBounds.Add(new RectangleF(_x, _y, _width, _height));
                }
                foreach (XmlNode pl in level.SelectNodes("Plane"))
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
                    foreach (XmlNode a in pl.SelectNodes("Asset"))
                    {
                        List<Face> faces = new List<Face>();
                        foreach (XmlNode f in a.SelectNodes("Face"))
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
                        plane.assets.Add(new Asset(faces));
                    }
                    foreach (XmlNode f in pl.SelectNodes("CollisionPolygon"))
                    {
                        //For each point inside the Polygon
                        List<PointF> collisionPolygon = new List<PointF>();
                        foreach (XmlNode p in f.ChildNodes)
                        {
                            float x = (float)Convert.ToDouble(p.Attributes["x"].Value);
                            float y = (float)Convert.ToDouble(p.Attributes["y"].Value);

                            collisionPolygon.Add(new PointF(x, y));
                        }

                        plane.collisionPolygons.Add(collisionPolygon.ToArray());
                    }
                    foreach (XmlNode l in pl.SelectNodes("Light"))
                    {
                        Color color = Color.FromArgb(Convert.ToInt16(l.Attributes["a"].Value), Convert.ToInt16(l.Attributes["r"].Value), Convert.ToInt16(l.Attributes["g"].Value), Convert.ToInt16(l.Attributes["b"].Value));
                        PointF position = new PointF((float)Convert.ToDouble(l.Attributes["x"].Value), (float)Convert.ToDouble(l.Attributes["y"].Value));
                        plane.primaryLights.Add(new Light(color, position));
                    }
                    foreach (XmlNode po in pl.SelectNodes("PhysicsObject"))
                    {
                        Rectangle ghostRect = new Rectangle();

                        ghostRect.X = Convert.ToInt32(po.Attributes["x"].Value);
                        ghostRect.Y = Convert.ToInt32(po.Attributes["y"].Value);
                        ghostRect.Width = Convert.ToInt32(po.Attributes["width"].Value);
                        ghostRect.Height = Convert.ToInt32(po.Attributes["height"].Value);

                        string id = po.Attributes["id"].Value;
                        if (id == "Player")
                        {
                            playerPlaneDepth = planes.Count();
                        }
                        plane.physicsObjects.Add(new PhysicsObject(ghostRect, id));
                    }
                    planes.Add(plane);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            paralax = !paralax;
            label2.BackColor = (paralax) ? Color.White : Color.LightGray;
        }

        private void LevelCreator_Load(object sender, EventArgs e)
        {

        }

        private void outlineLable_Click(object sender, EventArgs e)
        {
            outline = !outline;
            outlineLable.BackColor = (outline) ? Color.White : Color.LightGray;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            backgroundColor = cursorColor;
        }

        private void LevelCreator_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                //Temporary Movement Keys
                case Keys.W:
                    WSAD[0] = false;
                    break;
                case Keys.S:
                    WSAD[1] = false;
                    break;
                case Keys.A:
                    WSAD[2] = false;
                    break;
                case Keys.D:
                    WSAD[3] = false;
                    break;
                case Keys.ShiftKey:
                    shiftPressed = false;
                    break;
                case Keys.X:
                    foreach (PhysicsObject po in planes[playerPlaneDepth].physicsObjects)
                    {
                        if (po.id == "Player")
                        {
                            po.body.Location = new Point((int)(cursorPos.X + movementPoint.X), (int)(cursorPos.Y + movementPoint.Y));
                        }
                    }
                    break;
                case Keys.Space:
                    if (points.Count < 3)
                    {
                        ySpeed = (ySpeed > 5) ? ySpeed : 5;
                    }
                    break;
                case Keys.Escape:
                    foreach (Plane pl in planes)
                    {
                        foreach (Asset a in planes[planeDepth].assets)
                        {
                            a.selected = false;
                        }
                    }
                    break;
                case Keys.C: //Color
                    foreach (Plane pl in planes)
                    {
                        foreach (Asset a in pl.assets)
                        {
                            if (a.selected)
                            {
                                a.ColorFaces(cursorColor, determineColor.A / 255);
                            }
                        }
                    }
                    break;
                case Keys.Delete: //Delete
                    foreach (Plane pl in planes)
                    {
                        List<Asset> removeThese = new List<Asset>();
                        foreach (Asset a in pl.assets)
                        {
                            if (a.selected)
                            {
                                removeThese.Add(a);
                            }
                        }
                        for (int r = 0; r < removeThese.Count; r++)
                        {
                            pl.assets.Remove(removeThese[r]);
                        }
                    }
                    break;
                case Keys.V:
                case Keys.F:
                    selectionOption = "Not Selected";
                    break;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            additionType = "Screen Bounds";
            additionTypeCheck();
        }

        PointF paralaxThisPoint(PointF initialPoint, float depth)
        {
            PointF newPoint = initialPoint;

            //Tilt the camera depending on the cursors location
            float xDif = (paralaxCursorPoint.X - this.Width / 2);
            float yDif = (paralaxCursorPoint.Y - this.Height / 2);
            newPoint.X -= xDif + ((depth - 0) * xDif / 4);
            newPoint.Y -= yDif + ((depth - 0) * yDif / 4);

            //Move the camera to follow the player, use a bit of paralaxing
            newPoint.X -= (paralaxPoint.X - this.Width / 2) / (depth + 1);
            newPoint.Y -= (paralaxPoint.Y - this.Height / 2) / (depth + 1);

            return newPoint;
        }
    }
}
