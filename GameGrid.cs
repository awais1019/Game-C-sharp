using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace Game
{
    class GameGrid
    {
        private GameCell[,] cells;

        private int rows;

        private int cols;

        public int Rows
        {
            get
            {
                return rows;
            }
            set
            {
                rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return cols;
            }
            set
            {
                cols = value;
            }
        }

        public GameGrid(string fileName, int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            cells = new GameCell[rows, cols];
            loadGrid(fileName);
        }

        public GameCell getCell(int x, int y)
        {
            return cells[x, y];
        }

        private void loadGrid(string fileName)
        {
            StreamReader streamReader = new StreamReader(fileName);
            for (int i = 0; i < rows; i++)
            {
                string text = streamReader.ReadLine();
                for (int j = 0; j < cols; j++)
                {
                    GameCell gameCell = new GameCell(i, j, this);
                    char displayCharacter = text[j];
                    GameObjectType gameObjectType = GameObject.getGameObjectType(displayCharacter);
                    Image gameObjectImage = ImageProvider.getGameObjectImage(displayCharacter);
                    GameObject gameObject = new GameObject(gameObjectType, gameObjectImage);
                    gameCell.setGameObject(gameObject);
                    cells[i, j] = gameCell;
                }
            }

            streamReader.Close();
        }
    }
}
