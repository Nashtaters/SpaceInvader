using System;

namespace SpaceInvader
{
    /// <summary>
    /// This is a set of program wide constants to be used in other classes.
    /// </summary>
    public static class Constants
    {
        public const int MAX_X = 800;
        public const int MAX_Y = 600;
        public const int FRAME_RATE = 30;
        public const string IMAGE_AIEN = "./Assets/alien.png";
        public const string IMAGE_SPACECRAFT = "./Assets/spacecraft.png";
        public const string IMAGE_LASER = "./Assets/laser.png";
        public const string SOUND_START = "./Assets/start.wav";
        public const string SOUND_BOUNCE = "./Assets/boing.wav";
        public const string SOUND_OVER = "./Assets/over.wav";
        public const int DEFAULT_SQUARE_SIZE = 20;
        public const int DEFAULT_FONT_SIZE = 20;
        public const int DEFAULT_TEXT_OFFSET = 4;
        public const int SPACECRAFT_X = MAX_X / 2;
        public const int SPACECRAFT_Y = MAX_Y - 125;
        public const int X_OFF_SCREEN = 5000;
        public const int Y_OFF_SCREEN = 5000;
        public const int SPACECRAFT_DX = 8;
        public const int SPACECRAFT_DY = SPACECRAFT_DX * -1;

        public const int ALIEN_WIDTH = 48;
        public const int ALIEN_HEIGHT = 24;

        public const int ALIEN_SPACE = 5;

        public const int SPACECRAFT_SPEED = 15;

        public const int SPACECRAFT_WIDTH = 24;
        public const int SPACECRAFT_HEIGHT = 24;
        public const int LASER_WIDTH = 3;
        public const int LASER_HEIGHT = 1;
    }

}