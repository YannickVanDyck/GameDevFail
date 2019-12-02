using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    class GroundLayer : ICollideBlok
    {
        public Texture2D texture;
        public Vector2 position;
        Animation LGround;
        private Rectangle collisionRectangleTop;
        private Rectangle collisionRectangleBottom;
        private Rectangle collisionRectangleRight;
        private Rectangle collisionRectangleLeft;


        public GroundLayer(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;

            LGround = new Animation();
            LGround.AddFrame(new Rectangle(0, 0, 64, 64));

            collisionRectangleTop = new Rectangle((int)position.X, (int)position.Y, 64, 10);
            collisionRectangleBottom = new Rectangle((int)position.X, (int)position.Y + 54, 64, 10);
            collisionRectangleRight = new Rectangle((int)position.X + 54, (int)position.Y, 10, 64);
            collisionRectangleLeft = new Rectangle((int)position.X, (int)position.Y, 10, 64);
        }

        public Rectangle CollisionRectangleTop { get => collisionRectangleTop; set => collisionRectangleTop = value; }
        public Rectangle CollisionRectangleBottom { get => collisionRectangleBottom; set => collisionRectangleBottom = value; }
        public Rectangle CollisionRectangleRight { get => collisionRectangleRight; set => collisionRectangleRight = value; }
        public Rectangle CollisionRectangleLeft { get => collisionRectangleLeft; set => collisionRectangleLeft = value; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, LGround.currentFrame.SourceRectangle, Color.White);
        }
    }
}
