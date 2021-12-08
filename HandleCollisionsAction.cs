using System;
using System.Collections.Generic;
using SpaceInvader.Casting;
using SpaceInvader.Services;

namespace SpaceInvader
{
    public class HandleCollisionsAction : Action
    {
        private PhysicsService _physics = new PhysicsService();
        private AudioService _audio = new AudioService();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            CollisionLogic(cast);
            LaserLogic(cast);
        }

        private void LaserLogic(Dictionary<string, List<Actor>> cast)
        {
            Laser laser = (Laser)cast["laser"][0];

            if (laser.IsVisible())
            {
                int laserBounds = 0;
                int laserBottom = laser.GetY() + Constants.LASER_HEIGHT;
                if (laserBottom <= laserBounds)
                {
                    laser.SetVisible(false);
                }
            }
        }

        private void CollisionLogic(Dictionary<string, List<Actor>> cast)
        {
            Actor spaceCraft = cast["spaceCraft"][0];
            Laser laser = (Laser)cast["laser"][0];
            List<Actor> aliens = cast["aliens"];
            
            Actor removeAlien = null;
            foreach(Actor alien in aliens)
            {
                bool collision = _physics.IsCollision(laser, alien);
                if (collision)
                {
                    _audio.PlaySound(Constants.SOUND_BOUNCE);

                    removeAlien = alien;
                    aliens.Remove(removeAlien);
                    laser.SetVisible(false);
                    break;
                }
            }
            
            foreach(Actor alien in aliens)
            {
                bool collision = _physics.IsCollision(spaceCraft, alien);
                if (collision)
                {
                    _audio.PlaySound(Constants.SOUND_BOUNCE);

                    spaceCraft.QuitGame();
                    break;
                }
            }

        }
    }
}