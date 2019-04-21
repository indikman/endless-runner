
public static class Utils
{
    public enum lane {left, middle, right};
    public static lane current = lane.middle;

    public enum item{coin, obstacle_jump, obstacle_slide}

    public static string ITEM_TAG = "hititem";
}
