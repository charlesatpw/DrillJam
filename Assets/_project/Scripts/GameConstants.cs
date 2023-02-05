public enum Items
{
    Item_Fertilizer,
    Item_Jerry_Can,
    Item_Water_Pocket,
    Item_Rock,
    Item_Radiation_Barrel
}

public class GameConstants
{
    //Scenes
    public const string GameScene = "Game";
    public const string MenuScene = "MainMenu";
    public const string LoadingScene = "LoadingScreen";

    //EnemyTypes
    public const string Ant_Worker = "Ant_Worker";
    public const string Ant_Soldier = "Ant_Soldier";
    public const string Mole_Suit = "Mole_Suit";
    public const string Mole_Tie = "Mole_Tie";
    public const string Worm = "Worm";

    //Items
    public const string Fertilizer = "Fertilizer";
    public const string Jerry_Can = "Jerry_Can";
    public const string Water_Pocket = "Water_Pocket";
    public const string Rock = "Rock";
    public const string RadiationBarrel = "RadiationBarrel";

    public static string GetItemStringBasedOnType(Items item)
    {
        string returnString = string.Empty;
        switch (item) 
        {
            case Items.Item_Jerry_Can:
                returnString = Jerry_Can;
                break;
            case Items.Item_Water_Pocket:
                returnString = Water_Pocket;
                break;
            case Items.Item_Fertilizer:
                returnString = Fertilizer;
                break;
            case Items.Item_Rock:
                returnString = Rock;
                break;
            case Items.Item_Radiation_Barrel:
                returnString = RadiationBarrel;
                break;
        }

        return returnString;
    }
}
