using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NOT_Space_Invaders
{
    class Animation : Sprite
    {
        private int frames; //How many times it changes sprite per second
        private float timeElapsed, timeToUpdate; //Time between updates
        private bool isLooping = true;

        private Vector2 origin; //Where we're getting our image from
        //MUST place f at the end to show that it's a float
        private float spriteRotation = 0.0f;
        private float spriteScale = 0.0f;
        private SpriteEffects animationEffects;
        private Rectangle[] spriteRectangles; //Array of the animation positions
        private int frameIndex = 0; //Counter to see if you're at the number of frames needed
        private int spriteDepth;

        public Animation(Rectangle inPosition, Texture2D inTexture, Color inColour, float inSpriteRotation, float inSpriteScale, SpriteEffects inAnimationEffects, int inFrames) : base(inPosition, inTexture, inColour)
        {
            spriteTexture = inTexture;
            int width = inTexture.Width / inFrames; //Find how big each frame should be
            spriteRectangles = new Rectangle[inFrames];

            for(int i = 0; i < inFrames; i++)
            {
                spriteRectangles[i] = new Rectangle(i * width, 0, width, spriteTexture.Height / 2);
            }
        }

        public int FPS
        {
            set { timeToUpdate = (1f / value); } //Gives a consistent experience
        }

        public void Update(GameTime inGameTime)
        {
            timeElapsed += (float)inGameTime.ElapsedGameTime.TotalSeconds;

            if(timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if(frameIndex < spriteRectangles.Length - 1)
                {
                    frameIndex++;
                }
                else if(isLooping)
                {
                    frameIndex = 0;
                }
            }
        }

        public void DrawAnimation(SpriteBatch spritebatch, Rectangle enemyPositions)
        {
            spritebatch.Draw(spriteTexture, new Vector2(enemyPositions.X, enemyPositions.Y), spriteRectangles[frameIndex], Color.White);
        }

    }
}
