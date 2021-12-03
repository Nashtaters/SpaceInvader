using System;
using SpaceInvader.Services;
using SpaceInvader.Casting;
using SpaceInvader.Scripting;
using System.Collections.Generic;

namespace SpaceInvader
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the cast
            Dictionary<string, List<Actor>> cast = new Dictionary<string, List<Actor>>();

            // Aliens
            cast["aliens"] = new List<Actor>();
        
            int x_position = 5;
            int y_position = 0;
            for (int i = 0; i < 32; i++)
            {
                if (x_position > 680)
                {
                    x_position = 0;
                    y_position += 75;  
                }
                else
                {
                    Alien alien = new Alien(x_position, y_position);
                    cast["aliens"].Add(alien);
                    x_position += 75;
                }
            }

            // The Spacecraft (or Spacecaftss if desired)
            cast["spaceCraft"] = new List<Actor>();
            SpaceCraft spaceCraft = new SpaceCraft(Constants.SPACECRAFT_X, Constants.SPACECRAFT_Y);
            cast["spaceCraft"].Add(spaceCraft);

            // The laser
            cast["laser"] = new List<Actor>();
            Laser laser = new Laser(Constants.X_OFF_SCREEN, Constants.Y_OFF_SCREEN);
            laser.SetVisible(false);
            cast["laser"].Add(laser);

            // Create the script
            Dictionary<string, List<Action>> script = new Dictionary<string, List<Action>>();

            OutputService outputService = new OutputService();
            InputService inputService = new InputService();
            PhysicsService physicsService = new PhysicsService();
            AudioService audioService = new AudioService();

            script["output"] = new List<Action>();
            script["input"] = new List<Action>();
            script["update"] = new List<Action>();
            
            MoveActorsAction moveActors = new MoveActorsAction();
            script["update"].Add(moveActors);

            HandleCollisionsAction removeActors = new HandleCollisionsAction();
            script["update"].Add(removeActors);

            ControlActorsAction moveSpaceCraft = new ControlActorsAction();
            script["input"].Add(moveSpaceCraft);

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "SpaceInvader", Constants.FRAME_RATE);
            audioService.StartAudio();
            audioService.PlaySound(Constants.SOUND_START);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
