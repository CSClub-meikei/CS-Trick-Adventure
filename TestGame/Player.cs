using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLibrary;
using Microsoft.Xna.Framework.Input;
using static MonoGameLibrary.Collision.OverlapTester;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Animator;

namespace TestGame
{
    public class Player : RigidBody
    {
        new TestScreen parent;
        int jumpStep = 0;
        bool dead = false;
        FlashAnimator a;

        bool isStepped;
        public Player(Game1 game, Screen screen, int x, int y, int width, int height) : base(game, screen, Assets.image, x, y, width, height)
        {
            parent = (TestScreen)screen;
            a = new FlashAnimator(game, this, 0.1, 0, 0.1, 0);
            Animators.Add(a);
            a.Enable = false;
            //a.Start();
        }


        public override void Update(double deltaTime)
        {

            base.Update(deltaTime);
            if (dead) goto last;
            if (Input.onKeyDown(Keys.LeftShift))
            {
                Y += 50; Height = 50;
            }
            if (Input.IsKeyDown(Keys.LeftShift)) Height = 50;
            else Height = 100;

            if (Input.IsKeyDown(Keys.Left) && VelocityX > -500) VelocityX -= 40;
            else if (Input.IsKeyDown(Keys.Right) && VelocityX < 500) VelocityX += 40;
            else
            {
                if (VelocityX < -1) VelocityX += 20;
                else if (VelocityX > 1) VelocityX -= 20;

                if (VelocityX < 0.5 && VelocityX > -0.5) VelocityX = 0;
            }


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
                            break;
                        case 2:
                            VelocityX = 0;
                            X = o.X - Rectangle.Width;
                            break;
                        case 3:
                            VelocityY = 0;
                            jumpStep = 0;
                            Y = o.Y + o.Height;
                            break;
                        case 4:
                            if (VelocityY > 0)
                            {
                                flag = true;
                                Y = o.Y - Rectangle.Height;
                            }

                            break;
                    }

                    if (flag)
                    {
                        VelocityY = 0;
                        jumpStep = 0;
                    }


                    DebugMessage = " vx:" + VelocityX.ToString();
                }
                else if (o is Slope)
                {
                    int res = Rectangle.OverlapTestEX(o.Rectangle);
                    if (((Slope)o).Mode == 1)
                    {
                        if (res != 0 && Y + Height > o.Y + o.Height - ((Slope)o).getY(X + Width - o.X))
                        {
                            if (res == 1)
                            {

                                VelocityX = 0;
                                X = o.X + o.Width;
                            }
                            else
                            {
                                Y = o.Y + o.Height - ((Slope)o).getY(Math.Abs(X + Width - o.X)) - Height;
                                o.DebugMessage = " X-ox:" + (X - o.X).ToString();
                                VelocityY = 0;
                                jumpStep = 0;
                                if (VelocityX > 0) VelocityX -= 10;
                            }


                            DebugMessage = " " + res.ToString();



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
                            }
                            else
                            {
                                Y = o.Rectangle.Y + o.Rectangle.Height - ((Slope)o).getY(Rectangle.X - o.Rectangle.X) - Rectangle.Height;
                                o.DebugMessage = " X-ox:" + (Rectangle.X - o.Rectangle.X).ToString();

                                VelocityY = 0;
                                jumpStep = 0;
                                if (VelocityX < 0) VelocityX += 10;
                            }


                            DebugMessage = " " + res.ToString() + " X-ox:" + (Rectangle.X - o.Rectangle.X).ToString();



                        }
                    }

                }
                else if (o is Floor)
                {
                    if (Rectangle.OverlapTestEX(o.Rectangle) == 4 && VelocityY > 0)
                    {
                       // if (VelocityY > 101) Console.WriteLine("Y:" + VelocityY.ToString());
                        VelocityY = 0;
                        Y = o.Y - Height;
                        jumpStep = 0;
                    }
                }

            }

            foreach (enemy o in parent.Enemys)
            {
                switch (Rectangle.OverlapTestEX(new Rectangle((int)o.X+20, (int)o.Y+20, (int)o.Width-40, (int)o.Height-20)))
                {
                    case 1:
                    case 2:
                    case 3:
                        if (o.dead || VelocityY>0) break;
                        dead = true;
                        parent.pause = true;
                        a.Enable = true;
                        break;
                    case 4:
                        if (o.dead) break;
                        isStepped = true;
                        o.dead = true;
                        VelocityY = -600;
                        break;
                }
            }


                if (Input.onKeyDown(Keys.Space) && jumpStep < 2)
            {
                VelocityY = -1500;
                jumpStep++;
            }
            if (Input.IsKeyDown(Keys.Space) &&isStepped)
            {
                VelocityY = -2000;
            }

            if (X > 500)
            {
                parent.X = 500 - X;
            }

            isStepped = false;

            last:

            if (Y > 1200)
            {
                parent.X = 0;
                X = 0;
                Y = 0;
                dead = false;
            }
            if (dead) Alpha = 0.5f;
            else Alpha = 1;

           // Console.WriteLine("XX:" + X.ToString());
            // X += VelocityX * deltaTime;
            //  Y += VelocityY * deltaTime;

        }
    }
}

