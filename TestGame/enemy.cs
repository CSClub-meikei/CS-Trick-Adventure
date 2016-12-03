using MonoGameLibrary;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static MonoGameLibrary.Collision.OverlapTester;

namespace TestGame
{
    public class enemy :RigidBody
    {
        new TestScreen parent;
        public bool dead;
        int frame = 0;
        public int id;
        int v=-300;

        public enemy(MonoGameLibrary.Game game, Screen screen, int x, int y, int width, int height) : base(game, screen, Assets.enemy, x, y, width, height)
        {
            parent = (TestScreen)screen;
           
        }
        public override Rectangle Rectangle
        {
            get
            {
                 return new Rectangle((int)X, (int)Y, (int)Width, (int)Height); 
            }
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            VelocityX = v;
            if(VelocityX<0) Angle -= 0.1;
            else Angle += 0.1;
            if (dead)
            {
                
                Angle = 0;
                if (Height > 10)
                {
                    Y += Height;
                }
                Height = 10;
                VelocityX = 0;
                frame++;
                if (frame > 30)
                {
                    foreach(GameObject o in parent.AllObjects)
                    {
                        if (o is enemy && ((enemy)o).id == id) ((enemy)o).dead = true;
                    }
                    frame = 0;
                    parent.RemoveEnemy(this);
                }
            }
          
               int Col =  Collision(parent);
            int r = 0;
            foreach(enemy e in parent.Enemys)
            {
                if (e != this)
                {
                    int res = Rectangle.OverlapTestEX(e.Rectangle);
                    if (res == 1 && Col != 2)
                    {
                        v = 300;
                        X = e.X + Width;
                        r = res;
                    }
                    else if (res == 2 && Col!=1)
                    {
                        v = -300;
                        X = e.X - Width;
                        r = res;
                    } else if (res == 4 && Col!=3)
                    {
                        Y = e.Y - Height;
                        r = res;
                        VelocityY = 0;
                    }
                    else if (res == 3 && Col!=4)
                    {
                        Y = e.Y + e.Height;
                        r = res;
                        VelocityY = 0;
                    }
                }
               
            }
                
            if(new Random().Next(50) == 1)
            {
                VelocityY -= 500;
            }
            DebugMessage = "当たり:" + r.ToString();

            if(Y>1200) parent.RemoveEnemy(this);

        }
        public new enemy Clone()
        {
            return (enemy)MemberwiseClone();
        }
    }
}
