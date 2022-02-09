using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NOT_Space_Invaders
{
    class Enemy : Sprite
    {
        private bool isAlive;
        private Sprite otherSprite;

        public Enemy(Rectangle inPosition, Texture2D inTexture, Color inColour, Sprite inOtherSprite, bool inAlive) :base(inPosition, inTexture, inColour)
        {
            otherSprite = inOtherSprite;
            isAlive = inAlive;
        }

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

    }
}
