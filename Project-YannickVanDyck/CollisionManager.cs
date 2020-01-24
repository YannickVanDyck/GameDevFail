using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Project_YannickVanDyck
{
    class CollisionManager
    {
        List<ICollide> Collides;
        List<ICollideSkeleton> Skeletons;
        Hero Hero;
        ICollide collide;
        Game1 Game;

        ContentManager _content;
        GraphicsDevice _graphicsDevice;


        public CollisionManager(Hero hero, List<ICollide> bloks, List<ICollideSkeleton> skeletons, Game1 game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            Collides = bloks;
            Skeletons = skeletons;
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
                    Hero.stopLeft = true;
                    Console.WriteLine("stop, there is a block on your left!");
                }

                if (Hero.CollisionRectangleRight.Intersects(item.CollisionRectangleTop) && Hero.CollisionRectangleRight.Intersects(item.CollisionRectangleBottom))
                {
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

                foreach (Skeleton item2 in Skeletons)
                {
                    if (item2.CollisionRectangleLeft.Intersects(item.CollisionRectangleTop) || item2.CollisionRectangleRight.Intersects(item.CollisionRectangleTop))
                    {
                        item2.stopFall = true;
                    }

                    if (Hero.CollisionRectangleLeft.Intersects(item2.CollisionRectangleRight) || Hero.CollisionRectangleRight.Intersects(item2.CollisionRectangleLeft))
                    {
                        Hero.isDead = true;
                    }
                }
            }
        }
    }
}