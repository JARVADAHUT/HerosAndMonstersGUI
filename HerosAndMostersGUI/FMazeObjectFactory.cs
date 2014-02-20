using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeTest
{
    class FMazeObjectFactory
    {
        public static MazeObject GetMazeObject(EnumMazeObject s)
        {
            switch ((EnumMazeObject)s)
            {
                case EnumMazeObject.Air:
                    return new MazeObject( new MazeObjectAir() );

                case EnumMazeObject.Chest:
                    return new MazeObject( new MazeObjectChest() );

                case EnumMazeObject.Exit:
                    return new MazeObject( new MazeObjectExit() );

                case EnumMazeObject.Player:
                    return Player.GetInstance();

                case EnumMazeObject.Monster:
                    return new Monster();

                default:
                    return new MazeObject(new MazeObjectWall());

            }

        }




    }
}
