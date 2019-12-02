using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    class GroundLayer : ICollide
    {
        public Texture2D texture;
        public Vector2 position;
        Animation LGround;
        private Rectangle collisionRectangleTop;
        private Rectangle collisionRectangleBottom;

        public GroundLayer(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;

            LGround = new Animation();
            LGround.AddFrame(new Rectangle(0, 0, 64, 64));

            collisionRectangleTop = new Rectangle((int)position.X, (int)position.Y, 64, 30);
            collisionRectangleBottom = new Rectangle((int)position.X, (int)position.Y + 34, 64, 30);
        }

        public Rectangle CollisionRectangleTop { get => collisionRectangleTop; set => collisionRectangleTop = value; }
        public Rectangle CollisionRectangleBottom { get => collisionRectangleBottom; set => collisionRectangleBottom = value; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, LGround.currentFrame.SourceRectangle, Color.White);
        }
    }
}
