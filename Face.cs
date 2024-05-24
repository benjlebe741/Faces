using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #endregion

        #region Construction
        //Creating a face with a known angle:
        public Face(List<PointF> _points, float _horizontalTilt, float _verticalTilt)
        {
            points = _points;
            horizontalTilt = _horizontalTilt;
            verticalTilt = _verticalTilt;
            setReceiver();

            tiltedReciever = new PointF(receiver.X + horizontalTilt, receiver.Y + verticalTilt);
        }

        //Creating a face with an angle from a center point, to a point:
        public Face(List<PointF> _points, PointF lightPoint)
        {
            points = _points;
            setReceiver();
            tiltedReciever = lightPoint;

            horizontalTilt = lightPoint.X - receiver.X;
            verticalTilt = lightPoint.Y - receiver.Y;
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
        public float lightValue(List<PointF> lights)
        {
            if (receiver == tiltedReciever) { return 0; }
            float maximumBrightness = 0;

            //For each point in the list, how bright would the face be? 
            foreach (PointF l in lights)
            { }


            //Take only the brightest value, and return it.
            return maximumBrightness;
        }
        #endregion

    }

}
