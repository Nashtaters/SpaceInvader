using System;
using SpaceInvader.Casting;

namespace SpaceInvader
{
    public class Alien : Actor
    {
        public Alien(int x, int y)
        {
            SetVelocity(new Point(1, 0));
            SetPosition(new Point(x, y));
            SetWidth(Constants.ALIEN_WIDTH);
            SetHeight(Constants.ALIEN_HEIGHT);
        }
    }
}