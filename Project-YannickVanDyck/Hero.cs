using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    public class Hero :ICollide
    {
        private Texture2D textureLeft;
        private Texture2D textureRight;
        public Vector2 position;
        public Vector2 velocity;
        Animation animationIdle;
        Animation animationMove;
        Animation animationJump;
        public float gravity = 9.8f;
        private Rectangle collisionRectangle;
        public Controls _controls { get; set; }


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

            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, 109, 132);
        }
        double xOffset = 0;

        public Rectangle CollisionRectangleTop { get => collisionRectangle; set => collisionRectangle = value; }

        public void Update(GameTime gameTime)
        {
            animationMove.Update(gameTime);
            animationJump.Update(gameTime);
            animationIdle.Update(gameTime);
            _controls.Update();
            position.X += velocity.X;
            position.Y += velocity.Y;

            if (_controls.left)
            {
                position.X -= 3;
            }
            if (_controls.right)
            {
                position.X += 3;
            }

            if (_controls.up && position.Y > 840)
            {
                velocity.Y = -10;
            }
            if (!_controls.up && position.Y < 850) //position vervangen door hitboxes van grond
            {
                velocity.Y += (2 * gravity) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (!_controls.up && position.Y > 850) //position vervangen door hitboxes van grond
            {
                velocity.Y = 0;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
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
        }

        /*public Rectangle CollisionRectangle
        {
            get => 
        }*/
    }
}
