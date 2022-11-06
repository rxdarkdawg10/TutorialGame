using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TutorialGame.Source.Engine.Input;
using TutorialGame.Source.Engine;
using TutorialGame.Source;

namespace TutorialGame
{
    public class Main : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        clsGamePlay gamePlay;
        Basic2d cursor;

        public Main()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = false;

            Globals.screenHeight = 900; //900
            Globals.screenWidth = 1600; //1600

            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;

            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.content = this.Content;
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cursor = new Basic2d("2d\\Misc\\Cursor", new Vector2(0, 0), new Vector2(28, 28));

            Globals.normalEffect = Globals.content.Load<Effect>("Effects\\Normal");

            Globals.keyboard = new clsKeyboard();
            Globals.mouse = new clsMouseControl();

            gamePlay = new clsGamePlay();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Globals.gameTime = gameTime;
            Globals.keyboard.Update();
            Globals.mouse.Update();

            gamePlay.Update();


            Globals.keyboard.UpdateOld();
            Globals.mouse.UpdateOld();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // Open SpriteBatch for Drawing
            Globals.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);


            gamePlay.Draw();

            cursor.Draw(new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2(0, 0), Color.White);

            // End SpriteBatch
            Globals.spriteBatch.End();
            base.Draw(gameTime);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            using var game = new Main();
            game.Run();
        }
    }
}