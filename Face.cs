using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faces
{
    public class Face
    {
        #region Global Variables
        //The points that make up the face
        public List<PointF> points = new List<PointF>();

        //A tilt of 0 faces out, a negative or positive tilt faces to either side
        public float horizontalTilt, verticalTilt;

        //The point which recieves light
        public PointF receiver;
        public PointF tiltedReciever;

        public Color initialColor;
        #endregion

        #region Construction
        //Creating a face with a known angle:
        public Face(List<PointF> _points, float _horizontalTilt, float _verticalTilt, Color _initialColor)
        {
            points = _points;
            horizontalTilt = _horizontalTilt;
            verticalTilt = _verticalTilt;
            setReceiver();

            tiltedReciever = new PointF(receiver.X + horizontalTilt, receiver.Y + verticalTilt);
            simplifyTiltedReciever();
            initialColor = _initialColor;
        }

        //Creating a face with an angle from a center point, to a point:
        public Face(List<PointF> _points, PointF lightPoint, Color _initialColor)
        {
            points = _points;
            setReceiver();
            tiltedReciever = lightPoint;

            horizontalTilt = lightPoint.X - receiver.X;
            verticalTilt = lightPoint.Y - receiver.Y;
            simplifyTiltedReciever();
            initialColor = _initialColor;
        }
        void setReceiver()
        {
            receiver = new PointF();
            receiver.X = 0;
            receiver.Y = 0;

            foreach (PointF p in points)
            {
                receiver.X += p.X;
                receiver.Y += p.Y;
            }

            receiver.X /= points.Count;
            receiver.Y /= points.Count;
        }

        void simplifyTiltedReciever()
        {
            //Moves the point as close into the center of the face as possible!
            float deltaX = tiltedReciever.X - receiver.X;
            float deltaY = tiltedReciever.Y - receiver.Y;

            float largerDelta = (deltaX < deltaY) ? deltaX : deltaY;
            largerDelta = (largerDelta == 0) ? (float)0.01 : largerDelta;

            deltaX /= Math.Abs(largerDelta);
            deltaY /= Math.Abs(largerDelta);

            tiltedReciever.X = receiver.X + deltaX;
            tiltedReciever.Y = receiver.Y + deltaY;

            horizontalTilt = receiver.X - tiltedReciever.X;
            verticalTilt = receiver.Y - tiltedReciever.Y;
        }
        #endregion

        #region Methods
        public float lightValue(PointF light)
        {
            //For each point in the list, how bright would the face be? 
            double lightRecieverDistance = Math.Sqrt(Math.Pow((light.X - receiver.X), 2) + Math.Pow((light.Y - receiver.Y), 2));
            double lightTiltDistance = Math.Sqrt(Math.Pow((light.X - tiltedReciever.X), 2) + Math.Pow((light.Y - tiltedReciever.Y), 2));
            double recieverTiltDistance = Math.Sqrt(Math.Pow((receiver.X - tiltedReciever.X), 2) + Math.Pow((receiver.Y - tiltedReciever.Y), 2));

            recieverTiltDistance = (recieverTiltDistance != 0) ? recieverTiltDistance : (float)0.001;

            return (float)((lightRecieverDistance - lightTiltDistance) / recieverTiltDistance);
        }
        public Color colorValue(List<Light> lights)
        {
            if (lights.Count <= 0) { return Color.Black; }

            List<int> rList = new List<int>();
            List<int> gList = new List<int>();
            List<int> bList = new List<int>();

            //For each point in the list, how bright would the face be? 
            foreach (Light l in lights)
            {
                float lightVal = lightValue(l.position);

                int r = (l.color.R / 2 + initialColor.R / 2) - (255 - l.color.R);
                int g = (l.color.G / 2 + initialColor.G / 2) - (255 - l.color.G);
                int b = (l.color.B / 2 + initialColor.B / 2 ) - (255 - l.color.B); 

                //R
                int newR = (int)(r / 2 * lightVal);
                newR += (r / 2);

                newR = (newR > 255) ? 255 : newR;
                newR = (newR < 0) ? 0 : newR;

                rList.Add(newR);

                //G
                int newG = (int)(g / 2 * lightVal);
                newG += (g / 2);

                newG = (newG > 255) ? 255 : newG;
                newG = (newG < 0) ? 0 : newG;

                gList.Add(newG);

                //B
                int newB = (int)(b / 2 * lightVal);
                newB += (b / 2);

                newB = (newB > 255) ? 255 : newB;
                newB = (newB < 0) ? 0 : newB;

                bList.Add(newB);
            }

            rList.Sort();
            gList.Sort();
            bList.Sort();

            rList.Reverse();
            gList.Reverse();
            bList.Reverse();

            //Take only the brightest value, and return it.
            return Color.FromArgb(255,rList[0], gList[0], bList[0]);
        }
        #endregion

    }

}
