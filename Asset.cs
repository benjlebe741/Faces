using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faces
{
    public class Asset
    {
        public bool selected = false;
        public List<Face> faces;
        public float scale = 1;
        public float rotation = 0;
        public float depthBoost = 0; //Range from 0 to 1 for in between plane depths. 

        public Asset(List<Face> _faces)
        {
            faces = _faces;
        }

        public void SelectAsset(PointF selectionPoint)
        {
            bool _selected = false;
            Rectangle selectionRect = new Rectangle((int)selectionPoint.X - 5, (int)selectionPoint.Y - 5, 10, 10);
            foreach (Face face in faces)
            {
                if (_selected) { break; }
                foreach (PointF p in face.points)
                {
                    if (selectionRect.Contains(new Point((int)p.X, (int)p.Y)))
                    {
                        _selected = true;
                    }
                }
            }
            selected = (_selected) ? !selected : selected;
        }

        public void ScaleFaces(PointF aboutPoint, PointF toPoint, float scaleFactor, float uniformScaling)
        {
            foreach (Face face in faces)
            {
                for (int p = 0; p < face.points.Count; p++)
                {
                    face.points[p] = ScalePoint(aboutPoint, scaleFactor, face.points[p], uniformScaling);
                }
            }
        }

        public void RotateFaces(PointF aboutPoint, float angle)
        {
            foreach (Face face in faces)
            {
                for (int p = 0; p < face.points.Count; p++)
                {
                    face.points[p] = RotatePoint(aboutPoint, angle, face.points[p]);
                }
            }
        }

        PointF RotatePoint(PointF pivot, double angleInRads, PointF p)
        {
            float s = (float)Math.Sin(angleInRads);
            float c = (float)Math.Cos(angleInRads);

            // translate point back to origin:
            p.X -= pivot.X;
            p.Y -= pivot.Y;

            // rotate point
            float xnew = p.X * c - p.Y * s;
            float ynew = p.X * s + p.Y * c;

            // translate point back:
            p.X = xnew + pivot.X;
            p.Y = ynew + pivot.Y;

            return p;
        }

        PointF ScalePoint(PointF pivot, float scaleFactor, PointF p, float uniformity)
        {
            p.X = (p.X - pivot.X) * (scaleFactor + (scaleFactor * uniformity)) + pivot.X;
            p.Y = (p.Y - pivot.Y) * (scaleFactor - (scaleFactor * uniformity)) + pivot.Y;

            return p;
        }

        public void TranslateFaces(PointF aboutPoint, PointF toPoint)
        {
            float xDif = aboutPoint.X - toPoint.X;
            float yDif = aboutPoint.Y - toPoint.Y;

            foreach (Face face in faces)
            {
                for (int p = 0; p < face.points.Count; p++)
                {
                    float newX = face.points[p].X - xDif;
                    float newY = face.points[p].Y - yDif;

                    face.points[p] = new PointF(newX, newY);
                }
            }
        }

        public void ColorFaces(Color recolor, float percentage)
        {
            foreach (Face f in faces)
            {
                float r = (percentage * recolor.R) + ((1 - percentage) * f.initialColor.R);
                float g = (percentage * recolor.G) + ((1 - percentage) * f.initialColor.G);
                float b = (percentage * recolor.B) + ((1 - percentage) * f.initialColor.B);
                r = ((r < 0) ? 0 : r);
                r = ((r > 255) ? 255 : r);
                g = ((g < 0) ? 0 : g);
                g = ((g > 255) ? 255 : g);
                b = ((b < 0) ? 0 : b);
                b = ((b > 255) ? 255 : b);

                f.initialColor = Color.FromArgb((int)r, (int)g, (int)b);
            }
        }
    }
}
