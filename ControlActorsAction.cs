using System;
using System.Collections.Generic;
using SpaceInvader.Casting;
using SpaceInvader.Services;

namespace SpaceInvader
{
    public class ControlActorsAction : Action
    {
        private PhysicsService _physics = new PhysicsService();
        private InputService _input = new InputService();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            Actor spaceCraft = cast["spaceCraft"][0];
            if (_input.IsLeftPressed())
            {
                spaceCraft.SetVelocity(new Point(Constants.SPACECRAFT_SPEED * -1, 0));
            }
            else if (_input.IsRightPressed())
            {
                spaceCraft.SetVelocity(new Point(Constants.SPACECRAFT_SPEED, 0));
            }
            else if (_input.IsDownPressed())
            {
                spaceCraft.SetVelocity(new Point(0, Constants.SPACECRAFT_SPEED));
            }
            else if (_input.IsUpPressed())
            {
                spaceCraft.SetVelocity(new Point(0, Constants.SPACECRAFT_SPEED * -1));
            }
            else
            {
                spaceCraft.SetVelocity(new Point(0, 0));
            }

            Actor laser = cast["laser"][0];
            if (_input.IsSpacePressed())
            {
                int xPos = laser.GetX();
                if (xPos == Constants.X_OFF_SCREEN)
                {
                    Point laserPos = spaceCraft.GetPosition();
                    laserPos = new Point(laserPos.GetX() + (Constants.SPACECRAFT_WIDTH / 2), laserPos.GetY());
                    laser.SetPosition(laserPos);
                }
            }
        }
    }
}