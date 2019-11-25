using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    class CollisionManager
    {
        List<ICollide> Collection;
        Hero Hero;
        //hier elk blokje in de lijst Collection controleren op collision met hero
        public CollisionManager(Hero hero, List<ICollide> collection)
        {
            Collection = collection;
            Hero = hero;
        }

        #region Collision
        public void CheckForCollision(ICollideBlok collide)
        {
            if (Hero.CollisionRectangleTop.Intersects(collide.CollisionRectangleBottom))
            {
                System.Console.WriteLine("Stop met vallen");
            }
            if (Hero.CollisionRectangleTop.Intersects(collide.CollisionRectangleBottom))
            {
                System.Console.WriteLine("Stop met springen");
            }
            if (Hero.CollisionRectangleTop.Intersects(collide.CollisionRectangleRight))
            {
                System.Console.WriteLine("Stop met naar links te bewegen");
            }
            if (Hero.CollisionRectangleTop.Intersects(collide.CollisionRectangleLeft))
            {
                System.Console.WriteLine("Stop met naar Rechts te bewegen");
            }
        }
        #endregion
    }
}
