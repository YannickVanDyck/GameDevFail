using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project_YannickVanDyck
{
    class GroundLayer : ICollide
    {
        public Texture2D texture;
        public Vector2 position;
        Animation LGround;
        private Rectangle collisionRectangleTop;
        private Rectangle collisionRectangleBottom;

        Texture2D t1;
        Texture2D t2;

        public GroundLayer(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;

            LGround = new Animation();
            LGround.AddFrame(new Rectangle(0, 0, 64, 64));

            collisionRectangleTop = new Rectangle((int)position.X, (int)position.Y, 32, 14);
            collisionRectangleBottom = new Rectangle((int)position.X, (int)position.Y + 16, 32, 14);
        }

        public Rectangle CollisionRectangleTop { get => collisionRectangleTop; set => collisionRectangleTop = value; }
        public Rectangle CollisionRectangleBottom { get => collisionRectangleBottom; set => collisionRectangleBottom = value; }

        public void Draw(SpriteBatch spriteBatch, GraphicsDevice device)
        {
            spriteBatch.Draw(texture, new Rectangle((int)position.X, (int)position.Y, 32, 32), LGround.currentFrame.SourceRectangle, Color.White);

            if (t1 == null || t2 == null)
            {
                t1 = CreateTexture(device, CollisionRectangleBottom.Width, CollisionRectangleBottom.Height, pixel => Color.Red);
                t2 = CreateTexture(device, CollisionRectangleBottom.Width, CollisionRectangleBottom.Height, pixel => Color.Green);
            }
            spriteBatch.Draw(t1, CollisionRectangleTop, Color.White);
            spriteBatch.Draw(t2, CollisionRectangleBottom, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //do nothing
        }

        public static Texture2D CreateTexture(GraphicsDevice device, int width, int height, Func<int, Color> paint)  // tekenen van collisionrectangles
        {
            //initialize a texture
            Texture2D texture = new Texture2D(device, width, height);

            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                data[pixel] = paint(pixel);
            }

            texture.SetData(data);
            return texture;
        }
    }
}
