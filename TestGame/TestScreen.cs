using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLibrary.Object;
using MonoGameLibrary;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGameLibrary.Animator;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    public class TestScreen:Screen
    {

        public List<GameObject> Objects = new List<GameObject>();
        public List<GameObject> AllObjects = new List<GameObject>();
        public List<enemy> Enemys = new List<enemy>();
        public List<enemy> RemoveEnemys = new List<enemy>();
        Player player;
        TextObject info;
        testObject test;
        Button button;
        public bool pause = false;
        public Point Camera
        {
            get
            {
                return new Point((int)X * -1, (int)Y * -1);
            }
            set
            {
                Point _point = new Point(value.X * -1, value.Y * -1);
                X = _point.X;
                Y = _point.Y;
            }
        }


        public TestScreen(Game1 game, double x = 0, double y = 0):base(game,x,y)
        {

            info = new TextObject(game, this, game.DebugFont, Color.White, 100,100);
            button = new Button(game, this, 1000, 100, 200, 100);
            player = new Player(game, this, 0, 0, 100, 100);
            test = new testObject(game, this, 0, 0, 100, 100);


            AllObjects.Add(new RigidBody(game, this, Assets.getColorTexture(game, Color.Yellow), 200, 0, 100, 100));
            AllObjects.Add(new Block(game, this, 0, 1000, 1920, 50));
            AllObjects.Add(new Block(game, this, 0, 0, 1920, 50));

            AllObjects.Add(new Block(game, this, 900, 600, 400, 400));
            AllObjects.Add(new Slope(game, this, 1, 300, 600, 600, 400));
            AllObjects.Add(new Slope(game, this, -1, 1300, 600, 400, 400));

            AllObjects.Add(new Block(game, this, 2000, 800, 300, 50));
            AllObjects.Add(new Floor(game, this, 2000, 600, 300, 5));

            AllObjects.Add(new enemy(game, this, 1920, 600, 80, 90));

            AllObjects.Add(new Block(game, this, 2500, 1000, 1920, 50));
            AllObjects.Add(new Block(game, this, 0, 800, 200, 200));
            int i = 0;
            foreach (GameObject o in AllObjects) {
                if (o is enemy) ((enemy)o).id = i;
                i++;
            }

        }

        public void RemoveEnemy(enemy o)
        {
            RemoveEnemys.Add(o);
        }

        public void create()
        {
            Random r = new Random();
            if (r.Next(50) == 2)
            {
                Enemys.Add(new enemy(game, this, 1800, 400, 80, 90));
            }
        }
        public override void Update(double deltaTime)
        {
            if (Input.IsKeyDown(Keys.P)) pause = !pause;
            if (pause) return;
            if (Input.IsKeyDown(Keys.Up))
            {
                Scale += 0.01;
                X -= 19;
                Y -= 10;
            }
            if (Input.IsKeyDown(Keys.Down))
            {
                Scale -= 0.01;
                X += 19;
                Y += 10;
            }

            foreach (GameObject o in AllObjects)
            {
                if (CheckOnScreen(o))
                {
                    if (o is enemy && SearchEnemy((enemy)o)==null&&  !((enemy)o).dead ) Enemys.Add(((enemy)o).Clone());
                    else if (!(o is enemy) && Objects.IndexOf(o) == -1) Objects.Add(o);
                }
                else
                {
                    if (o is enemy && SearchEnemy((enemy)o)!=null) Enemys.Remove((enemy)o);
                    else if (!(o is enemy) && Objects.IndexOf(o) != 1) Objects.Remove(o);
                }
                if (o is enemy && SearchEnemy((enemy)o) != null && !CheckOnScreen(SearchEnemy((enemy)o))) Enemys.Remove(SearchEnemy((enemy)o));
            }


            foreach (GameObject o in Objects) o.Update(deltaTime);
            foreach (enemy o in Enemys) o.Update(deltaTime);
            foreach (enemy o in RemoveEnemys) Enemys.Remove(o);
            create();
            player.Update(deltaTime);
            button.Update(deltaTime);
            test.Update(deltaTime);
            info.Text = "All : " + AllObjects.Count + "\nLoaded : " + Objects.Count + "\nmob:" + Enemys.Count ;

            base.Update(deltaTime);
        }
        public override void Draw(SpriteBatch batch)
        {
            foreach (GameObject o in Objects) o.Draw(batch);
            foreach (GameObject o in Enemys) o.Draw(batch);
            player.Draw(batch);
            info.Draw(batch);
            button.Draw(batch);
            test.Draw(batch);
            base.Draw(batch);
        }

        public bool CheckOnScreen(GameObject o)
        {
            if (o.X < Camera.X + 1920 && Camera.X - 0 < o.X + o.Width && o.Y < Camera.Y + 1920 && Camera.Y - 0 < o.Y + o.Height) return true;
            else return false;
        }
        public enemy SearchEnemy(enemy e)
        {
            enemy flag = null;
            foreach(enemy o in Enemys)
            {
                if (o.id == e.id) flag = o;
            }
            return flag;
        }
    }
}
