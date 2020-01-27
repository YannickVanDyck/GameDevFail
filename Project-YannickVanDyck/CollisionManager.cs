using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Project_YannickVanDyck
{
    class CollisionManager
    {
        List<ICollide> Collides;
        List<Coin> Coins;
        List<ICollideSkeleton> Skeletons;
        List<ICollideHero> Hero;
        Hero HeroHard;
        ICollide collide;
        Game1 Game;

        ContentManager _content;
        GraphicsDevice _graphicsDevice;


        public CollisionManager(List<ICollide> bloks,List<Coin> coins, List<ICollideSkeleton> skeletons, List<ICollideHero> hero, Game1 game, ContentManager content, GraphicsDevice graphicsDevice)
        {
            Collides = bloks;
            Coins = coins;
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
            foreach (ICollide blok in Collides)
            {
                foreach (Hero hero in Hero)
                {
                    if (hero.CollisionRectangleLeft.Intersects(blok.CollisionRectangleTop) && hero.CollisionRectangleLeft.Intersects(blok.CollisionRectangleBottom))
                    {
                        hero.stopLeft = true;
                        Console.WriteLine("stop, there is a block on your left!");
                    }

                    if (hero.CollisionRectangleRight.Intersects(blok.CollisionRectangleTop) && hero.CollisionRectangleRight.Intersects(blok.CollisionRectangleBottom))
                    {
                        hero.stopRight = true;
                        Console.WriteLine("stop, there is a block on your Right!");
                    }

                    if (blok.CollisionRectangleTop.Intersects(hero.CollisionRectangleLeft) || blok.CollisionRectangleTop.Intersects(hero.CollisionRectangleRight))
                    {
                        hero.stopFall = true;
                        hero.stopJump = false;
                        if (hero.CollisionRectangleLeft.Y + 54 > blok.CollisionRectangleTop.Y)
                        {
                            hero.yCorrection = 2f;
                        }
                        else hero.yCorrection = 0;

                        Console.WriteLine("stop, your feet touch the ground!");
                    }

                    if (blok.CollisionRectangleBottom.Intersects(hero.CollisionRectangleLeft) || blok.CollisionRectangleBottom.Intersects(hero.CollisionRectangleRight))
                    {
                        hero.stopJump = true;
                        Console.WriteLine("stop, your bumping your head!");
                    }

                    foreach (Skeleton skeleton in Skeletons)
                    {
                        if (skeleton.CollisionRectangleLeft.Intersects(blok.CollisionRectangleTop) || skeleton.CollisionRectangleRight.Intersects(blok.CollisionRectangleTop))
                        {
                            skeleton.stopFall = true;
                        }

                        if (skeleton.CollisionRectangleRight.Intersects(blok.CollisionRectangleTop) && skeleton.CollisionRectangleRight.Intersects(blok.CollisionRectangleBottom))
                        {
                            skeleton.stopRight = true;
                            skeleton.stopLeft = false;
                        }

                        if (skeleton.CollisionRectangleLeft.Intersects(blok.CollisionRectangleTop) && skeleton.CollisionRectangleLeft.Intersects(blok.CollisionRectangleBottom))
                        {
                            skeleton.stopLeft = true;
                            skeleton.stopRight = false;
                        }

                        if (hero.CollisionRectangleLeft.Intersects(skeleton.CollisionRectangleRight) || hero.CollisionRectangleRight.Intersects(skeleton.CollisionRectangleLeft))
                        {
                            Game.Dead();
                        }
                    }

                    foreach (Coin coin in Coins)
                    {
                        if (hero.CollisionRectangleLeft.Intersects(coin.CollisionRectangleTop) || hero.CollisionRectangleLeft.Intersects(coin.CollisionRectangleTop) || hero.CollisionRectangleRight.Intersects(coin.CollisionRectangleTop) || hero.CollisionRectangleRight.Intersects(coin.CollisionRectangleTop))
                        {
                            coin.IsRemoved = true;
                            hero.stopFall = true;
                        }
                    }

                    for (int i = 0; i < Coins.Count; i++)
                    {
                        Coin sprite = Coins[i];
                        if (sprite.IsRemoved)
                        {
                            Coins.RemoveAt(i);
                            i--;
                        }

                    }
                }
            }
        }
    }
}