using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MonoGameLibrary.Collision.OverlapTester;

namespace TestGame
{
    public class RigidBody:MonoGameLibrary.Object.GameObject
    {


        public RigidBody(MonoGameLibrary.Game game, Screen screen, Texture2D texture, int x, int y, int width, int height):base(game,screen,texture,x,y,width,height)
        {

        }
        public override void Update(double deltaTime)
        {
            if(VelocityY<3000)VelocityY += 50;

            //Console.WriteLine(VelocityY.ToString());
            base.Update(deltaTime);
        }
        protected int Collision(TestScreen parent)
        {
            int Result = 0;

            bool flag = false;

            foreach (GameObject o in parent.Objects)
            {
                if (o is Block)
                {
                    switch (Rectangle.OverlapTestEX(o.Rectangle))
                    {
                        case 1:
                            VelocityX = 0;
                            X = o.X + o.Width;
                            Result = 1;
                            break;
                        case 2:
                            VelocityX = 0;
                            X = o.X - Rectangle.Width;
                            Result = 2;
                            break;
                        case 3:
                            VelocityY = 0;
                            //jumpStep = 0;
                            Y = o.Y + o.Height;
                            Result = 3;
                            break;
                        case 4:
                            if (VelocityY > 0)
                            {
                                flag = true;
                                Y = o.Y - Rectangle.Height;
                                Result = 4;
                            }

                            break;
                    }

                    if (flag)
                    {
                        VelocityY = 0;
                        //jumpStep = 0;
                    }


                    DebugMessage = " vx:" + VelocityX.ToString();
                }
                else if (o is Slope)
                {
                    int res = Rectangle.OverlapTestEX(o.Rectangle);
                    if (((Slope)o).Mode == 1)
                    {
                        if (res != 0 && Rectangle.Y + Rectangle.Height > o.Rectangle.Y + o.Rectangle.Height - ((Slope)o).getY(Rectangle.X + Rectangle.Width - o.Rectangle.X))
                        {
                            if (res == 1)
                            {
                               
                                VelocityX = 0;
                                X = o.Rectangle.X + o.Rectangle.Width;
                                Result = 1;
                            }
                            else
                            {
                                Y = o.Rectangle.Y + o.Rectangle.Height - ((Slope)o).getY(Math.Abs(Rectangle.X + Rectangle.Width - o.Rectangle.X)) - Rectangle.Height;
                                o.DebugMessage = " X-ox:" + (Rectangle.X - o.Rectangle.X).ToString();
                                VelocityY = 0;
                                //jumpStep = 0;
                                if (VelocityX > 0) VelocityX -= 10;
                                Result = 4;
                            }


                            DebugMessage = " " + res.ToString() + " X-ox:" + (Rectangle.X - o.Rectangle.X).ToString();

                            Result = res;

                        }
                    }
                    else if (((Slope)o).Mode == -1)
                    {
                        if (res != 0 && Rectangle.Y + Rectangle.Height > o.Rectangle.Y + o.Rectangle.Height - ((Slope)o).getY(Rectangle.X - o.Rectangle.X))
                        {
                            if (res == 2)
                            {

                                VelocityX = 0;
                                X = o.Rectangle.X - Rectangle.Width;
                                Result = 1;
                            }
                            else
                            {
                                Y = o.Rectangle.Y + o.Rectangle.Height - ((Slope)o).getY(Rectangle.X - o.Rectangle.X) - Rectangle.Height;
                                o.DebugMessage = " X-ox:" + (Rectangle.X - o.Rectangle.X).ToString();
                                
                                VelocityY = 0;
                                //jumpStep = 0;
                                if (VelocityX < 0) VelocityX += 10;
                                Result = 4;
                            }

                            
                            DebugMessage = " " + res.ToString() + " X-ox:" + (Rectangle.X - o.Rectangle.X).ToString();



                        }
                    }

                }
                else if (o is Floor)
                {
                    if (Rectangle.OverlapTestEX(o.Rectangle) == 4 && VelocityY > 0)
                    {
                        //if (VelocityY > 101) Console.WriteLine("Y:" + VelocityY.ToString());
                        VelocityY = 0;
                        Y = o.Y - Height;
                        //jumpStep = 0;
                        Result = 4;
                    }
                }

            }

            return Result;
        }
    }
}
