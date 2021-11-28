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
            for (int i = 0; i < 100; i++)
            {
                if (x_position > 800)
                {
                    x_position = 5;
                    y_position += 29;  
                }
                else
                {
                    Alien alien = new Alien(x_position, y_position);
                    cast["aliens"].Add(alien);
                    x_position += 53;
                }
            }

            // The Spacecraft (or Spacecaftss if desired)

            // The laser

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

            DrawActorsAction drawActorsAction = new DrawActorsAction(outputService);
            script["output"].Add(drawActorsAction);

            // Start up the game
            outputService.OpenWindow(Constants.MAX_X, Constants.MAX_Y, "SpaceInvader", Constants.FRAME_RATE);

            Director theDirector = new Director(cast, script);
            theDirector.Direct();

            audioService.StopAudio();
        }
    }
}
