﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;


namespace premiertest
{
    internal class Enemy
    {

        Character character;

        public float Y {  get; set; }

        public float X { get; set; }
        

        public const float Speed = 100f;
        public const float Size = 70f;
        private Vector2 enemyPosition;
        private Vector2 playerPosition;
        private Vector2 direction;

        protected int state;

        

        public Enemy(float x, float y, Character player)
        {
            character = player;
            X = x;
            Y = y;
        }

        public void Update(GameTime gameTime)
        {

            playerPosition = new Vector2(character.X, character.Y);
            enemyPosition = new Vector2(X, Y);

            direction = playerPosition - enemyPosition;

            if (direction != Vector2.Zero)
            {
                direction = Vector2.Normalize(direction);
            }

            Vector2 moveVector = direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;


            X += moveVector.X;
            Y += moveVector.Y;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(new RectangleF(X - Size / 2, Y - Size / 2, Size, Size), Color.Red, thickness: 5);
        }



    }
}
