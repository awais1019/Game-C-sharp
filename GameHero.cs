using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class GameHero : GameObject
    {
        public int verticalhealth = 10;
        public int horizontalhealth = 10;
        public int smarthealth = 10;
        public static List<Bullet> bullets=new List<Bullet>();
        public int score = 0;
        public GameHero(Image image, GameCell startCell)
            : base(GameObjectType.PLAYER, image)
        {
            base.CurrentCell = startCell;
         
        }

        public void move(GameCell gameCell)
        {
            base.CurrentCell = gameCell;
        }

        public void moveBullets()
        {

            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].CurrentCell == bullets[i].nextCell(GameDirection.Right))
                {
                    GameCell currentCell = this.CurrentCell;
                    bullets[i].CurrentCell.setGameObject(ImageProvider.getBlankGameObject());
                    bullets.RemoveAt(i);
                }
                else if(bullets[i].nextCell(GameDirection.Right).CurrentGameObject.GameObjectType == GameObjectType.SMARTENEMY)
                {
                    score++;
                    smarthealth--;
                    bullets.RemoveAt(i);
                }
                else if (bullets[i].nextCell(GameDirection.Right).CurrentGameObject.GameObjectType == GameObjectType.HORIZONTALENEMY)
                {
                    score++;
                    horizontalhealth--;
                    bullets.RemoveAt(i);
                }
                else if (bullets[i].nextCell(GameDirection.Right).CurrentGameObject.GameObjectType == GameObjectType.VERTICALENEMY)
                {
                    score++;
                    verticalhealth--;
                    bullets.RemoveAt(i);
                }
                else
                {
                    bullets[i].move(bullets[i].nextCell(GameDirection.Right));
                }

            }
        }

        public void generateBullet()
        {
            Bullet bullet = new Bullet(ImageProvider.getHeroBulletImage(), this.CurrentCell.nextCell(GameDirection.Right));
            bullets.Add(bullet);
        }
    }
}
