using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LandmineGameClasses
{
    public class Player
    {
        private int boardWidth;
        private int boardHeight;

        private int mX;
        public int x
        {
            get
            {
                return mX;
            }

            internal set
            {
                mX = value;
            }
        }

        private int mY;
        public int y
        {
            get
            {
                return mY;
            }

            internal set
            {
                mY = value;
            }
        }

        // Functionality involving lives will not be tested since it is very basic
        private int mLives;
        public int lives
        {
            get
            {
                return mLives;
            }

            internal set
            {
                mLives = value;
            }
        }

        private Player()
        {
            boardWidth = 0;
            boardHeight = 0;
            x = 0;
            y = 0;
            lives = 0;

        }
        public void initialise(int startingX, int startingY, int startingLives, int boardWidth, int boardHeight)
        {
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            x = startingX;
            y = startingY;
            lives = startingLives;
        }
        public enum MovementDirection
        {
            Up, Down, Left, Right
        }
        public void move(MovementDirection movementDirection)
        {
            switch (movementDirection)
            {
                case MovementDirection.Up:
                {
                    if(y < boardHeight - 1)
                        y += 1;
                    break;
                }
                case MovementDirection.Down:
                {
                    if(y > 0)
                        y -= 1;
                    break;
                }
                case MovementDirection.Left:
                {
                    if(x > 0)
                        x -= 1;
                    break;
                }
                case MovementDirection.Right:
                {
                    if(x < boardWidth - 1)
                        x += 1;
                    break;
                }
            }
        }

        // This function will not be tested since it is very basic functionality
        public void deductLife()
        {
            lives -= 1;
        }

        public void addLife()
        {
            lives += 1;
        }

        // This function will not be tested since it is very basic functionality
        public bool isDead()
        {
            return lives <= 0;
        }
    }
}
