﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Project_YannickVanDyck
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D _heroTexture;
        Hero hero;
        GroundLayer ground;
        Level1 level;
        Collider Co;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1020;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D _heroTextureLeft = Content.Load<Texture2D>("WalkLeft");
            Texture2D _heroTextureRight = Content.Load<Texture2D>("WalkRight");

            hero = new Hero(_heroTextureLeft, _heroTextureRight, new Vector2(50, 300));
            hero._controls = new ZQSDControl();

            Texture2D _tile = Content.Load<Texture2D>("Tile");
            ground = new GroundLayer(_tile, new Vector2(0, 0));

            Co = new Collider();

            level = new Level1();
            level.texture = _tile;
            level.CreateWorld();
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //hier collide code
            if (Co.CheckCollider(ground, hero) == true)
            {
                System.Console.WriteLine("1234 hoedje van hoedje van");
                hero.velocity.Y = 0;
            }

            hero.Update(gameTime);

            base.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            hero.Draw(spriteBatch);
            level.DrawWorld(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
