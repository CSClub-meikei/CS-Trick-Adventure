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
    public class Mob1 : Sprite
    {
        int speed = 300;

        public Mob1(MonoGameLibrary.Game game, GameScreen screen, Texture2D texture, int x, int y, int width, int height) : base(game, screen, texture, x, y, width, height)
        {
            IsRigitBody = true;
        }
        public override void Update(double deltaTime)
        {
            VelocityX = speed;
            base.Update(deltaTime);
        }
    }
}
