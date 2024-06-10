using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace Faces
{
    public class PhysicsObject
    {
        public Rectangle body, pastBody;
        public string id;

        int normalX, normalY;

        //Jumping
        const int MAX_Y_SPEED = 16;
        int time = 0;
        double impulse = -35;
        double accelleration = 1.8;
        double deceleration = 1;

        public PhysicsObject(Rectangle _body, string _id)
        {
            body = pastBody = _body;
            id = _id;
        }

        public void Move(List<PointF[]> polygons)
        {
            LevelCreator.airBorn = true;
            time++;
            pastBody.Location = body.Location;

            normalX = normalY = 0;

            #region Jumping
            if (LevelCreator.jumpPressed)
            {
                LevelCreator.ySpeed = impulse;
                LevelCreator.jumpPressed = false;
            }
            if (time % deceleration == 0)
            {
                LevelCreator.ySpeed = (LevelCreator.ySpeed + accelleration > MAX_Y_SPEED) ? MAX_Y_SPEED : LevelCreator.ySpeed + accelleration;
            }
            body.Y += (int)LevelCreator.ySpeed;
            #endregion

            collisionChecks(polygons);

            int speed = 8;
            body.Y += (LevelCreator.WSAD[0]) ? -speed : 0;
            body.Y += (LevelCreator.WSAD[1]) ? speed : 0;
            body.X += (LevelCreator.WSAD[2]) ? -speed : 0;
            body.X += (LevelCreator.WSAD[3]) ? speed : 0;


            int xChange = pastBody.X - body.X;
            int yChange = pastBody.Y - body.Y;

            collisionChecks(polygons);

            //NOW ADD THE NORMAL FORCE
            pastBody = body;

            normalX /= (normalX != 0) ? Math.Abs(normalX) : 1;
            normalY /= (normalY != 0) ? Math.Abs(normalY) : 1;

            if (xChange == 0)
            {
                body.X += normalX;
            }
            if (yChange != 0)
            {
                body.Y += normalY;
            }
            collisionChecks(polygons);
        }

        void collisionChecks(List<PointF[]> polygons)
        {
            float deltaX = (pastBody.X - body.X);
            float deltaY = (pastBody.Y - body.Y);

            double xDirectionChange = (deltaX == 0) ? 0 : (Math.Abs(deltaX) / deltaX);
            double yDirectionChange = (deltaY == 0) ? 0 : (Math.Abs(deltaY) / deltaY);

            bool intersection = false;

            foreach (PointF[] polygon in polygons)
            {
                for (int p = 0; p < polygon.Length; p++)
                {
                    Point pOne = new Point((int)polygon[p].X, (int)polygon[p].Y);
                    Point pTwo = (p + 1 >= polygon.Length) ? new Point((int)polygon[0].X, (int)polygon[0].Y) : new Point((int)polygon[p + 1].X, (int)polygon[p + 1].Y);
                    if (lineIntersects(pOne, pTwo, body, pastBody, false)) //If there is an intersection
                    {
                        intersection = true;
                        #region new stuff

                        Point leftMost = (pOne.X < pTwo.X) ? pOne : pTwo;
                        Point rightMost = (leftMost == pTwo) ? pOne : pTwo;
                        Point upMost = (pOne.Y < pTwo.Y) ? pOne : pTwo;
                        Point downMost = (upMost == pTwo) ? pOne : pTwo;


                        bool increasingSlope = (leftMost.Y < rightMost.Y) ? true : false;

                        float deltaLineX = ((pTwo.X - pOne.X) == 0) ? ((pTwo.X - pOne.X) + (float)0.00001) : (pTwo.X - pOne.X);
                        float slope = (pTwo.Y - pOne.Y) / deltaLineX;

                        float projectedPreviousX = -(((pOne.Y - (pastBody.Y + (pastBody.Height / 2))) / slope) - pOne.X);
                        float sideOfLine = projectedPreviousX - (pastBody.X + (pastBody.Width / 2));

                        int slopeX = 0;
                        int slopeY = 0;

                        int fn = 1;
                        if (!increasingSlope)
                        {
                            slopeX = (sideOfLine > 1) ? -fn : fn;
                            slopeY = (sideOfLine > 1) ? -fn : fn;

                            if (sideOfLine > 1)
                            {
                                LevelCreator.airBorn = false;
                            }
                        }
                        else
                        {
                            slopeX = (sideOfLine > 1) ? -fn : fn;
                            slopeY = (sideOfLine > 1) ? fn : -fn;

                            if (sideOfLine < 1)
                            {
                                LevelCreator.airBorn = false;
                            }

                        }

                        normalX += slopeX;
                        normalY += slopeY;


                        if (xDirectionChange != slopeX)
                        { xDirectionChange = 0; }
                        if (yDirectionChange != slopeY)
                        { yDirectionChange = 0; }
                        #endregion
                    }
                }
            }

            int count = (int)((Math.Abs(deltaX) > Math.Abs(deltaY)) ? Math.Abs(deltaX) : Math.Abs(deltaY));
            //If no change can be made, go to previous position
            if (xDirectionChange == 0 && yDirectionChange == 0) { body.Location = pastBody.Location; intersection = false; }
            //Otherwise gradually move the player back towards their previous position until they reach it
            while (intersection)
            {
                count--;
                if (count <= 0)
                {
                    body.Location = pastBody.Location;
                    break;
                }
                intersection = false;

                body.X += (int)xDirectionChange;
                body.Y += (int)yDirectionChange;
                foreach (PointF[] polygon in polygons)
                {
                    for (int p = 0; p < polygon.Length; p++)
                    {
                        Point pOne = new Point((int)polygon[p].X, (int)polygon[p].Y);
                        PointF pTwoTemp = (p + 1 >= polygon.Length) ? polygon[0] : polygon[p + 1];
                        Point pTwo = new Point((int)(pTwoTemp.X), (int)(pTwoTemp.Y));

                        if (lineIntersects(pOne, pTwo, body, pastBody, false)) //If there is an intersection
                        {
                            intersection = true;
                        }
                    }
                }
            }
        }


        bool lineIntersects(Point _pOne, Point _pTwo, Rectangle _rect, Rectangle _pastRect, bool move)
        {
            if (_rect.Contains(_pOne) || _rect.Contains(_pTwo))
            {
                return true;
            }

            if (_pOne.X == _pTwo.X)
            {
                _pOne.X += 1;
            }
            if (_pOne.Y == _pTwo.Y)
            {
                _pOne.Y += 1;
            }


            Point leftMost = (_pOne.X < _pTwo.X) ? _pOne : _pTwo;
            Point rightMost = (leftMost == _pTwo) ? _pOne : _pTwo;
            Point upMost = (_pOne.Y < _pTwo.Y) ? _pOne : _pTwo;
            Point downMost = (upMost == _pTwo) ? _pOne : _pTwo;


            //Are we to the left or right or above or below the line?
            if (_rect.Right < leftMost.X || _rect.X > rightMost.X || _rect.Bottom < upMost.Y || _rect.Y > downMost.Y)
            { return false; }


            bool increasingSlope = (leftMost.Y < rightMost.Y) ? true : false;

            //Find what points are inside the line-to-be-checked's rectangle, we can also narrow down the points to be checked based on slope
            List<Point> rectCorners;

            float deltaX = ((_pTwo.X - _pOne.X) == 0) ? ((_pTwo.X - _pOne.X) + (float)0.00001) : (_pTwo.X - _pOne.X);
            float slope = (_pTwo.Y - _pOne.Y) / deltaX;

            float projectedPreviousX = -(((_pOne.Y - (pastBody.Y + (pastBody.Height / 2))) / slope) - _pOne.X);
            float sideOfLine = projectedPreviousX - (pastBody.X + (pastBody.Width / 2));

            if (!increasingSlope)
            {
                //Bottom Right or Top Left
                Point ghostPoint = (sideOfLine > 1) ? new Point(_rect.X + _rect.Width - 1, _rect.Y + _rect.Height - 1) : new Point(_rect.X, _rect.Y);

                rectCorners = new List<Point>
                {
                    ghostPoint,
                };
            }
            else
            {
                //Top Right or Bottom Left
                Point ghostPoint = (sideOfLine > 1) ? new Point(_rect.X + _rect.Width - 1, _rect.Y) : new Point(_rect.X, _rect.Y + _rect.Height - 1);

                rectCorners = new List<Point>
                {
                    ghostPoint,
                };
            }





            for (int i = 0; i < rectCorners.Count; i++)
            {
                //Project this point onto the line-to-be-checked, both using the points x and y coord
                int x = rectCorners[i].X;
                int y = rectCorners[i].Y;
                //Rearrange the line equation with those x and y coordinates as one of the unknowns, get this new point
                Point subbedInX, subbedInY;

                float newY = -((slope * (_pOne.X - x)) - _pOne.Y);
                float newX = -(((_pOne.Y - y) / slope) - _pOne.X);

                subbedInX = new Point(x, (int)newY);
                subbedInY = new Point((int)newX, y);


                //(Does this projected point exist inside the inputed rectangle) ? Intersection : Continue
                if (_rect.Contains(subbedInX) || body.Contains(subbedInY))
                {
                    int fn = 3;
                    if (!increasingSlope && move)
                    {
                        body.X += (sideOfLine > 1) ? -fn : fn;
                        body.Y += (sideOfLine > 1) ? -fn : fn;
                    }
                    else if (move)
                    {
                        body.X += (sideOfLine > 1) ? -fn : fn;
                        body.Y += (sideOfLine > 1) ? fn : -fn;
                    }
                    return true;

                }
            }

            return false;
        }
    }
}
