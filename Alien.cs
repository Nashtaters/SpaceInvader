using System;
using SpaceInvader.Casting;

namespace SpaceInvader
{
    public class Alien : Actor
    {
        private const int ALIEN_V_X = 1;
        private const int ALIEN_V_Y = 0;
        
        public Alien(int x, int y)
        {
            SetVelocity(new Point(ALIEN_V_X, ALIEN_V_Y));
            SetPosition(new Point(x, y));
            SetWidth(Constants.ALIEN_WIDTH);
            SetHeight(Constants.ALIEN_HEIGHT);
            SetImage(Constants.IMAGE_AIEN);
            GetImage();
        }
    }
}