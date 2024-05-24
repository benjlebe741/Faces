﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faces
{
    public class Light
    {
        public Color color;
        public PointF position;

        public Light(Color _color, PointF _position)        {
            color = _color;
            position = _position;
        }

    }
}
