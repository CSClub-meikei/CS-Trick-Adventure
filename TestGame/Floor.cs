using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLibrary.Object;
using Microsoft.Xna.Framework;
using MonoGameLibrary;
namespace TestGame
{
    public class Floor:GameObject
    {
        public Floor(Game1 game, Screen screen, int x, int y, int width, int height) : base(game, screen, Assets.getColorTexture(game, Color.Yellow), x, y, width, height)
        {

        }
        public new Floor Clone()
        {
            return (Floor)MemberwiseClone();
        }
    }
}