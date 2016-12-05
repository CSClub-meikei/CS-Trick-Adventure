using CS_Trick_Adventure.Screens;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace CS_Trick_Adventure.Objects
{
    public class Floor : WorldObject
    {
        public const int Top = 1;
        public const int Right = 2;
        public const int Bottom = 3;
        public const int Left = 4;
        public const int Fill = 5;
        public const int TopRightCorner = 6;
        public const int BottomRightCorner = 7;
        public const int BottomLeftCorner = 8;
        public const int TopLeftCorner = 9;

        public int Mode = 0;

        public override Rectangle Rectangle
        {
            get {
                if(Mode==Floor.Top) return new Rectangle((int)X, (int)Y, (int)Width, (int)10);
                else return new Rectangle((int)X, (int)Y, (int)Width, (int)Height);
            }
        }

        public Floor(MonoGameLibrary.Game game, GameScreen screen,int mode, int x, int y, int width, int height) : base(game, screen, null, x, y, width, height)
        {
           
            switch (mode)
            {
                case Top:
                    Collision = CollisionMode.Floor;
                    Texture = Assets.GameObject.FloorTop;
                    break;
                case Right:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorSide;
                    
                    break;
                case Bottom:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorTop;
                    SpriteEffects = SpriteEffects.FlipVertically;
                    break;
                case Left:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorSide;
                    SpriteEffects = SpriteEffects.FlipHorizontally;
                    break;
                case Fill:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorFill;
                    break;
                case TopRightCorner:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorCorner;
                    break;
                case BottomRightCorner:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorCorner;
                    SetAngle(90);
                    break;
                case BottomLeftCorner:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorCorner;
                    SetAngle(180);
                    break;
                case TopLeftCorner:
                    Collision = CollisionMode.Block;
                    Texture = Assets.GameObject.FloorCorner;
                    SetAngle(270);
                    break;
            }
            RenderMode = 1;
            
        }
     
    }
}