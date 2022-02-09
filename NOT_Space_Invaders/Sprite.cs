using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NOT_Space_Invaders
{
    class Sprite
    {
        protected Rectangle spritePosition;
        protected Texture2D spriteTexture;
        protected Color spriteColour;

        public Sprite(Rectangle inPosition, Texture2D inTexture, Color inColour)
        {
            spritePosition = inPosition;
            spriteTexture = inTexture;
            spriteColour = inColour;
        }

        public void DrawSprite(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spriteTexture, spritePosition, spriteColour);
        } // Allows for sprites to be drawn

        public Rectangle GetPosition()
        {
            return spritePosition;
        } // Allows for anything that inherits Sprite to get its position

        public void SetPosition(Rectangle newPosition)
        {
            spritePosition = newPosition;
        }

        public Texture2D GetTexture()
        {
            return spriteTexture;
        } // Allos anything that inherits Sprite to be able to get the texture of
    }
}
