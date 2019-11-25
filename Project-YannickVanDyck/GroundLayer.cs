using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    class GroundLayer : ICollide
    {
        public Texture2D texture;
        public Vector2 position;
        Animation LGround;
        private Rectangle collisionRectangle;

        public GroundLayer(Texture2D _texture, Vector2 _position)
        {
            texture = _texture;
            position = _position;

            LGround = new Animation();
            LGround.AddFrame(new Rectangle(0, 0, 64, 64));

            collisionRectangle = new Rectangle((int)position.X, (int)position.Y, 64, 64);
        }

        public Rectangle CollisionRectangle { get => collisionRectangle; set => collisionRectangle = value; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, LGround.currentFrame.SourceRectangle, Color.White);

        }
    }
}
