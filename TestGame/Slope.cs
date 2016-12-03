using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLibrary;
using Microsoft.Xna.Framework.Input;
using static MonoGameLibrary.Collision.OverlapTester;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Object;

namespace TestGame
{
    public class Slope:GameObject
    {

        public int Mode;
        // 
        public Slope(MonoGameLibrary.Game game, Screen screen,int mode, int x, int y, int width, int height) : base(game, screen, Assets.saka45, x, y, width, height)
        {
            this.Mode = mode;
            if (Mode == -1) SetAngle(90);
        }

       

        public double getY(double x)
        {
            double slope = Height / Width;
            double y = 0;
            if (Mode == 1)
            {
                if(x>Width) y = slope * Width;
                else y = slope * x;
            }
            else if(Mode==-1)
            {
                if(x < 0) y = Height;
                else y = slope * (Width-x);
            }
            return y;
        }
        public new Slope Clone()
        {
            return (Slope)MemberwiseClone();
        }
    }
}
