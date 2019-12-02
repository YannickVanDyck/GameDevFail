using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    public interface ICollide
    {
        Rectangle CollisionRectangleTop { get; set; } //iedereen die van ICollide overerft moet een CollisionRectangle hebben
        Rectangle CollisionRectangleBottom { get; set; }

        void Draw(SpriteBatch spriteBatch);
    }
}
