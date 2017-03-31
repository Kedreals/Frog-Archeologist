using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogArchaologist.Utility
{
    class AnimatedSprite
    {
        Texture2D texture;
        Vector2 m_pos;
        public Vector2 Position
        {
            get
            {
                return m_pos;
            }
            set
            {
                m_pos = value;
                destination.Location = m_pos.ToPoint();
            }
        }
        public Vector2 Scale
        {
            get
            {
                Vector2 res = 2*(destination.Center.ToVector2() - Position);
                return new Vector2(Math.Abs(res.X)/Size.X, Math.Abs(res.Y)/Size.Y);
            }
            set
            {
                destination.Width = (int)(Size.X * value.X);
                destination.Height = (int)(Size.Y * value.Y);
            }
        }
        int m_frame = 0;
        int Frame
        {
            get
            {
                return m_frame;
            }
            set
            {
                m_frame = value;
                source = new Rectangle(new Point((int)(m_frame*Size.X), m_animationOffset), Size.ToPoint());
            }
        }

        private int m_animationOffset = 0;

        public int AnimationOffset
        {
            get
            {
                return (int)(m_animationOffset / Size.Y);
            }
            set
            {
                m_animationOffset = value * (int)Size.Y;
                m_frame = 0;
                timeSinceLastFrame = 0;
            }
        }

        Vector2 Size = new Vector2(1,1);
        float Rotation = 0;

        Rectangle destination = new Rectangle();
        Rectangle? source = null;
        int m_frameCount = 0;
        float timeSteps = -1;
        float timeSinceLastFrame = 0;

        public AnimatedSprite(ContentManager content, string sprite, Vector2? scale = null, Vector2? size = null, int frameCount = 0, float animationDuration = -1)
        {
            texture = content.Load<Texture2D>(sprite);

            Size = size != null ? size.Value : texture.Bounds.Size.ToVector2();

            Scale = scale != null ? scale.Value : new Vector2(1, 1);

            Position = new Vector2();

            if(frameCount > 0 && animationDuration > 0)
            {
                m_frameCount = frameCount;
                timeSteps = animationDuration / frameCount;

                source = new Rectangle(Point.Zero, Size.ToPoint());
            }
        }

        public void Update(GameTime time)
        {
            if (timeSteps < 0)
                return;

            timeSinceLastFrame += (float)time.ElapsedGameTime.TotalSeconds;
            
            while(timeSinceLastFrame > timeSteps)
            {
                timeSinceLastFrame -= timeSteps;
                Frame = (Frame + 1) % m_frameCount;
            }

            Rotation += 0.01f;
        }

        public void Draw(SpriteBatch batch, SpriteEffects effects = SpriteEffects.None)
        {
            Draw(batch, Color.White, effects);
        }

        public void Draw(SpriteBatch batch, Color colorMask, SpriteEffects effects = SpriteEffects.None)
        {
            batch.Draw(texture, destination, source, colorMask, Rotation, Size*0.5f, effects, 0);
        }
    }
}
