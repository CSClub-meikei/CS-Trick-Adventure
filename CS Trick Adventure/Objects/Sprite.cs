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
    public class Sprite:WorldObject
    {

        public bool IsDead;
        public bool IsRigitBody;


        public Sprite(MonoGameLibrary.Game game, GameScreen screen, Texture2D texture, int x, int y, int width, int height):base(game,screen,texture,x,y,width,height){



        }
        public override void Update(double deltaTime)
        {
            if (IsRigitBody && VelocityY < 3000) VelocityY += 50;
            base.Update(deltaTime);
        }

    }
}
