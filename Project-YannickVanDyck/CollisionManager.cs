using System;
using System.Collections.Generic;

namespace Project_YannickVanDyck
{
    class CollisionManager
    {
        List<ICollide> Collides;
        Hero Hero;
        public CollisionManager(Hero hero, List<ICollide> collection)
        {
            Collides = collection;
            Hero = hero; 
        }

        public void CheckForCollision()
        {
            Console.WriteLine(Collides.Count);
            foreach (ICollide item in Collides)
            {
                if (Hero.CollisionRectangleLeft.Intersects(item.CollisionRectangleTop) && Hero.CollisionRectangleLeft.Intersects(item.CollisionRectangleBottom))
                {
                    Hero.stopLeft = true;
                    Console.WriteLine("stop je kan niet meer naar links!");
                }

                if (Hero.CollisionRectangleRight.Intersects(item.CollisionRectangleTop) && Hero.CollisionRectangleRight.Intersects(item.CollisionRectangleBottom))
                {
                    Hero.stopRight = true;
                    Console.WriteLine("stop je kan niet meer naar Rechts!");
                }

                if (item.CollisionRectangleTop.Intersects(Hero.CollisionRectangleLeft) || item.CollisionRectangleTop.Intersects(Hero.CollisionRectangleRight))
                {
                    Hero.stopFall = true;
                    Console.WriteLine("stop je kan niet meer verder vallen!");
                }

                if (item.CollisionRectangleBottom.Intersects(Hero.CollisionRectangleLeft) && item.CollisionRectangleBottom.Intersects(Hero.CollisionRectangleRight))
                {
                    Hero.stopJump = true;
                    Console.WriteLine("stop je kan niet meer verder springen!");
                }
            }
        }
    }
}