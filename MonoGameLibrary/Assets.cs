using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGameLibrary
{
    public static class Assets
    {

        static ContentManager content;

        public static void Initialize(Game game)
        {
            content = game.Content;
           

            content.RootDirectory = "Content";
        }

        public static void Load()
        {

        }
        public static Texture2D getColorTexture(Game game, Color c)
        {
            Color[] color = new Color[1 * 1];
            color[0] = c;
            Texture2D t = new Texture2D(game.GraphicsDevice, 1, 1);
            t.SetData<Color>(color);

            return t;
        }
    }
}
