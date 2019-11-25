using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    public interface ICollide
    {
        Rectangle CollisionRectangleTop { get; set; } //iedereen die van ICollide overerft moet een CollisionRectangle hebben

        void Draw(SpriteBatch spriteBatch);
    }
}
