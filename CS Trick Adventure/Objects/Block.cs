using CS_Trick_Adventure.Screens;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Trick_Adventure.Objects
{
    public class Block:WorldObject
    {


        public Block(MonoGameLibrary.Game game, GameScreen screen, Texture2D texture, int x, int y, int width, int height) : base(game, screen, texture, x, y, width, height)
        {
            Collision = CollisionMode.Block;
        }


    }
}
