using Microsoft.Xna.Framework;
using MonoGameLibrary;
using MonoGameLibrary.Animator;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame
{
    public class Button:UiObject
    {
        MoveAnimator a;
        public Button(MonoGameLibrary.Game game, Screen screen, int x, int y, int width, int height) : base(game,screen,Assets.getColorTexture(game,Color.Blue),x,y,width,height)
        {
            OnHover += onHover;
            OnLeave += onLeave;
            OnDown += onClick;
            a = new MoveAnimator(game, this, 1,1, new Point(0, 0), new Point(100, 100), new Point(1000, 400), new Point(1000, 500));
            Animators.Add(a);
        }
        public void onHover(object sender,UiEventArgs e)
        {
            Texture = Assets.getColorTexture(game, Color.Yellow);
        }
        public void onLeave(object sender,UiEventArgs e)
        {
            Texture = Assets.getColorTexture(game, Color.Blue);
        }
        public void onClick(object sender, UiEventArgs e)
        {
            DebugMessage = "Clicked";
            a.Start();
        }
       
    }
}
