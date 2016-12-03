using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary.Object;
using System.Collections.Generic;

namespace MonoGameLibrary
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game : Microsoft.Xna.Framework.Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        protected List<Screen> screens = new List<Screen>();

        protected List<Screen> removeScreens = new List<Screen>();
        protected List<Screen> addScreens = new List<Screen>();
        protected List<Screen> InsertScreens = new List<Screen>();

        public bool DebugMode = false;

        protected bool clearScreenFlag = false;

        public SpriteFont DebugFont;

        protected int fps;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            DebugFont = Content.Load<SpriteFont>("DebugFont");
            Input.Initialize(this);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
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

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            double deltaTime = FpsCounter.getDeltaTime(gameTime);
            fps = FpsCounter.fpsCounter(deltaTime)/1000;
            foreach (Screen s in screens)
                s.Update(deltaTime);

            foreach (Screen s in removeScreens)
                screens.Remove(s);

            foreach (Screen s in addScreens)
                screens.Add(s);

            removeScreens.Clear();
            addScreens.Clear();

            if (clearScreenFlag) screens.Clear();
            // TODO: Add your update logic here
            Input.update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Screen s in screens) s.Draw(spriteBatch);

            base.Draw(gameTime);
        }

        public Matrix GetScaleMatrix()
        {
            var scaleX = (float)graphics.PreferredBackBufferWidth / 1920;
            var scaleY = (float)graphics.PreferredBackBufferHeight / 1080;
            return Matrix.CreateScale(scaleX, scaleY, 1.0f);
        }
        public void SetWindowSize(int width,int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
        }
        public void removeScreen(Screen screen)
        {
            removeScreens.Add(screen);
        }
        public void AddScreen(Screen screen)
        {
            addScreens.Add(screen);
        }
        public void InsertScreen(Screen screen)
        {
            InsertScreens.Add(screen);
        }
        public void clearScreen()
        {
            clearScreenFlag = true;
        }
    }
}
