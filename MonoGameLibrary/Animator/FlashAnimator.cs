using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary.Animator
{
    public class FlashAnimator:GameObjectAnimator
    {
        double durationIn;
        double durationOut;
        double durationKeep1;
        double durationKeep2;
        double OpPerSecIn;
        double OpPerSecOut;
        int step=0;

        double keepTime;
        bool cancel;
        public FlashAnimator(Game game,GameObject parent,double durationIn, double durationKeep1 ,double durationOut,double durationKeep2) : base(game, parent)
        {
            this.durationIn = durationIn;
            this.durationOut = durationOut;
            this.durationKeep1 = durationKeep1;
            this.durationKeep2 = durationKeep2;
        }
        public override void Initialize()
        {

        }
        public override void Stop()
        {
            
        }
        public override void Start()
        {
            IsAnimate = true;
            

            OpPerSecIn = 1 / durationIn;
            OpPerSecOut = 1 / durationOut;
            base.Start();
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            if (!Enable) return;

            switch (step)
            {
                case 0:
                    parent.Alpha += OpPerSecIn * deltaTime;
                    if (parent.Alpha >= 1) step = 1;
                    break;
                case 1:
                    keepTime += deltaTime;
                    if (keepTime >= durationKeep1)
                    {
                        step = 2;
                        keepTime = 0;
                    }
                    break;
                case 2:
                    parent.Alpha -= OpPerSecOut * deltaTime;
                    if (parent.Alpha <= 0) step = 3;
                    break;
                case 3:
                    keepTime += deltaTime;
                    if (keepTime >= durationKeep2)
                    {
                        step = 0;
                        keepTime = 0;
                    }
                    break;
            }


        }
    }
}
