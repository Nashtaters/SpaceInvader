using System;
using SpaceInvader.Casting;

namespace SpaceInvader
{
    public class Laser : Actor
    {
        public Laser(int x, int y)
        {
            SetVelocity(new Point(0, -5));
            SetPosition(new Point(x, y));
            SetWidth(Constants.LASER_WIDTH);
            SetHeight(Constants.LASER_HEIGHT);
            SetImage(Constants.IMAGE_LASER);
            GetImage();
        }
    }
}