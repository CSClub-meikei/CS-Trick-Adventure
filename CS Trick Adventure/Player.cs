using CS_Trick_Adventure.Objects;
using MonoGameLibrary;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using CS_Trick_Adventure.Screens;
using MonoGameLibrary.Animator;

namespace CS_Trick_Adventure
{
    public class Player : WorldObject
    {
        TextureAnimator a;

        public Player(MonoGameLibrary.Game game, GameScreen screen, int x, int y, int width, int height) : base(game, screen, Assets.GameObject.Player, x, y, width, height)
        {
            IsRigitBody = true;
            a = new TextureAnimator(game, this, Assets.GameObject.Dust,300,0.1,-150,120,300,100);
            
            Animators.Add(a);
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            int res  = CollisionTest(parent.Objects);

            if (Input.IsKeyDown(Keys.Right) && VelocityX < 500)
            {
                VelocityX += 50;
            }

            if (Input.IsKeyDown(Keys.Left) && VelocityX > -500)
            {
                if(VelocityX>450 && res==4) a.Start();
                if (VelocityX > 0) VelocityX -= 20;
                else VelocityX -= 50;

            }

            if (VelocityX < 11 && VelocityX > -11) VelocityX = 0;

            if (a.Enable && VelocityX < 40 && VelocityX > -40)
            {
                a.Stop();
              
            }

            if(!Input.IsKeyDown(Keys.Left) && !Input.IsKeyDown(Keys.Right))
            {
                if (VelocityX > 0) VelocityX -= 20;
                else if (VelocityX < 0) VelocityX += 20;
            }
            

            if (Input.onKeyDown(Keys.Space))
            {
                Console.WriteLine("ju");
                VelocityY = -1500;
            }
        }
    }
}
