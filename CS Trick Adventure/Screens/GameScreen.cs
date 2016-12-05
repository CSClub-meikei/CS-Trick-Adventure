using CS_Trick_Adventure.Objects;
using MonoGameLibrary.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace CS_Trick_Adventure.Screens
{
    public class GameScreen :Screen
    {

        public List<Sprite> AllSprite = new List<Sprite>();
        public List<WorldObject> AllObjects = new List<WorldObject>();

        public List<Sprite> Sprites = new List<Sprite>();
        public List<WorldObject> Objects = new List<WorldObject>();
        Player player;
        TextObject info;

        public GameScreen(Game1 game, double x = 0, double y = 0) : base(game, x, y)
        {
            Assets.LoadGameGraphics();
            info = new TextObject(game, this, game.DebugFont, Color.White, 0, 0);
            AllObjects.Add(new Floor(game, this, Floor.Top, 0, 500, 500, 100));
            AllObjects.Add(new Floor(game, this, Floor.Right, 500, 600, 100, 400));
            AllObjects.Add(new Floor(game, this, Floor.Fill, 0, 600, 500, 400));
            AllObjects.Add(new Floor(game, this, Floor.TopRightCorner, 500, 500, 100, 100));
            AllObjects.Add(new Floor(game, this, Floor.BottomRightCorner, 500, 1000, 100, 100));
            player = new Player(game, this, 0, 0, 100, 100);
        }

        public override void Update(double deltaTime)
        {

            for (int i = 0; i < Sprites.Count; i++) Sprites[i].Update(deltaTime);

            for (int i = 0; i < AllObjects.Count; i++)
            {
                if (CheckOnScreen(AllObjects[i]) && Objects.IndexOf(AllObjects[i])==-1) Objects.Add(AllObjects[i]);
                else if (!CheckOnScreen(AllObjects[i]))Objects.Remove(AllObjects[i]);
            }
            for (int i = 0; i < Objects.Count; i++) Objects[i].Update(deltaTime);
            player.Update(deltaTime);
            if (player.X > 500) Camera = new Point((int)player.X - 500,0);
            info.Text = "all" + AllObjects.Count + "\nloaded" +  Objects.Count.ToString();
            base.Update(deltaTime);
        }

        public override void Draw(SpriteBatch batch)
        {

            for (int i = 0; i < Sprites.Count; i++) Sprites[i].Draw(batch);
            for (int i = 0; i < Objects.Count; i++) Objects[i].Draw(batch);
            player.Draw(batch);
            info.Draw(batch);
            base.Draw(batch);
        }
        public bool CheckOnScreen(GameObject o)
        {
            if (o.X < Camera.X + 1920 && Camera.X - 0 < o.X + o.Width && o.Y < Camera.Y + 1920 && Camera.Y - 0 < o.Y + o.Height) return true;
            else return false;
        }
    }
}
