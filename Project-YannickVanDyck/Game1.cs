using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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
        GroundLayer ground2;
        Skeleton skeleton;
        Level1 level1;
        Level2 level2;
        CollisionManager Co;
        CollisionManager Co2;

        private State _currentState;
        private State _nextState;

        Color backgroundColor = Color.Red;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

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
            IsMouseVisible = true;

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

            _currentState = new MenuState(this, graphics.GraphicsDevice, Content);

            Texture2D _heroTextureLeft = Content.Load<Texture2D>("WalkLeft");
            Texture2D _heroTextureRight = Content.Load<Texture2D>("WalkRight");
            hero = new Hero(_heroTextureLeft, _heroTextureRight, new Vector2(100, 900));
            hero._controls = new ZQSDControl();

            Texture2D _skeletonLeft = Content.Load<Texture2D>("SkeletonLeft");
            Texture2D _skeletonRight = Content.Load<Texture2D>("SkeletonRight");
            skeleton = new Skeleton(_skeletonLeft, _skeletonRight, new Vector2(0, 0));

            Texture2D _tile = Content.Load<Texture2D>("Tile");
            ground = new GroundLayer(_tile, new Vector2(0, 0));

            Texture2D _tile2 = Content.Load<Texture2D>("3");
            ground2 = new GroundLayer(_tile2, new Vector2(0, 0));

            level1 = new Level1(hero, this, Content, GraphicsDevice);
            level1.texture = _tile;
            level1.skeletonLeftTexture = _skeletonLeft;
            level1.skeletonRightTexture = _skeletonRight;
            level1.CreateWorld();

            level2 = new Level2(hero, this, Content, GraphicsDevice);
            level2.texture = _tile2;
            level2.CreateWorld();

            Co = new CollisionManager(hero, level1.Collides,level1.Skeletons, this, Content, GraphicsDevice);
            Co2 = new CollisionManager(hero, level2.Collides,level2.Skeletons, this, Content, GraphicsDevice);

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

            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            _currentState.Update(gameTime);

            _currentState.PostUpdate(gameTime); //doet niks

            if (_currentState is GameState)
            {
                hero.Update(gameTime);

                level1.Update(gameTime);

                if (hero.nextLevel)
                {
                    ChangeState(new GameState2(this, GraphicsDevice, Content));
                }
            }

            
            //hij tekent het 2de level gewoon boven op het 1ste level

            if (_currentState is GameState2)
            {
                hero.Update(gameTime);

                level2.Update(gameTime);
            }
            
            

            base.Update(gameTime);


        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _currentState.Draw(gameTime, spriteBatch);

            if (_currentState is GameState)
            {
                spriteBatch.Begin();

                hero.Draw(spriteBatch, GraphicsDevice);
                level1.DrawWorld(spriteBatch, GraphicsDevice);

                spriteBatch.End();
            }

            
            //hij tekent het 2de level gewoon boven op het 1ste level 
            
            if (_currentState is GameState2)
            {
                spriteBatch.Begin();
                hero.Draw(spriteBatch, GraphicsDevice);
                level2.DrawWorld(spriteBatch, GraphicsDevice);

                spriteBatch.End();
            }
            
            

            if (hero.isDead)
            {
                LoadContent();
                ChangeState(new DeadState(this, GraphicsDevice, Content));
            }

            base.Draw(gameTime);
        }
    }
}
