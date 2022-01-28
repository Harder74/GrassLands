using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GrassLands.Collisions;

namespace GrassLands
{
    public class PlayerController
    {
        private KeyboardState keyboardState;

        private Texture2D _texture;

        private Vector2 position;

        private BoundingRectangle bounds = new BoundingRectangle(new Vector2(200 - 16, 200 - 16), 16, 9);

        public BoundingRectangle Bounds => bounds;

        public Color Color { get; set; } = Color.White;

        public PlayerController(Vector2 pos)
        {
            position = pos;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("tilesPacked");
        }

        /// <summary>
        /// Updates the sprite's position based on user input
        /// </summary>
        /// <param name="gameTime">The GameTime</param>
        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            // Apply keyboard movement
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) position += new Vector2(0, -1) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) position += new Vector2(0, 1) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                position += new Vector2(-1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                position += new Vector2(1, 0) * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds;
                
            }
            bounds.X = position.X + 7;
            bounds.Y = position.Y + 23;
        }

        /// <summary>
        /// Draws the sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            spriteBatch.Draw(_texture, position, new Rectangle(225, 97, 30, 30), Color, 0f, new Vector2(0,0), 1f, SpriteEffects.None, 0);
            
        }
    }
}
