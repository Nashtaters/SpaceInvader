using System;
using SpaceInvader.Casting;

namespace SpaceInvader
{
    public class Laser : Actor
    {
        private const int LASER_V_X = 0;
        private const int LASER_V_Y = -50;
        private bool _visible = true;
        public Laser(int x, int y)
        {
            SetVelocity(new Point(LASER_V_X, LASER_V_Y));
            SetPosition(new Point(x, y));
            SetWidth(Constants.LASER_WIDTH);
            SetHeight(Constants.LASER_HEIGHT);
            SetImage(Constants.IMAGE_LASER);
            GetImage();
        }

        public void SetVisible(bool isVisible)
        {
            _visible = isVisible;
            if (_visible == false)
            {
                SetVelocity(new Point(0, 0));
                SetPosition(new Point(Constants.X_OFF_SCREEN, Constants.Y_OFF_SCREEN));
            }
        }

        public bool IsVisible()
        {
            return _visible;
        }
    }
}