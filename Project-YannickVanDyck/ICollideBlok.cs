using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    interface ICollideBlok : ICollide
    {
        Rectangle CollisionRectangleBottom { get; set; }
        Rectangle CollisionRectangleRight { get; set; }
        Rectangle CollisionRectangleLeft { get; set; }
    }
}
