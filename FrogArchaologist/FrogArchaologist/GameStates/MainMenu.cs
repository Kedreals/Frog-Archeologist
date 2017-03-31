//#define TestAnimatedSprite

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FrogArchaologist.Utility;
using Microsoft.Xna.Framework.Input;

namespace FrogArchaologist.GameStates
{
    class MainMenu : IGameState
    {
        #region TestAnimatedSprite
#if TestAnimatedSprite
        AnimatedSprite sprite;
#endif
        #endregion

        public void Draw(SpriteBatch batch)
        {
            #region TestAnimatedSprite
#if TestAnimatedSprite
            sprite.Draw(batch);
#endif
#endregion
        }

        public void Initialize()
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            #region TestAnimatedSprite
#if TestAnimatedSprite
            sprite = new AnimatedSprite(content, "Content/testAnimation", null, new Vector2(100, 50), 3, 1);
#endif
            #endregion
        }

        public void UnloadContent(ContentManager content)
        {
            
        }

        public EGameState Update(GameTime gTime)
        {
            #region TestAnimatedSprite
#if TestAnimatedSprite
            if (KeyboardController.FirstPress(Keys.Space))
            {
                sprite.AnimationOffset = (sprite.AnimationOffset + 1) % 2;
            }

            sprite.Position += new Vector2(0.1f, 0.1f);
            sprite.Scale = new Vector2(1 + 0.5f *(float)Math.Sin(gTime.TotalGameTime.TotalSeconds));

            sprite.Update(gTime);
#endif
#endregion


            return EGameState.MainMenu;
        }
    }
}
