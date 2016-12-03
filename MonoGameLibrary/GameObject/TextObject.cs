using System;
using MonoGameLibrary.Object;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Animator;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Object
{
    public class TextObject: GameObject
    {
        SpriteFont font;
        public string Text { get; set; }
        public Color Color { get; set; }

        public TextObject(Game game, Screen screen,SpriteFont font, Color color, int x, int y) : base(game, screen, null, x, y, 0, 0)
        {
            this.font = font;
            Text = "null";
            this.Color = color;
        }
        public override void Draw(SpriteBatch batch)
        {
         

            batch.Begin(transformMatrix: game.GetScaleMatrix());

            batch.DrawString(font, Text, new Vector2((float)ActX, (float)ActY), Color);
            batch.End();

            foreach (GameObjectAnimator a in Animators) a.Draw(batch);
        }
    }
}
