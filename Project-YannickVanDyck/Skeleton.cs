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

        public bool stopLeft = true;
        public bool stopRight = false;
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

            collisionRectangleLeft = new Rectangle((int)position.X, (int)position.Y, 10, 50);
            collisionRectangleRight = new Rectangle((int)position.X, (int)position.Y, 10, 50);
        }

        public Rectangle CollisionRectangleLeft { get => collisionRectangleLeft; set => collisionRectangleLeft = value; }
        public Rectangle CollisionRectangleRight { get => collisionRectangleRight; set => collisionRectangleRight = value; }

        public void Update(GameTime gameTime)
        {
            animationMove.Update(gameTime);

            Vector2 temp = position;
            temp.X += velocity.X;
            temp.Y += velocity.Y;

            if (position.X < 0 || stopLeft)
            {
                temp.X += 0.5f;
            }
            else if (position.X > 1920 || stopRight)
            {
                temp.X -= 0.5f;
            }

            if (!stopFall) //Fall conditions
            {
                velocity.Y += (2 * gravity) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                //temp.Y -= 5;
            }
            if (stopFall) //Don't fall conditions
            {
                velocity.Y = 0;
                stopFall = false; // Zorgt ervoor dat als je van een blok stapt je valt en niet blijft zweven
                temp.Y -= 0.05f;
            }
            position = temp;
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            if (stopLeft == true)
            {
                spriteBatch.Draw(textureRight, new Rectangle((int)position.X, (int)position.Y, 33, 49), animationMove.currentFrame.SourceRectangle, Color.White);
                //spriteBatch.Draw(textureRight, position, animationMove.currentFrame.SourceRectangle, Color.White);
            }
            if (stopRight == true)
            {
                spriteBatch.Draw(textureLeft, new Rectangle((int)position.X, (int)position.Y, 33, 49), animationMove.currentFrame.SourceRectangle, Color.White);
                //spriteBatch.Draw(textureLeft, position, animationMove.currentFrame.SourceRectangle, Color.White);
            } else
            {
                //spriteBatch.Draw(textureRight, position, animationMove.currentFrame.SourceRectangle, Color.White);
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
