using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using static MonoGameLibrary.Collision.OverlapTester;
using MonoGameLibrary.Struct;
using MonoGameLibrary.Animator;
namespace MonoGameLibrary.Object
{
    public class GameObject
    {
        public double X { get { return x; } set { x = value; ActX = parent.X + X; } }
        public double Y { get { return y; } set { y = value; ActY = parent.Y + Y; } }
        public double Width { get; set; }
        public double Height { get; set; }

        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        public Vector2 Origin { get; set; }
        public double Angle { get; set; }
        public double ActX { get; private set; }
        public double ActY { get; private set; }
        public double Alpha { get; set; }
        public List<GameObjectAnimator> Animators = new List<GameObjectAnimator>();


        public string DebugMessage { get; set; }

        double x,y;

        Texture2D debugTexture;

        public virtual Rectangle Rectangle
        {
            get { return new Rectangle((int)X, (int)Y, (int)Width, (int)Height); }
        }

        public virtual Rectangle ActRectangle
        {
            get { return new Rectangle((int)(ActX*parent.Scale), (int)(ActY*parent.Scale), (int)((Width * parent.Scale)), (int)(Height * parent.Scale)); }
        }

        public virtual Circle Circle
        {
            get { return new Circle(X, Y, (Width + Height) / 2); }
        }

        protected Game game;
        public Screen parent;
        public Texture2D Texture { get; set; }
        
        public GameObject(Game game,Screen screen,Texture2D texture,int x,int y, int width,int height)
        {
            this.game = game;
            parent = screen;
            this.Texture = texture;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            if(texture!=null)Origin = new Vector2((float)(texture.Width / 2), (float)(texture.Height / 2));
            Alpha = 1;
            debugTexture = Assets.getColorTexture(game, Color.Yellow);
        }

        public virtual void Update(double deltaTime)
        {
            X += VelocityX * deltaTime;
            Y += VelocityY * deltaTime;
            

            ActX = X + parent.X;
            ActY = Y + parent.Y;

            foreach (GameObjectAnimator a in Animators) a.Update(deltaTime);
        }

        public virtual void Draw(SpriteBatch batch)
        {
            if (game.DebugMode)
            {
                batch.Begin(transformMatrix: parent.GetScaleMatrix());
                //batch.Draw(debugTexture, destinationRectangle: new Rectangle((int)ActX + (int)((texture.Width / 2) * (Width / texture.Width)), (int)ActY + (int)((texture.Height / 2) * (Height / texture.Height)), (int)Width, (int)Height), color: Color.White * (float)Alpha * (float)parent.Alpha * 0.5f, rotation: (float)Angle, origin: new Vector2(0,0));
                string message = "X:" + ((int)X).ToString() + " Y:" + ((int)Y).ToString() + " " + DebugMessage;

                batch.DrawString(game.DebugFont, message, new Vector2((int)ActX, (int)ActY - (int)game.DebugFont.MeasureString(message).Y), Color.Yellow);
                batch.End();
            }


            batch.Begin(transformMatrix: parent.GetScaleMatrix());

            batch.Draw(Texture, destinationRectangle: new Rectangle((int)ActX + (int)((Texture.Width / 2) * (Width / Texture.Width)), (int)ActY + (int)((Texture.Height / 2) * (Height / Texture.Height)), (int)Width, (int)Height), color: Color.White * (float)Alpha * (float)parent.Alpha, rotation: (float)Angle, origin: Origin);
            //batch.Draw(texture, new Rectangle((int)X, (int)Y, (int)Width, (int)Height), Color.White);
            batch.End();

            foreach (GameObjectAnimator a in Animators) a.Draw(batch);
            
           
        }

        public void SetAngle(double r)
        {
            Angle = dir2Rot(r);
            Origin = new Vector2((float)(Texture.Width / 2), (float)(Texture.Height / 2));
        }
        private float dir2Rot(double angle)
        {
            return (float)(angle / 180 * Math.PI);
        }
        private double rot2Dir(float radian)
        {
            return (double)(radian * 180 / Math.PI);
        }
        
        public GameObject Clone()
        {
            return (GameObject)MemberwiseClone();
        }
    }
}
