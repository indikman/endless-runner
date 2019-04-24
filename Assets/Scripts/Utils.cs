
public static class Utils
{
    public enum lane {left, middle, right};
    public static lane current = lane.middle;
    public enum item{coin, obstacle_jump, obstacle_slide}
    public enum powerup{coin, score, shield, boost, rb}

    public static string ITEM_TAG = "hititem";
    public static string POWERUP_TAG = "powerup";
    public static float START_SPEED = 25f;

    public static float HIGH_SPEED_ADDITION = 20f;
    public static int COIN_THRESHOLD = 50;
    public static int OBSTACLE_THRESHOLD = 70; // higher the val, higher the obstacles
    public static int COIN_TO_OBSTACLE_THRESHOLD = 20; //0-100; higher the value higher the coins //

    public static float OBSTACLE_SPEED = 10f;
    public static float SPEED = 10f;

    public static int itemsInALane = 50;

    public static int scoreMultiplier = 1;
    public static bool isRunning = false;
    public static bool isSliding = false;

    public static bool isScoreBoost = false;
    public static bool isShield = false;
    public static int coinMultiplier = 1;
    
    public static float boostTime = 4.0f;
    public static float scoreBoostTime = 4.0f;
    public static float shieldTime = 4.0f;

    public static int coinBoostValue = 100;

    public static int POWERUP_PROBABILITY_THRESHOLD = 50; // 0-100


    public static int score = 0;
    public static int coin_count = 0;

}
