using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using MonoGameLibrary.Animator;

namespace TestGame
{
    public class testObject:GameObject
    {
        public testObject(MonoGameLibrary.Game game, Screen screen, int x, int y, int width, int height) : base(game, screen, Assets.enemy, x, y, width, height)
        {
            TextureAnimator a = new TextureAnimator(game, this, Assets.smoke, 360, 0, 0.016);
            Animators.Add(a);
            a.Start();
        }
        
        public override void Draw(SpriteBatch batch)
        {
            foreach(GameObjectAnimator a in Animators)
            {
                a.Draw(batch);
            }
        }
    }
}
