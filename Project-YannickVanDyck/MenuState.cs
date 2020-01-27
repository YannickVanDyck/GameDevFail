using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project_YannickVanDyck
{
    public class MenuState : State
    {
        private List<Component> _components;

        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");

            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1920 / 2, 1020 / 2 - 50),
                Text = "New Game",
            };
            newGameButton.Click += NewGameButton_Click;

            var infoButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1920 / 2, 1020 / 2),
                Text = "Info",
            };
            infoButton.Click += InfoButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1920 / 2, 1020 / 2 + 50),
                Text = "Quit Game",
            };
            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                infoButton,
                quitGameButton,
            };
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void InfoButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new InfoState(_game, _graphicsDevice, _content));
        }

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //remove sprites if they're not needed
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
