using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    class Skeleton : ICollide
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
                Rectangle temp = CollisionRectangleTop;
                temp.Location = _position.ToPoint();
                temp.X += 0;
                CollisionRectangleTop = temp;
                temp.Y += temp.Height + 7;
                CollisionRectangleBottom = temp;
            }
        }

        public Game1 _game;

        Animation animationMove;

        bool left = false;
        bool right = false;

        private Rectangle collisionRectangleTop;
        private Rectangle collisionRectangleBottom;

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

            collisionRectangleTop = new Rectangle((int)position.X, (int)position.Y, 22, 15);
            collisionRectangleBottom = new Rectangle((int)position.X, (int)position.Y + 18, 22, 15);
        }

        public Rectangle CollisionRectangleTop { get => collisionRectangleTop; set => collisionRectangleTop = value; }
        public Rectangle CollisionRectangleBottom { get => collisionRectangleBottom; set => collisionRectangleBottom = value; }

        public void Update(GameTime gameTime)
        {
            animationMove.Update(gameTime);

            Vector2 temp = position;
            //temp.X += velocity.X;
            //temp.Y += velocity.Y;

            if (position.X < 200)
            {
                right = true;
                left = false;
            }
            if (position.X > 500)
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
            }


            if (t1 == null || t2 == null)
            {
                t1 = GroundLayer.CreateTexture(device, CollisionRectangleTop.Width, CollisionRectangleTop.Height, pixel => Color.Red);
                t2 = GroundLayer.CreateTexture(device, CollisionRectangleBottom.Width, CollisionRectangleBottom.Height, pixel => Color.Green);
            }
            spriteBatch.Draw(t1, CollisionRectangleTop, Color.White);
            spriteBatch.Draw(t2, CollisionRectangleBottom, Color.White);
        }
    }
}
