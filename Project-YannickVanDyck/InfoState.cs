using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    public class InfoState : State
    {
        private List<Component> _components;

        public InfoState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/Button");
            var buttonFont = _content.Load<SpriteFont>("Fonts/Font");
 
            var menuButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(1920 / 2, 1020 / 2 + 50),
                Text = "Menu",
            };
            menuButton.Click += MenuButton_Click;

            _components = new List<Component>()
            {
                menuButton,
            };
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new MenuState(_game, _graphicsDevice, _content));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var font = _content.Load<SpriteFont>("Fonts/Font");

            spriteBatch.Begin();

            spriteBatch.DrawString(font, "Het skeleton army heeft coins van je gestolen. Sluip het kasteel binnen en steel ze terug, maar pas op dat de skeleton wachters je niet vangen.", new Vector2(550, 200), Color.Black);
            spriteBatch.DrawString(font, "In het eerste level ben je niet verplicht om alle coins te verzamelen, je moet enkel zorgen dat je naar de deur van de schatkamer geraakt", new Vector2(550, 220), Color.Black);
            spriteBatch.DrawString(font, "In het tweede level moet je alle coins verzamelen, heb je ze allemaal verzameld ben je gewonnen.", new Vector2(550, 240), Color.Black);
            spriteBatch.DrawString(font, "Je kan dood gaan door tegen een skeleton te lopen of door van te hoog te vallen.", new Vector2(550, 280), Color.Black);
            spriteBatch.DrawString(font, "Bestuur je hero met de Z,Q,D toetsen en je kan sprinten met SHIFT.", new Vector2(550, 300), Color.Black);

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
