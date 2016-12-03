using Microsoft.Xna.Framework;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class Block:GameObject
    {

        public override Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)X+1, (int)Y+1, (int)Width-2, (int)Height-2);
            }
        }
        public Block(Game1 game, Screen screen, int x, int y, int width, int height) : base(game, screen, Assets.getColorTexture(game,Color.White), x, y, width, height){

        }
        public new Block Clone()
        {
            return (Block)MemberwiseClone();
        }
    }
}
