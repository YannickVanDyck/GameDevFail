using System;
using System.Collections.Generic;

namespace Project_YannickVanDyck
{
    class CollisionManager
    {
        List<ICollideBlok> Collection;
        Hero Hero;
        //hier elk blokje in de lijst Collection controleren op collision met hero
        public CollisionManager(Hero hero, List<ICollideBlok> collection)
        {
            Collection = collection;
            Hero = hero;
        }

        #region Collision
        public void CheckForCollision()
        {
            foreach (GroundLayer item in Collection)
            {
                if (Hero.CollisionRectangleTop.Intersects(item.CollisionRectangleTop))
                {
                    Console.WriteLine("Stop met vallen");
                }
                if (Hero.CollisionRectangleTop.Intersects(item.CollisionRectangleBottom))
                {
                    Console.WriteLine("Stop met springen");
                }
                if (Hero.CollisionRectangleTop.Intersects(item.CollisionRectangleRight))
                {
                    Console.WriteLine("Stop met naar links te bewegen");
                }
                if (Hero.CollisionRectangleTop.Intersects(item.CollisionRectangleLeft))
                {
                    Console.WriteLine("Stop met naar Rechts te bewegen");
                }
            }
        }
        #endregion
    }
}
