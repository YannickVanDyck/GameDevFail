using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    public interface ICollide
    {
        Rectangle GetCollisionRectangle(); //iedereen die van ICollide overerft moet een CollisionRectangle hebben

        void Draw(SpriteBatch spriteBatch);
    }
}
