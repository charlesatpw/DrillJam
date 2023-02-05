public class Config
{
    public const string playerDataFileName = "playerdata.bytes";

    public static PlayerConfig playerConfig;
    public static EnemyConfig enemyConfig;
    public static ItemConfig itemConfig;
    public static RootConfig rootConfig;

    public static bool ReadConfigFiles()
    { 
        playerConfig = new PlayerConfig();
        playerConfig = JsonParser.ReadFile<PlayerConfig>(playerConfig.GetType().ToString()) as PlayerConfig;

        enemyConfig = new EnemyConfig();
        enemyConfig = JsonParser.ReadFile<EnemyConfig>(enemyConfig.GetType().ToString()) as EnemyConfig;

        itemConfig = new ItemConfig();
        itemConfig = JsonParser.ReadFile<ItemConfig>(itemConfig.GetType().ToString()) as ItemConfig;

        rootConfig = new RootConfig();
        rootConfig = JsonParser.ReadFile<RootConfig>(rootConfig.GetType().ToString()) as RootConfig;

        return true;
    }

    public static bool FilesRead()
    {
        return playerConfig != null && enemyConfig != null && itemConfig != null;
    }
}