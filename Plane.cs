using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Faces
{
    public class Plane
    {
        //Holds all the artwork & Assets
        public List<Face> faces = new List<Face>();
        //Holds all the collision lines
        public List<PointF[]> collisionPolygons = new List<PointF[]>();
        public List<PhysicsObject> physicsObjects= new List<PhysicsObject>();

        //Holds all the lights
        public List<Light> primaryLights = new List<Light>();
        public List<Light> lights = new List<Light>();
        List<Light> secondaryLights = new List<Light>();
        List<Light> tertiaryLights = new List<Light>();

        public void tick(bool surfaceLights)
        {
            #region Surface Lights
            lights.Clear();
            lights.AddRange(primaryLights);
            if (surfaceLights)
            {

                secondaryLights.Clear();
                tertiaryLights.Clear();
                foreach (Face f in faces)
                {
                    Color color = f.colorValue(lights, 0, Color.Black);
                    secondaryLights.Add(new Light(color, new PointF(f.tiltedReciever.X + f.horizontalTilt, f.tiltedReciever.Y + f.verticalTilt)));
                }
                lights.AddRange(secondaryLights);

                foreach (Face f in faces)
                {
                    Color color = f.colorValue(lights, 0, Color.Black);
                    tertiaryLights.Add(new Light(color, new PointF(f.tiltedReciever.X + f.horizontalTilt, f.tiltedReciever.Y + f.verticalTilt)));
                }
                lights.AddRange(tertiaryLights);
            }
            #endregion
        }
    }
}
