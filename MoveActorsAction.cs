using System;
using System.Collections.Generic;
using SpaceInvader.Casting;

namespace SpaceInvader
{
    public class MoveActorsAction : Action
    {
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            foreach(List<Actor> group in cast.Values)
            {
                foreach(Actor a in group)
                {
                    a.MoveNext();
                }
            }
        }
    }
}