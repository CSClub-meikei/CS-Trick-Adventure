using Microsoft.Xna.Framework;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Animator
{
    public class MoveAnimator:GameObjectAnimator
    {
        public const int FadeIn = 0;
        public const int FadeOut = 1;
        
        double duration;
        double vx, vy;
        int mode = -1;
        Point p0, p1, p2,p3;

        double time;

        public override event EventHandler Finish;

        public MoveAnimator(Game game, GameObject parent, double duration,Point p1,Point p2) : base(game, parent)
        {
            
            this.duration = duration;
            this.p1 = p1;
            this.p2 = p2;
            mode = 1;
        }
        public MoveAnimator(Game game, GameObject parent,int mode, double duration, Point p0, Point p1,Point p2,Point p3) : base(game, parent)
        {
            //0通常 1Xのみ 2Yのみ
            this.duration = duration;
            this.p0 = p0;
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
            this.mode = mode+2;
        }
        public override void Initialize()
        {

        }
        public override void Start()
        {
            IsAnimate = true;
            time = 0;
            if (mode == 1)
            {
                vx = (p2.X - p1.X) / duration;
                vy = (p2.Y - p1.X) / duration;
            }
            else if ( 2 <= mode && mode <=4)
            {
                
            }
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            if (!Enable || !IsAnimate) return;
            time += deltaTime;
            if (mode == 1)
            {
                parent.X += vx;
                parent.Y += vy;
            }else if (mode == 2)
            {
                Vector2 v = MathUtils.BezierCurve(new Vector2(p0.X,p0.Y), new Vector2(p1.X, p1.Y), new Vector2(p2.X, p2.Y), new Vector2(p3.X, p3.Y), time/duration);
                parent.X = v.X;
                parent.Y = v.Y;
            }
            else if (mode == 3)
            {
                Vector2 v = MathUtils.BezierCurve(new Vector2(p0.X, p0.Y), new Vector2(p1.X, p1.Y), new Vector2(p2.X, p2.Y), new Vector2(p3.X, p3.Y), time / duration);
                parent.X = v.X;
               // parent.Y = v.Y;
            }
            else if (mode == 4)
            {
                Vector2 v = MathUtils.BezierCurve(new Vector2(p0.X, p0.Y), new Vector2(p1.X, p1.Y), new Vector2(p2.X, p2.Y), new Vector2(p3.X, p3.Y), time / duration);
               // parent.X = v.X;
                parent.Y = v.Y;
            }
            parent.DebugMessage = time.ToString();
            if (time >= duration)
            {
                if(mode==2 || mode==3)parent.X = p3.X;
                if(mode==2 || mode==4)parent.Y = p3.Y;    
                Finish?.Invoke(this, EventArgs.Empty);
                IsAnimate = false;
            }
        }
    }
}
