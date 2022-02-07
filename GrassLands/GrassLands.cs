using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using GrassLands.Collisions;

namespace GrassLands
{
    public class GrassLands : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private PlayerController _player;
        private CampfireSprite _campFire;
        private Texture2D _grassLands;
        private SpriteFont _centaur;
        private Texture2D _ball;

        

        public GrassLands()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Window.Title = "GrassLands";
            _player = new PlayerController( new Vector2(200,200));
            _campFire = new CampfireSprite(new Vector2(400,400));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _grassLands = Content.Load<Texture2D>("tilesPacked");
            _player.LoadContent(Content);
            _campFire.LoadContent(Content);
            _ball = Content.Load<Texture2D>("ball");
            _centaur = Content.Load<SpriteFont>("Centaur");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _player.Update(gameTime);
            // TODO: Add your update logic here
            if (_player.Bounds.CollidesWith(_campFire.Bounds)) Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            _spriteBatch.Draw(_grassLands, new Vector2(200,200), new Rectangle(0, 0, 32,32),Color.White);
            _spriteBatch.Draw(_grassLands, new Vector2(200, 232), new Rectangle(0, 32, 32, 16), Color.White);
            _spriteBatch.Draw(_grassLands, new Vector2(200, 248), new Rectangle(0, 32, 32, 16), Color.White);
            _spriteBatch.Draw(_grassLands, new Vector2(200, 264), new Rectangle(0, 48, 32, 32), Color.White);
            _player.Draw(gameTime, _spriteBatch);

            /*
            var rect = new Rectangle((int)_player.Bounds.X, (int)_player.Bounds.Y, (int)_player.Bounds.Width, (int)_player.Bounds.Height);
            _spriteBatch.Draw(_ball, rect, Color.White);
            */

            _campFire.Draw(gameTime, _spriteBatch);
            /*
            var rect2 = new Rectangle((int)_campFire.Bounds.X, (int)_campFire.Bounds.Y, (int)_campFire.Bounds.Width, (int)_campFire.Bounds.Height);
            _spriteBatch.Draw(_ball, rect2, Color.White);
            */
            _spriteBatch.DrawString(_centaur, "Step into the flames to Exit.", new Vector2(350, 340), Color.Gold);
            _spriteBatch.DrawString(_centaur, "Use W, A, S, D to move the character.", new Vector2(150, 100), Color.Gold);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
