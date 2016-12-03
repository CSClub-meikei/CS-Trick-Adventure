using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using System.IO;

namespace TestGame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : MonoGameLibrary.Game
    {

        Effect effect;
        public Game1()
        {
            Content.RootDirectory = "Content";
            SetWindowSize(1280, 720);
            //Window.IsBorderless = true;
            DebugMode = true;
            graphics.PreferMultiSampling = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Assets.Initialize(this);
            IsMouseVisible = true;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            //BinaryReader Reader = new BinaryReader(File.Open(@"Content\\NewEffect.fx", FileMode.Open));
           // effect = new Effect(GraphicsDevice, Reader.ReadBytes((int)Reader.BaseStream.Length));
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.Load();
            AddScreen(new TestScreen(this));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Window.Title = "fps:" + fps.ToString();
            
        }
       

    }
}
