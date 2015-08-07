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

            //draw message
            string msg = snakeGame.Message();
            spriteBatch.DrawString(snakeGame.RenderContext.FontContainer["scoreFont"],
                                   msg,
                                   MessageRenderLocation(msg),
                                   new Color(41, 128, 185));
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Vector2 MessageRenderLocation(string msg)
        {
            var msgSize = snakeGame.RenderContext.FontContainer["scoreFont"].MeasureString(msg);

            return new Vector2(GraphicsDevice.Viewport.Width / 2 - msgSize.X / 2,
               (GraphicsDevice.Viewport.Height - gameView.Height) / 2 - msgSize.Y / 2);
        }

        private void RenderSnakeGame()
        {
            renderer.Setup();
            GraphicsDevice.Clear(new Color(44, 62, 80));
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            snakeGame.Render();
            spriteBatch.End();

            renderer.Flush();
            GraphicsDevice.Clear(new Color(240, 240, 241));
        }
    }
}
