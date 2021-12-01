using System;
using SpaceInvader.Casting;

namespace SpaceInvader
{
    public class SpaceCraft : Actor
    {
        public SpaceCraft(int x, int y)
        {
            SetVelocity(new Point(1, 0));
            SetPosition(new Point(x, y));
            SetWidth(Constants.SPACECRAFT_WIDTH);
            SetHeight(Constants.SPACECRAFT_HEIGHT);
            SetImage(Constants.IMAGE_SPACECRAFT);
            GetImage();
        }
    }
}