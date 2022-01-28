using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace GrassLands
{
    public class CampfireSprite
    {
        private const float ANIMATION_SPEED = 0.33f;

        private double animationTimer;

        private int animationFrame;

        private Vector2 position;

        private Texture2D texture;

        public CampfireSprite(Vector2 position)
        {
            this.position = position;
           
        }

        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("CampFireFinished");
        }

        /// <summary>
        /// Draws the animated sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > ANIMATION_SPEED)
            {
                animationFrame++;
                if (animationFrame > 4) animationFrame = 0;
                animationTimer -= ANIMATION_SPEED;
            }

            int frameStart = 0; 
            if (animationFrame == 0)
            {
                frameStart = animationFrame * 32 + 16;
            }
            else
            {
                frameStart = animationFrame * 64 + 16;
            }
           
            var source = new Rectangle(frameStart, 0, 32, 64);
            spriteBatch.Draw(texture, position, source, Color.White, 0f, new Vector2(16,32), .8f, SpriteEffects.None, 0);
        }
    }
}
