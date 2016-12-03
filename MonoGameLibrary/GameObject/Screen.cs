using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace MonoGameLibrary.Object
{
    public class Screen
    {

        public double X { get; set; }
        public double Y { get; set; }
        public double Alpha { get; set; }
        public double Scale { get; set; }
        protected Game game;

        public Screen(Game game,double x = 0,double y = 0,double scale = 1)
        {
            this.game = game;
            this.Scale = scale;
            X = x;
            Y = y;
            Alpha = 1;
        }

        public virtual void Update(double deltaTime)
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {

        }
        public virtual Matrix GetScaleMatrix()
        {
            var scaleX = (float)game.graphics.PreferredBackBufferWidth / (float)1920*(float)Scale;
            var scaleY = (float)game.graphics.PreferredBackBufferHeight / (float)1080*(float)Scale;
            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }
    }
}
