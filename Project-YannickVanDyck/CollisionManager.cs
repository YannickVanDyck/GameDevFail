using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Project_YannickVanDyck
{
    class CollisionManager
    {
        List<ICollide> Collides;
        Hero Hero;
        Game1 Game;

        ContentManager _content;
        GraphicsDevice _graphicsDevice;


        public CollisionManager(Hero hero, List<ICollide> collection, Game1 game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            Collides = collection;
            Hero = hero;
            Game = game;

            _content = content;
            _graphicsDevice = graphicsDevice;
        }

        //om te voorkomend dat je valt en deels in een blok zit, zorg ervoor dat als je een collision hebt tijdens het vallen dat de Y positie van je Hero naar de Y positie van het blok wordt gezet

        public void CheckForCollision()
        {
            Console.WriteLine(Collides.Count);
            foreach (ICollide item in Collides)
            {
                if (Hero.CollisionRectangleLeft.Intersects(item.CollisionRectangleTop) && Hero.CollisionRectangleLeft.Intersects(item.CollisionRectangleBottom))
                {
                    if (item is Skeleton)
                    {
                        Hero.isDead = true;
                    }

                    Hero.stopLeft = true;
                    Console.WriteLine("stop, there is a block on your left!");
                }

                if (Hero.CollisionRectangleRight.Intersects(item.CollisionRectangleTop) && Hero.CollisionRectangleRight.Intersects(item.CollisionRectangleBottom))
                {
                    if (item is Skeleton)
                    {
                        Hero.isDead = true;
                    }

                    Hero.stopRight = true;
                    Console.WriteLine("stop, there is a block on your Right!");
                }

                if (item.CollisionRectangleTop.Intersects(Hero.CollisionRectangleLeft) || item.CollisionRectangleTop.Intersects(Hero.CollisionRectangleRight))
                {
                    Hero.stopFall = true;
                    Hero.stopJump = false;
                    Console.WriteLine("stop, your feet touch the ground!");
                }

                if (item.CollisionRectangleBottom.Intersects(Hero.CollisionRectangleLeft) || item.CollisionRectangleBottom.Intersects(Hero.CollisionRectangleRight))
                {
                    Hero.stopJump = true;
                    Console.WriteLine("stop, your bumping your head!");
                }
            }
        }
    }
}