﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    class DeadState : State
    {
        private List<Component> _components;

        public DeadState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1920 / 2, 1020 / 2 - 25),
                Text = "Restart",
            };
            newGameButton.Click += NewGameButton_Click;

            var menuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1920 / 2, 1020 / 2 + 25),
                Text = "Menu",
            };
            menuButton.Click += MenuButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                menuButton,
            };
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            //_game.Load();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var font = _content.Load<SpriteFont>("Text");

            spriteBatch.Begin();

            spriteBatch.DrawString(font, "YOU DIED!!!", new Vector2(1920/2 - 60, 200), Color.Black);

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
