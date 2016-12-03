using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Object
{
    public class UiObject:GameObject
    {
        public class UiEventArgs : EventArgs
        {
            public Point point;
            public int Button;
            public UiEventArgs(Point point,int button = -1)
            {
                this.point = point;
                this.Button = button;
            }
        }
    
        public event EventHandler<UiEventArgs> OnClick;
        public event EventHandler<UiEventArgs> OnHover;
        public event EventHandler<UiEventArgs> OnLeave;
        public event EventHandler<UiEventArgs> OnDown;
        public event EventHandler<UiEventArgs> OnUp;

        public UiObject(Game game, Screen screen,Texture2D texture, int x, int y, int width, int height) : base(game, screen, texture, x, y, width, height)
        {

        }
        public bool IsHover(Point point)
        {
            if (Rectangle.X < point.X && point.X < Rectangle.X + Rectangle.Width && Rectangle.Y < point.Y && point.Y < Rectangle.Y + Rectangle.Height) return true;
            else return false;
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            if (Input.onHover(ActRectangle))
            {
                OnHover?.Invoke(this, new UiEventArgs(Input.getPosition()));
            }
            if (Input.onLeave(ActRectangle))
            {
                OnLeave?.Invoke(this, new UiEventArgs(Input.getPosition()));
            }
            if (Input.OnMouseDown(Input.LeftButton) && Input.IsHover(ActRectangle))
            {
                OnDown?.Invoke(this, new UiEventArgs(Input.getPosition(), Input.LeftButton));
            }
            if (Input.OnMouseDown(Input.MiddleButton) && Input.IsHover(ActRectangle))
            {
                OnDown?.Invoke(this, new UiEventArgs(Input.getPosition(), Input.MiddleButton));
            }
            if (Input.OnMouseDown(Input.RightButton) && Input.IsHover(ActRectangle))
            {
                OnDown?.Invoke(this, new UiEventArgs(Input.getPosition(), Input.RightButton));
            }
            if (Input.OnMouseUp(Input.LeftButton) && Input.IsHover(ActRectangle))
            {
                OnUp?.Invoke(this, new UiEventArgs(Input.getPosition(), Input.LeftButton));
            }
            if (Input.OnMouseUp(Input.MiddleButton) && Input.IsHover(ActRectangle))
            {
                OnUp?.Invoke(this, new UiEventArgs(Input.getPosition(), Input.MiddleButton));
            }
            if (Input.OnMouseUp(Input.RightButton) && Input.IsHover(ActRectangle))
            {
                OnUp?.Invoke(this, new UiEventArgs(Input.getPosition(), Input.RightButton));
            }
        }
    }
}
