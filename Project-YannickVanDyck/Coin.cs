using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    class Coin : ICollide
    {
        public Texture2D texture;
        public Vector2 position;
        Animation FloatingCoin;
        private Rectangle collisionRectangleTop;
        private Rectangle collisionRectangleBottom;

        Texture2D t1;
        Texture2D t2;

        public Coin(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;

            FloatingCoin = new Animation();
            FloatingCoin.AddFrame(new Rectangle(0, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(45, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(90, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(135, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(180, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(225, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(270, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(315, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(360, 0, 45, 42));
            FloatingCoin.AddFrame(new Rectangle(405, 0, 45, 42));

            collisionRectangleTop = new Rectangle((int)position.X, (int)position.Y, 45, 20);
            collisionRectangleBottom = new Rectangle((int)position.X, (int)position.Y + 22, 45, 20);
        }

        public Rectangle CollisionRectangleTop { get => collisionRectangleTop; set => collisionRectangleTop = value; }
        public Rectangle CollisionRectangleBottom { get => collisionRectangleBottom; set => collisionRectangleBottom = value; }

        public void Update(GameTime gameTime)
        {
            FloatingCoin.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 32, 32), FloatingCoin.currentFrame.SourceRectangle, Color.White);

            if (t1 == null || t2 == null)
            {
                t1 = GroundLayer.CreateTexture(device, CollisionRectangleTop.Width, CollisionRectangleTop.Height, pixel => Color.Red);
                t2 = GroundLayer.CreateTexture(device, CollisionRectangleBottom.Width, CollisionRectangleBottom.Height, pixel => Color.Green);
            }
            //spriteBatch.Draw(t1, CollisionRectangleTop, Color.White);
            //spriteBatch.Draw(t2, CollisionRectangleBottom, Color.White);
        }
    }
}
