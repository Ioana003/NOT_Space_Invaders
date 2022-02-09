using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NOT_Space_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D testTexture;
        private Texture2D[] enemyTexture = new Texture2D[4];
        private Texture2D playerShipTexture;
        private Texture2D bulletTexture;
        private Texture2D testSpriteSheet;

        private Sprite baseSprite;
        private Player Player1;
        private Bullet bulletPlayer;
        private Enemy[,] enemySprite = new Enemy[10, 4];
        private EnemyShip shipBase;
        private Animation[,] testAnimate = new Animation[10, 4];


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            testTexture = Content.Load<Texture2D>("Brick");
            enemyTexture[3] = Content.Load<Texture2D>("NOT_Space_Invaders Lower Enemy");
            enemyTexture[2] = Content.Load<Texture2D>("NOT_Space_Invaders Middle Enemy");
            enemyTexture[1] = Content.Load<Texture2D>("NOT_Space_Invaders Middle Enemy");
            enemyTexture[0] = Content.Load<Texture2D>("NOT_Space_Invaders Top Enemy");
            playerShipTexture = Content.Load<Texture2D>("NOT_Space_Invaders Player Ship");
            bulletTexture = Content.Load<Texture2D>("NOT_Space_Invaders Bullet");
            testSpriteSheet = Content.Load<Texture2D>("NOT Space Invaders Spritesheet");

            Player1 = new Player(new Rectangle(Window.ClientBounds.Width / 2 - playerShipTexture.Width / 2, Window.ClientBounds.Height - playerShipTexture.Height - 5, playerShipTexture.Width, playerShipTexture.Height), playerShipTexture, Color.Red);
            bulletPlayer = new Bullet(new Rectangle(Window.ClientBounds.Width / 2 - bulletTexture.Width, Window.ClientBounds.Height - bulletTexture.Height - 5, bulletTexture.Width, bulletTexture.Height - 3), bulletTexture, Color.Green, false);
            shipBase = new EnemyShip(new Rectangle(0, 0, enemyTexture[0].Width, enemyTexture[0].Height), enemyTexture[0], Color.White, enemySprite, true, bulletPlayer, enemyTexture);
            
            for(int a = 0; a < testAnimate.GetUpperBound(0); a++)
            {
                for (int i = 0; i < testAnimate.GetUpperBound(1); i++)
                {
                    testAnimate[a, i] = new Animation(shipBase.GetPosition(), testSpriteSheet, Color.White, 0f, 0f, new SpriteEffects(), 4);
                }
            }

            shipBase.DecideEnemyPositions();
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Player1.Movement();

            bulletPlayer.MoveWithPlayer(Player1);

            bulletPlayer.ShotOut();

            shipBase.EnemyMovement();

            foreach (Animation a in testAnimate)
            {
                a.Update(gameTime);
                a.FPS = 1;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            for(int i = 0; i < enemySprite.GetUpperBound(0); i++)
            {
                for(int j = 0; j < enemySprite.GetUpperBound(1); j++)
                {
                    if (enemySprite[i,j].IsAlive)
                    {
                        enemySprite[i,j].DrawSprite(_spriteBatch);

                        testAnimate[i, j].SetPosition(enemySprite[i,j].GetPosition());
                        testAnimate[i,j].DrawAnimation(_spriteBatch);

                        if (enemySprite[i,j].GetPosition().Intersects(bulletPlayer.GetPosition()))
                        {
                            enemySprite[i,j].IsAlive = false;
                            bulletPlayer.HasBeenShot = false;
                        }
                    }
                }
            }

            bulletPlayer.DrawSprite(_spriteBatch);
            Player1.DrawSprite(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
