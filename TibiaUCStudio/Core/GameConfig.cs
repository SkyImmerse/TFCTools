namespace Game.Core
{
    public static class GameConfig
    {
        public static int ClientVersion = 1097;

        public static bool GameEnhancedAnimations = ClientVersion >= 1050;
        public static bool GameSpritesU32 = ClientVersion >= 960;
        public static bool GameIdleAnimations = ClientVersion >= 1057;

        public static bool IsEnhancedGraphics = true;

        public static void SetupVersionParamaters()
        {
            GameEnhancedAnimations = ClientVersion >= 1050;
            GameSpritesU32 = ClientVersion >= 960;
            GameIdleAnimations = ClientVersion >= 1057;
    }

        public static string GetOs()
        {
            return "windows";
        }
        public static uint GetClientVersion()
        {
            return (uint)(uint) ClientVersion;
        }
    }
}