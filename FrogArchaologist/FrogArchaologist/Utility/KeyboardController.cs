using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogArchaologist.Utility
{
    static class KeyboardController
    {
        static KeyboardState lastState;
        static KeyboardState currentState;

        public static void Update()
        {
            lastState = currentState;
            currentState = Keyboard.GetState();
        }

        public static bool FirstPress(Keys key)
        {
            return lastState.IsKeyUp(key) && currentState.IsKeyDown(key);
        }

        public static bool FirstRelease(Keys key)
        {
            return lastState.IsKeyDown(key) && currentState.IsKeyUp(key);
        }

        public static bool IsPressed(Keys key)
        {
            return currentState.IsKeyDown(key);
        }

        public static bool IsReleased(Keys key)
        {
            return currentState.IsKeyUp(key);
        }

        public static bool AreAllPressed(params Keys[] keys)
        {
            return keys.All(k => currentState.IsKeyDown(k));
        }

        public static bool CombinationFirstPressed(params Keys[] keys)
        {
            return keys.All(k => currentState.IsKeyDown(k)) && keys.Any(k => lastState.IsKeyUp(k));
        }

        public static bool AreAllReleased(params Keys[] keys)
        {
            return keys.All(k => currentState.IsKeyUp(k));
        }

        public static bool AnyPressed(params Keys[] keys)
        {
            return keys.Any(k => currentState.IsKeyDown(k));
        }

        public static bool AnyReleased(params Keys[] keys)
        {
            return keys.Any(k => currentState.IsKeyUp(k));
        }
    }
}
