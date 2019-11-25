using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    public class Collider
    {
        public bool CheckCollider(ICollide source, ICollide target)
        {
            if (source.CollisionRectangle.Intersects(target.CollisionRectangle))
            {
                return true;
            }
            return false;
        }
    }
}
