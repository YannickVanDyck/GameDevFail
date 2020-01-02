using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Web.UI.WebControls;

namespace Project_YannickVanDyck
{
    public class Hero : ICollideHero
    {
        private Texture2D textureLeft;
        private Texture2D textureRight;

        public Game1 _game;
        
        
        private Vector2 _position { get; set; }
        public Vector2 position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                Rectangle temp = CollisionRectangleLeft;
                temp.Location = _position.ToPoint();
                temp.X += 25;
                CollisionRectangleLeft = temp;
                temp.X += temp.Width;
                CollisionRectangleRight = temp;
            }
        }



        public Vector2 velocity;
        Animation animationIdle;
        Animation animationMove;
        Animation animationJump;
        public float gravity = 9.8f;
        private Rectangle collisionRectangleLeft;
        private Rectangle collisionRectangleRight;
        public Controls _controls { get; set; }

        public bool stopLeft = false;
        public bool stopRight = false;
        public bool stopJump = false;
        public bool stopFall = false;

        public bool isDead = false;

        Texture2D t1;
        Texture2D t2;


        public Hero(Texture2D _textureLeft, Texture2D _textureRight, Vector2 _position)
        {
            textureLeft = _textureLeft;
            textureRight = _textureRight;
            position = _position;

            animationIdle = new Animation();
            animationIdle.AddFrame(new Rectangle(0, 0, 82, 132));
            animationIdle.AddFrame(new Rectangle(81, 0, 82, 132));
            animationIdle.AddFrame(new Rectangle(164, 0, 82, 132));
            animationIdle.AddFrame(new Rectangle(245, 0, 82, 132));

            animationMove = new Animation();
            animationMove.AddFrame(new Rectangle(0, 132, 109, 132));
            animationMove.AddFrame(new Rectangle(109, 132, 109, 132));
            animationMove.AddFrame(new Rectangle(218, 132, 109, 132));
            animationMove.AddFrame(new Rectangle(0, 264, 109, 132));
            animationMove.AddFrame(new Rectangle(109, 264, 109, 132));
            animationMove.AddFrame(new Rectangle(218, 264, 109, 132));

            animationJump = new Animation();
            animationJump.AddFrame(new Rectangle(218, 396, 109, 132));
            animationJump.AddFrame(new Rectangle(109, 396, 109, 132));
            animationJump.AddFrame(new Rectangle(0, 396, 109, 132));

            collisionRectangleLeft = new Rectangle((int)position.X, (int)position.Y, 25, 115);
            collisionRectangleRight = new Rectangle((int)position.X, (int)position.Y, 50, 115);
        }
        double xOffset = 0;

        public Rectangle CollisionRectangleLeft { get => collisionRectangleLeft; set => collisionRectangleLeft = value; }
        public Rectangle CollisionRectangleRight { get => collisionRectangleRight; set => collisionRectangleRight = value; }

        public void Update(GameTime gameTime)
        {
            animationMove.Update(gameTime);
            animationJump.Update(gameTime);
            animationIdle.Update(gameTime);
            _controls.Update();
            Vector2 temp = position;
            temp.X += velocity.X;
            temp.Y += velocity.Y;

            if (_controls.left && !stopLeft)
            {
                temp.X -= 3;
                stopRight = false;
            }
            if (_controls.right && !stopRight)
            {
                temp.X += 3;
                stopLeft = false;
            }

            if (_controls.up && !stopJump) //Jump conditions
            {
                velocity.Y = -10;
                stopFall = false;
                stopJump = true;
            }

            if (!_controls.up && !stopFall || _controls.up && stopJump || !_controls.up && stopJump) //Fall conditions
            {
                velocity.Y += (2 * gravity) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (!_controls.up && stopFall || _controls.up && stopFall) //Don't fall conditions
            {
                velocity.Y = 0;
                stopFall = false;
                //stopJump = false;
            }

            if (temp.Y > 1080)
            {
                isDead = true;
            }
            position = temp;
        }


        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            if (!_controls.left && !_controls.right && !_controls.idleLeft)
            {
                spriteBatch.Draw(textureRight, position, animationIdle.currentFrame.SourceRectangle, Color.White);
            }
            if (!_controls.left && !_controls.right && _controls.idleLeft)
            {
                spriteBatch.Draw(textureLeft, position, animationIdle.currentFrame.SourceRectangle, Color.White);
            }
            if (_controls.left && !_controls.up)
            {
                spriteBatch.Draw(textureLeft, position, animationMove.currentFrame.SourceRectangle, Color.White);
            }
            if (_controls.right && !_controls.up)
            {
                spriteBatch.Draw(textureRight, position, animationMove.currentFrame.SourceRectangle, Color.White);
            }
            if (_controls.up && _controls.left)
            {
                spriteBatch.Draw(textureLeft, position, animationJump.currentFrame.SourceRectangle, Color.White);
            }
            if (_controls.up && _controls.right)
            {
                spriteBatch.Draw(textureRight, position, animationJump.currentFrame.SourceRectangle, Color.White);
            }

            if (t1 == null || t2 == null)
            {
                t1 = GroundLayer.CreateTexture(device, CollisionRectangleLeft.Width, CollisionRectangleLeft.Height, pixel => Color.Red);
                t2 = GroundLayer.CreateTexture(device, CollisionRectangleRight.Width, CollisionRectangleRight.Height, pixel => Color.Green);
            }
            //spriteBatch.Draw(t1, CollisionRectangleLeft, Color.White);
            //spriteBatch.Draw(t2, CollisionRectangleRight, Color.White);
        }
    }
}
