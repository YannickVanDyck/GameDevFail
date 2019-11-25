using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_YannickVanDyck
{
    public abstract class Controls
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public bool idleLeft { get; set; }
        public abstract void Update();
    }

    public class ZQSDControl : Controls
    {
        public override void Update()
        {
            KeyboardState stateKey = Keyboard.GetState();

            if (stateKey.IsKeyDown(Keys.Q))
            {
                left = true;
                idleLeft = true;
            }
            if (stateKey.IsKeyUp(Keys.Q))
            {
                left = false;
            }

            if (stateKey.IsKeyDown(Keys.D))
            {
                right = true;
                idleLeft = false;
            }
            if (stateKey.IsKeyUp(Keys.D))
            {
                right = false;
            }

            if (stateKey.IsKeyDown(Keys.Z))
            {
                up = true;
            }
            if (stateKey.IsKeyUp(Keys.Z))
            {
                up = false;
            }
        }
    }
}
