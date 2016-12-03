using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
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
            image = content.Load<Texture2D>("image");
            saka45 = content.Load<Texture2D>("saka45");
            enemy = content.Load<Texture2D>("enemy");
            smoke = content.Load<Texture2D>("smoke");
        }
        public static Texture2D image;
        public static Texture2D saka45;
        public static Texture2D enemy;
        public static Texture2D smoke;
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
