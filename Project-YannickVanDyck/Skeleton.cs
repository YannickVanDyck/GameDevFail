using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    public class Skeleton : ICollideSkeleton
    {
        private Texture2D textureLeft;
        private Texture2D textureRight;

        private Vector2 _position;
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
                temp.X += 0;
                CollisionRectangleLeft = temp;
                temp.X += temp.Width + 2;
                CollisionRectangleRight = temp;
            }
        }

        public Game1 _game;

        Animation animationMove;

        bool left = false;
        bool right = false;

        public bool stopFall = false;

        public Vector2 velocity;
        public float gravity = 9.8f;

        private Rectangle collisionRectangleLeft;
        private Rectangle collisionRectangleRight;

        Texture2D t1;
        Texture2D t2;

        public bool isDead = false;


        public Skeleton(Texture2D _textureLeft, Texture2D _textureRight, Vector2 _position)
        {
            textureLeft = _textureLeft;
            textureRight = _textureRight;
            position = _position;

            animationMove = new Animation();
            animationMove.AddFrame(new Rectangle(0, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(22, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(44, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(66, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(88, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(110, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(132, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(154, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(176, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(198, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(220, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(242, 0, 22, 33));
            animationMove.AddFrame(new Rectangle(264, 0, 22, 33));

            collisionRectangleLeft = new Rectangle((int)position.X, (int)position.Y, 10, 33);
            collisionRectangleRight = new Rectangle((int)position.X, (int)position.Y, 10, 33);
        }

        public Rectangle CollisionRectangleLeft { get => collisionRectangleLeft; set => collisionRectangleLeft = value; }
        public Rectangle CollisionRectangleRight { get => collisionRectangleRight; set => collisionRectangleRight = value; }

        public void Update(GameTime gameTime)
        {
            animationMove.Update(gameTime);

            Vector2 temp = position;
            temp.X += velocity.X;
            temp.Y += velocity.Y;

            if (!stopFall) //Fall conditions
            {
                velocity.Y += (2 * gravity) * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (stopFall) //Don't fall conditions
            {
                velocity.Y = 0;
                stopFall = false; // Zorgt ervoor dat als je van een blok stapt je valt en niet blijft zweven
            }


            if (position.X < 100)
            {
                right = true;
                left = false;
            }
            if (position.X >= 100 && position.X <= 700)
            {
                right = true;
                left = false;
            }
            if (position.X > 700)
            {
                right = false;
                left = true;
            }

            if (right == true)
            {
                temp.X += 0.5f;
            }
            if (left == true)
            {
                temp.X -= 0.5f;
            }
            position = temp;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            if (right == true)
            {
                spriteBatch.Draw(textureRight, position, animationMove.currentFrame.SourceRectangle, Color.White);
            }
            if (left == true)
            {
                spriteBatch.Draw(textureLeft, position, animationMove.currentFrame.SourceRectangle, Color.White);
            } else
            {
                spriteBatch.Draw(textureRight, position, animationMove.currentFrame.SourceRectangle, Color.White);
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
