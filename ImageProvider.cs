using Game.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ImageProvider
    {
        public static GameObject getBlankGameObject()
        {
            return new GameObject(GameObjectType.NONE, Resources.simplebox);
        }
        public static Image getHeroImage()
        {
            return Resources.icons8_plane_100;
        }
        public static Image getVerticalPlayerImage()
        {
            return Resources.verticalplayer;
        }
        public static Image getHorizontalPlayerImage()
        {
            return Resources.airplane;
        }
        public static Image getSmartPlayerImage()
        {
            return Resources.aircraft;
        }

        public static Image getHeroBulletImage()
        {
            return Resources.icons8_bullet_67;
        }
        public static Image getHorizontalBulletImage()
        {
            return Resources.icons8_bullet_64__1_1;
        }
        public static Image getVerticalBulletImage()
        {
            return Resources.icons8_bullet_64;
        }
        public static Image getSmartBulletImage()
        {
            return Resources.smartfire;
        }

        public static Image getGameObjectImage(char displayCharacter)
        {
            Image result = Resources.simplebox;
            if (displayCharacter == '|' || displayCharacter == '%')
            {
                result = Resources.vertical;
            }

            if (displayCharacter == '#')
            {
                result = Resources.horizontal;
            }

       

            return result;
        }
    }
}
