
using TutorialGame.Source.Engine;

namespace TutorialGame
{
    internal class GameGlobals
    {
        public static bool paused = false;
        public static int score = 0;
        public static PassObject PassProjectile
            , PassMob
            , PassBuilding
            , CheckScroll
            , PassSpawnPoint;
    }
}
