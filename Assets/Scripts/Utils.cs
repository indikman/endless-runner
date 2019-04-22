
public static class Utils
{
    public enum lane {left, middle, right};
    public static lane current = lane.middle;

    public enum item{coin, obstacle_jump, obstacle_slide}
    public enum powerup{coin, magnet, shield, boost, rb}

    public static string ITEM_TAG = "hititem";
    public static string POWERUP_TAG = "powerup";
    public static float START_SPEED = 25f;

    public static float HIGH_SPEED_ADDITION = 20f;
    public static int COIN_THRESHOLD = 50;
    public static int OBSTACLE_THRESHOLD = 70; // higher the val, higher the obstacles
    public static int COIN_TO_OBSTACLE_THRESHOLD = 20; //0-100; higher the value higher the coins //


    //Boosts
    public static float boostTime = 4.0f;
    //Boosts
    public static float magnetTime = 4.0f;
    //Boosts
    public static float shieldTime = 4.0f;
}
