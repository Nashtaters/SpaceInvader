using System;
using System.Collections.Generic;
using SpaceInvader.Casting;
using SpaceInvader.Services;

namespace SpaceInvader
{
    public class HandleOffScreenAction : Action
    {
        private int _moveDirecetion = Constants.ALIEN_MOVE_RIGHT;
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
            _leftEdge.SetWidth(1);
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

            if (_moveDirecetion == Constants.ALIEN_MOVE_RIGHT)
            {
                HandleRightMovement(aliens);
            }
            else if (_moveDirecetion == Constants.ALIEN_MOVE_LEFT)
            {
                HandleLeftMovement(aliens);
            }

            foreach (Actor alien in aliens)
            {                    
                bool collision = _physics.IsCollision(alien, _bottomEdge);
                //check if the alien hits bottom edge
                if (collision)
                {
                    Point reverseVelocity = alien.GetVelocity().Reverse();
                    Point newVelocity = new Point(reverseVelocity.GetX()*-1, reverseVelocity.GetY());
                    alien.SetVelocity(newVelocity);
                }
            }
        }

        private void HandleRightMovement(List<Actor> aliens)
        {
            foreach (Actor alien in aliens)
            {
                bool collision = _physics.IsCollision(alien, _rightEdge);

                //check if the alien hits right edge
                if (collision)
                {
                    _moveDirecetion = Constants.ALIEN_MOVE_LEFT;
                    ReverseAlienDirection(aliens);
                    MoveAliensDown(aliens);
                    return;
                }
            }
        }

        private void HandleLeftMovement(List<Actor> aliens)
        {
            foreach (Actor alien in aliens)
            {
                bool collision = _physics.IsCollision(alien, _leftEdge);                

                //check if the alien hits left edge
                if (collision)
                {
                    _moveDirecetion = Constants.ALIEN_MOVE_RIGHT;
                    ReverseAlienDirection(aliens);
                    MoveAliensDown(aliens);
                    return;
                }
            }
        }


        private void ReverseAlienDirection(List<Actor> aliens)
        {
            foreach (Actor alien in aliens)
            {
                Point reverseVelocity = alien.GetVelocity().Reverse();
                Point newVelocity = new Point(reverseVelocity.GetX(), reverseVelocity.GetY()*-1);
                alien.SetVelocity(newVelocity); 
            }
        }

        private void MoveAliensDown(List<Actor> aliens)
        {
            foreach (Actor alien in aliens)
            {
                Point newPosition = new Point(alien.GetX(), alien.GetY() + 5);
                alien.SetPosition(newPosition); 
            }
        }
    }
}