using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NOT_Space_Invaders
{
    class EnemyShip : Sprite
    {
        private Enemy[,] enemiesArray;
        private const int SPACE_BETWEEN_ENEMIES = 10;
        private bool leftORright = true;
        private bool isAlive;
        private Sprite otherSprite;
        private Texture2D[] enemyTextures = new Texture2D[4];

        public EnemyShip(Rectangle inPosition, Texture2D inTexture, Color inColour, Enemy[,] inArray, bool inAlive, Sprite inOtherSprite, Texture2D[] inEnemyTextures) : base(inPosition, inTexture, inColour)
        {
            enemiesArray = inArray;
            isAlive = inAlive;
            otherSprite = inOtherSprite;
            enemyTextures = inEnemyTextures;
        }

        public Enemy[,] EnemiesArray
        {
            get { return enemiesArray; }
        }

        public void DecideEnemyPositions()
        {
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    enemiesArray[i, j] = new Enemy(new Rectangle(i * (spriteTexture.Width + SPACE_BETWEEN_ENEMIES), j * (spriteTexture.Height + SPACE_BETWEEN_ENEMIES) + 10, enemyTextures[j].Width, enemyTextures[j].Height), enemyTextures[j], spriteColour, otherSprite, true);
                }
            }
        }

        public void EnemyMovement()
        {
            if(enemiesArray[0, 0].GetPosition().X <= 0)
            {
                leftORright = true;
            }

            else if(enemiesArray[9, 3].GetPosition().X + spriteTexture.Width >= GraphicsDeviceManager.DefaultBackBufferWidth)
            {
                leftORright = false;
            }

            if(leftORright == true)
            {
                foreach(Enemy e in enemiesArray)
                {
                    e.SetPosition(new Rectangle(e.GetPosition().X + 1, e.GetPosition().Y, spriteTexture.Width, spriteTexture.Height));
                }
            }

            else
            {
                foreach(Enemy e in enemiesArray)
                {
                    e.SetPosition(new Rectangle(e.GetPosition().X - 1, e.GetPosition().Y, spriteTexture.Width, spriteTexture.Height));
                }
            }
        }

    }
}
