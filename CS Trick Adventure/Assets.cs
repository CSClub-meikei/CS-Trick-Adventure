using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Trick_Adventure
{
    public static class Assets
    {
        static ContentManager content;
        public static class GameObject
        {
            public static Texture2D Block1;
            public static Texture2D FloorTop;
            public static Texture2D FloorSide;
            public static Texture2D FloorFill;
            public static Texture2D FloorCorner;
            public static Texture2D Player;
            public static Texture2D Slope;
            public static Texture2D Dust;
        }




        public static void Init(Game game)
        {
            content = game.Content;
        }

        public static void LoadGameGraphics(int preset = 0)
        {
            GameObject.Block1 = content.Load<Texture2D>("block");
            GameObject.FloorTop = content.Load<Texture2D>("FloorTop");
            GameObject.FloorSide = content.Load<Texture2D>("FloorSide");
            GameObject.FloorFill = content.Load<Texture2D>("FloorFill");
            GameObject.FloorCorner = content.Load<Texture2D>("FloorCorner");
            GameObject.Player = content.Load<Texture2D>("player");
            GameObject.Slope = content.Load<Texture2D>("saka45");
            GameObject.Dust = content.Load<Texture2D>("dust");
        }
    }
}
