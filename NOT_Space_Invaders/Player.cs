using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NOT_Space_Invaders
{
    class Player : Sprite
    {

        private int livesPlayer = 3;
        private bool endGame = false;
        public Player(Rectangle inPosition, Texture2D inTexture, Color inColour) : base(inPosition, inTexture, inColour)
        {

        }

        public void Movement()
        {

            if(spritePosition.X >= 0 && spritePosition.X + spriteTexture.Width <= GraphicsDeviceManager.DefaultBackBufferWidth)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    spritePosition.X = spritePosition.X - 1;
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    spritePosition.X = spritePosition.X + 1;
                }
            } // While within bounds, keep moving

            else
            {
                if (spritePosition.X < 0)
                {
                    spritePosition.X = spritePosition.X + 1;
                }

                if(spritePosition.X + spriteTexture.Width > GraphicsDeviceManager.DefaultBackBufferWidth)
                {
                    spritePosition.X = spritePosition.X - 1;
                }
            } // If outside bounds, bring player back

        }

        public void CalculateLife()
        {
            livesPlayer = livesPlayer - 1;

            if(livesPlayer <= 0)
            {
                endGame = true;
            }
        }
    }
}
