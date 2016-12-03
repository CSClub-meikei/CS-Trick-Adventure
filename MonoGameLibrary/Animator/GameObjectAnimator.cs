using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLibrary.Object;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameLibrary.Animator
{
    public class GameObjectAnimator
    {

        public Game game { get; }
        public GameObject parent{get;set;}
        public double Delay { get; set; }
        public double Limit { get; set; }
        public double TotalTime { get; private set; }
        public bool Enable { get;  set; }
        public virtual event EventHandler Finish;
        public bool IsAnimate { get; set; }
        public GameObjectAnimator(Game game,GameObject parent)
        {
            this.game = game;
            this.parent = parent;
        }
        public virtual void Initialize()
        {

        }
        public virtual void Start()
        {

        }
        public virtual void Stop()
        {

        }
        public virtual void Update(double deltaTime)
        {
            if (!IsAnimate) return;
            TotalTime += deltaTime;
            
            if (TotalTime < Delay) Enable = false;
            else Enable = true;
        }
        public virtual void Draw(SpriteBatch batch)
        {

        }
    }
}
