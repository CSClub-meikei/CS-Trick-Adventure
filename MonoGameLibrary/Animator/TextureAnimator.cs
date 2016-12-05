using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Animator
{
    public class TextureAnimator:GameObjectAnimator
    {
        public const int FadeIn = 0;
        public const int FadeOut = 1;

        int mode;
        double duration;
        double OpPerSec;
        int frame;
        int width;
        int ofx, ofy;
        int ow, oh;
        public override event EventHandler Finish;
        Texture2D texture;
        double time;
        public double Alpha = 1;
        bool fadeOut;
        public TextureAnimator(Game game, GameObject parent,Texture2D texture, int splitWidth, double duration,int ofx = 0, int ofy = 0,int w = 0,int h = 0) : base(game, parent)
        {
            this.ofx = ofx;
            this.ofy = ofy;
            if (w > 0) ow = w;
            else ow = (int)parent.Width;

            if (h > 0) oh = h;
            else oh = (int)parent.Height;

            this.duration = duration;
            width = splitWidth;
            this.texture = texture;
        }
        public override void Initialize()
        {

        }
        public override void Start()
        {
            Enable = true;
            IsAnimate = true;
        }
        public override void Stop()
        {
            IsAnimate = false;
            Enable = false;
            fadeOut = true;
            base.Stop();
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (Enable)
            {

                time += deltaTime;
                if (time >= duration)
                {
                    frame++;
                    if (frame > texture.Width / width)
                    {
                        
                        Stop();
                        
                    }

                }
            }

            if (fadeOut)
            {
                Alpha -= 0.05;
                if (Alpha < 0)
                {
                    frame = 0;
                    Alpha = 1;
                    fadeOut = false;
                }
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(transformMatrix: parent.parent.GetScaleMatrix(),blendState:BlendState.NonPremultiplied);

            batch.Draw(texture, destinationRectangle: new Rectangle((int)parent.ActX+ ofx + (int)((texture.Width / 2) * (parent.Width / texture.Width)), (int)parent.ActY + ofy + (int)((texture.Height / 2) * (parent.Height / texture.Height)),ow,oh),sourceRectangle:new Rectangle(width*frame,0,width,texture.Height), color: Color.White * (float)parent.Alpha * (float)Alpha, rotation: (float)parent.Angle, origin: parent.Origin);
            //batch.Draw(texture, new Rectangle((int)X, (int)Y, (int)Width, (int)Height), Color.White);
            batch.End();
        }
    }
}
