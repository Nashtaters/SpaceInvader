using System;
using System.Collections.Generic;
using SpaceInvader.Casting;
using SpaceInvader.Services;

namespace SpaceInvader
{
    public class HandleOffScreenAction : Action
    {

        private PhysicsService _physics = new PhysicsService();
        Actor _bottomEdge = new Actor();
        Actor _topEdge = new Actor();
        Actor _leftEdge = new Actor();
        Actor _rightEdge = new Actor();

        public HandleOffScreenAction()
        {
            Casting.Point point = new Casting.Point(0, Constants.MAX_Y);
            _bottomEdge.SetWidth(Constants.MAX_X);
            _bottomEdge.SetPosition(point);

            point = new Casting.Point(0, 0);
            _topEdge.SetWidth(Constants.MAX_X);
            _topEdge.SetPosition(point);

            point = new Casting.Point(0, 0);
            _leftEdge.SetHeight(Constants.MAX_Y);
            _leftEdge.SetPosition(point);

            point = new Casting.Point(Constants.MAX_X, 0);
            _rightEdge.SetHeight(Constants.MAX_Y);
            _rightEdge.SetPosition(point);
        }

        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            EdgeLogic(cast);
        }

        private void EdgeLogic(Dictionary<string, List<Actor>> cast)
        {
            List<Actor> aliens = cast["aliens"];

            foreach (Actor alien in aliens)
            {                    
                bool collision = _physics.IsCollision(alien, _bottomEdge);
                if (collision)
                {
                    Point reverseVelocity = alien.GetVelocity().Reverse();
                    Point newVelocity = new Point(reverseVelocity.GetX()*-1, reverseVelocity.GetY());
                    alien.SetVelocity(newVelocity);
                }
                
                collision = _physics.IsCollision(alien, _topEdge);
                if (collision)
                {
                    Point reverseVelocity = alien.GetVelocity().Reverse();
                    Point newVelocity = new Point(reverseVelocity.GetX()*-1, reverseVelocity.GetY());
                    alien.SetVelocity(newVelocity);
                }

                collision = _physics.IsCollision(alien, _leftEdge);
                if (collision)
                {
                    Point reverseVelocity = alien.GetVelocity().Reverse();
                    Point newVelocity = new Point(reverseVelocity.GetX(), reverseVelocity.GetY()*-1);
                    Point newPosition = new Point(alien.GetX(), alien.GetY() + 5);
                    alien.SetPosition(newPosition);
                    alien.SetVelocity(newVelocity);
                }

                collision = _physics.IsCollision(alien, _rightEdge);
                if (collision)
                { 
                    Point reverseVelocity = alien.GetVelocity().Reverse();
                    Point newVelocity = new Point(reverseVelocity.GetX(), reverseVelocity.GetY()*-1);
                    Point newPosition = new Point(alien.GetX(), alien.GetY() + 5);
                    alien.SetPosition(newPosition);
                    alien.SetVelocity(newVelocity);
                }
            }
        }
    }
}