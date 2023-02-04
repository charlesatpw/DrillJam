public class Config
{
    public const string playerDataFileName = "playerdata.bytes";

    public static PlayerConfig playerConfig;
    public static EnemyConfig enemyConfig;
    public static ItemConfig itemConfig;

    public static bool ReadConfigFiles()
    { 
        playerConfig = new PlayerConfig();
        playerConfig = JsonParser.ReadFile<PlayerConfig>(playerConfig.GetType().ToString()) as PlayerConfig;

        enemyConfig = new EnemyConfig();
        enemyConfig = JsonParser.ReadFile<EnemyConfig>(enemyConfig.GetType().ToString()) as EnemyConfig;

        itemConfig = new ItemConfig();
        itemConfig = JsonParser.ReadFile<ItemConfig>(playerConfig.GetType().ToString()) as ItemConfig;

        return true;
    }
}