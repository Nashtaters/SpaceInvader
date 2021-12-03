using System;
using System.Collections.Generic;
using SpaceInvader.Casting;
using SpaceInvader.Services;

namespace SpaceInvader
{
    public class HandleCollisionsAction : Action
    {
        const int  FLASH_INTERVAL = 10;

        private PhysicsService _physics = new PhysicsService();
        private AudioService _audio = new AudioService();

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            CollisionLogic(cast);
        }

        private void CollisionLogic(Dictionary<string, List<Actor>> cast)
        {
            Actor spaceCraft = cast["spaceCraft"][0];
            Actor laser = cast["laser"][0];
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
                    break;
                }
            }
            
            Actor removeSpaceCraft = null;
            foreach(Actor alien in aliens)
            {
                bool collision = _physics.IsCollision(spaceCraft, alien);
                if (collision)
                {
                    _audio.PlaySound(Constants.SOUND_BOUNCE);

                    removeSpaceCraft = spaceCraft;
                }
            }

        }
    }
}