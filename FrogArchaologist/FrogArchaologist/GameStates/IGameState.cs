using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogArchaologist.GameStates
{
    enum EGameState
    {
        None = -1,

        MainMenu,
        Options,
        Ingame,

        Count
    }

    interface IGameState
    {
        void Initialize();
        void LoadContent(ContentManager content);
        void UnloadContent(ContentManager content);
        EGameState Update(GameTime gTime);
        void Draw(SpriteBatch batch);
    }
}
