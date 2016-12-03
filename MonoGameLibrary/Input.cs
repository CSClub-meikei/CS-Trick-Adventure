using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary
{
    public static class Input
    {

        static KeyboardState KeyOldState;
        static MouseState MouseOldState;

        public const int LeftButton = 1;
        public const int RightButton = 2;
        public const int MiddleButton = 3;

        static Game game;
        public static void Initialize(Game game)
        {
            Input.game = game;
        }
        public static bool IsKeyDown(Keys key)
        {
            return Keyboard.GetState().IsKeyDown(key);
        }
        public static bool onKeyDown(Keys key)
        {
            KeyboardState newState = Keyboard.GetState();  // get the newest state
            bool res;

            // handle the input
            if (KeyOldState.IsKeyUp(key) && newState.IsKeyDown(key)) res = true;
            else res = false;




            return res;

        }
        public static bool onKeyUp(Keys key)
        {
            KeyboardState newState = Keyboard.GetState();  // get the newest state
            bool res;

            // handle the input
            if (KeyOldState.IsKeyDown(key) && newState.IsKeyUp(key)) res = true;
            else res = false;




            return res;

        }
        public static bool onHover(Rectangle rect, double Scale = 1)
        {
            MouseState newState = Mouse.GetState();
            var newm = GlobalToLocal(newState.Position,Scale);
            var old = GlobalToLocal(MouseOldState.Position,Scale);
            if (rect.Contains(newm) && !rect.Contains(old)) return true;
            else return false;



        }
        public static bool onLeave(Rectangle rect,double Scale = 1)
        {
            MouseState newState = Mouse.GetState();
            var newm = GlobalToLocal(newState.Position, Scale);
            var old = GlobalToLocal(MouseOldState.Position, Scale);
            if (!rect.Contains(newm) && rect.Contains(old)) return true;
            else return false;



        }
        public static bool IsHover(Rectangle rect,double Scale = 1)
        {
            MouseState newState = Mouse.GetState();
            var newm = GlobalToLocal(newState.Position, Scale);

            if (rect.Contains(newm)) return true;
            else return false;



        }
        public static Point getPosition(double Scale = 1)
        {

            return GlobalToLocal(Mouse.GetState().Position);
        }
        public static void setPotition(Point point)
        {
            Point p = LocalToGlobal(point);
            Mouse.SetPosition(p.X, p.Y);
        }
        public static int getWheel()
        {
            return Mouse.GetState().ScrollWheelValue;
        }
        public static bool OnMouseDown(int button)
        {
            MouseState newState = Mouse.GetState();
            if (button == LeftButton)
            {
                if (newState.LeftButton == ButtonState.Pressed && MouseOldState.LeftButton != ButtonState.Pressed) return true;
                else return false;

            }
            else if (button == RightButton)
            {
                if (newState.RightButton == ButtonState.Pressed && MouseOldState.RightButton != ButtonState.Pressed) return true;
                else return false;
            }
            else if (button == MiddleButton)
            {
                if (newState.MiddleButton == ButtonState.Pressed && MouseOldState.MiddleButton != ButtonState.Pressed) return true;
                else return false;
            }
            return false;
        }
        public static bool OnMouseUp(int button)
        {
            MouseState newState = Mouse.GetState();
            if (button == LeftButton)
            {
                if (newState.LeftButton != ButtonState.Pressed && MouseOldState.LeftButton == ButtonState.Pressed) return true;
                else return false;

            }
            else if (button == RightButton)
            {
                if (newState.RightButton != ButtonState.Pressed && MouseOldState.RightButton == ButtonState.Pressed) return true;
                else return false;
            }
            else if (button == MiddleButton)
            {
                if (newState.MiddleButton != ButtonState.Pressed && MouseOldState.MiddleButton == ButtonState.Pressed) return true;
                else return false;
            }
            return false;
        }
        public static bool IsMouseDown(int button)
        {
            MouseState newState = Mouse.GetState();
            if (button == LeftButton)
            {
                if (newState.LeftButton == ButtonState.Pressed) return true;
                else return false;

            }
            else if (button == RightButton)
            {
                if (newState.RightButton == ButtonState.Pressed) return true;
                else return false;
            }
            else if (button == MiddleButton)
            {
                if (newState.MiddleButton == ButtonState.Pressed) return true;
                else return false;
            }
            return false;
        }
        private static Point GlobalToLocal(Point point,double Scale = 1)
        {
            var scaleX = 1920*Scale / (float)game.graphics.PreferredBackBufferWidth;
            var scaleY = 1080*Scale / (float)game.graphics.PreferredBackBufferHeight;

            return new Point((int)(point.X * scaleX), (int)(point.Y * scaleY));


        }
        private static Point LocalToGlobal(Point point, double Scale = 1)
        {
            var scaleX = 1920*Scale / (float)game.graphics.PreferredBackBufferWidth;
            var scaleY = 1080*Scale / (float)game.graphics.PreferredBackBufferHeight;

            return new Point((int)(point.X / scaleX), (int)(point.Y / scaleY));


        }
        public static void update()
        {
            KeyboardState KnewState = Keyboard.GetState();  // get the newest state
            KeyOldState = KnewState;  // set the new state as the old state for next time
            MouseState MnewState = Mouse.GetState();
            MouseOldState = MnewState;

        }

    }
}