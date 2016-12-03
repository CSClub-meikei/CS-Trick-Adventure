using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Animator
{
    public class FadeAnimator:GameObjectAnimator
    {
        public const int FadeIn = 0;
        public const int FadeOut = 1;

        int mode;
        double duration;
        double OpPerSec;

        public override event EventHandler Finish;

        public FadeAnimator(Game game,GameObject parent,int mode,double duration) : base(game, parent)
        {
            this.mode = mode;
            this.duration = duration;
        }
        public override void Initialize()
        {
            
        }
        public override void Start()
        {
            IsAnimate = true;
            if (mode == FadeIn) parent.Alpha = 0;

            OpPerSec = 1 / duration;
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if (!Enable) return;

            if (mode == FadeIn)
            {
                parent.Alpha += OpPerSec*deltaTime;
                if (parent.Alpha >= 1) Finish?.Invoke(this, EventArgs.Empty);
            }
            else if (mode == FadeOut)
            {
                parent.Alpha -= OpPerSec*deltaTime;
                if(parent.Alpha<=0) Finish?.Invoke(this, EventArgs.Empty);
            }


        }
    }
}
