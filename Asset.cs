using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void ScaleFaces(PointF aboutPoint, PointF toPoint)
        {

        }

        public void RotateFaces(PointF aboutPoint, PointF toPoint)
        {

        }

        public void ColorFaces(Color recolor, float percentage)
        {

        }
    }
}
