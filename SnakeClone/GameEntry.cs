using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SnakeClone.Rendering;

namespace SnakeClone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameEntry : Game
    {
        private IRenderer renderer;
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private SnakeClone snakeGame;
        private Rectangle gameView;

        public GameEntry()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Components.Add(new Input.InputManager(this));
            gameView = new Rectangle(5, 40, 290, 290);
            Window.Title = "SnakeClone";
            graphics.PreferredBackBufferWidth = 300;
            graphics.PreferredBackBufferHeight = 335;
            graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            renderer = new PlainRenderer(GraphicsDevice);
            snakeGame = new SnakeClone(renderer.Initialize,
                                       new Map.LevelTracker(),
                                       new Providers.HardCodedAssetProvider(),
                                       spriteBatch,
                                       Content);
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

            snakeGame.Update(gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            RenderSnakeGame();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            spriteBatch.Draw(renderer.Target, gameView, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void RenderSnakeGame()
        {
            renderer.Setup();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            snakeGame.Render();
            spriteBatch.End();

            renderer.Flush();
            GraphicsDevice.Clear(new Color(240,240,241));
        }
    }
}
