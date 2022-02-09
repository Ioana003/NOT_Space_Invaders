using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NOT_Space_Invaders
{
    class Bullet : Sprite
    {
        private bool hasBeenShot;

        public Bullet(Rectangle inPosition, Texture2D inTexture, Color inColour, bool shotORnot) : base(inPosition, inTexture, inColour)
        {
            hasBeenShot = shotORnot;
        }

        public void MoveWithPlayer( Sprite inSprite) // Now properly uses the actual sprite of the player for positioning.
        {
            // DIVIDED BY 20 MUST BE CHANGED ONCE SPRITE CHANGES AS WELL
            if (hasBeenShot == false)
            {
                spritePosition.Y = GraphicsDeviceManager.DefaultBackBufferHeight - inSprite.GetTexture().Height - 3;
                spritePosition.X = inSprite.GetPosition().X + inSprite.GetTexture().Width / 2 - spriteTexture.Width / 20;
            }
        }

        public bool HasBeenShot
        {
            set { hasBeenShot = value; }
            get { return hasBeenShot; }
        }

        public void ShotOut() // Moves the bullet upwards to "shoot"
        {
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                hasBeenShot = true;
            }

            if(hasBeenShot == true && spritePosition.Y >= 0)
            {
                spritePosition.Y = spritePosition.Y - 3;
            }

            else
            {
                hasBeenShot = false;
            }        
        }

    }
}
