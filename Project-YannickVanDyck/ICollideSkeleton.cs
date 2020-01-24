﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    public interface ICollideSkeleton
    {
        Rectangle CollisionRectangleLeft { get; set; } //iedereen die van ICollide overerft moet een CollisionRectangle hebben
        Rectangle CollisionRectangleRight { get; set; }

        void Draw(SpriteBatch spriteBatch, GraphicsDevice device);
        void Update(GameTime gameTime);
    }
}
