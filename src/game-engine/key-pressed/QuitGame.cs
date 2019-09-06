using System;

namespace GladiatorGame.SimpleGameEngine
{
    internal class QuitGame: IKeyPressedHandler
    {
        
        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}