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
        public override event EventHandler Finish;
        Texture2D texture;
        double time;
        public TextureAnimator(Game game, GameObject parent,Texture2D texture, int splitWidth,int mode, double duration) : base(game, parent)
        {
            this.mode = mode;
            this.duration = duration;
            width = splitWidth;
            this.texture = texture;
        }
        public override void Initialize()
        {

        }
        public override void Start()
        {

            IsAnimate = true;
        }
        public override void Stop()
        {
            base.Stop();
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (!Enable) return;
            time += deltaTime;
            if (time >= duration)
            {
                frame++;
                if (frame > texture.Width / width) frame = 0;
            }
           
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Begin(transformMatrix: parent.parent.GetScaleMatrix());

            batch.Draw(texture, destinationRectangle: new Rectangle((int)parent.ActX + (int)((texture.Width / 2) * (parent.Width / texture.Width)), (int)parent.ActY + (int)((texture.Height / 2) * (parent.Height / texture.Height)), (int)parent.Width, (int)parent.Height),sourceRectangle:new Rectangle(width*frame,0,width,texture.Height), color: Color.White * (float)parent.Alpha * (float)parent.Alpha, rotation: (float)parent.Angle, origin: parent.Origin);
            //batch.Draw(texture, new Rectangle((int)X, (int)Y, (int)Width, (int)Height), Color.White);
            batch.End();
        }
    }
}
