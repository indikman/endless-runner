using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PreferencesManager
{
    // real time changing variables
    private static string GAME_SCORE = "";
    private static string GAME_COIN = "";


    //Global player pref keys
    private const string KEY_COINS = "_coin_tot";
    private const string KEY_COINS_HASH = "_coin_tot_h";

    //----------Keys for power up values----------
    private const string KEY_POWERUP_BOOST = "_bvall"; //boost level 1,2,3,4,5
    private const string KEY_POWERUP_SCORE = "_mval"; //multiplying 1,2,3,4,5
    private const string KEY_POWERUP_SHIELD = "_sval"; //shield 1,2,3,4,5
    private const string KEY_POWERUP_COIN = "_cval"; // number of coins to add 1,2,3,4,5


    //Other private variables
    private const string key = "kjhaf987324hjka091khsasd325ba";

    //keys for stats
    private const string KEY_APPOPENS = "stat_appopen";


//-----------------------------------------------------------------------------

    //score functions
    public static void AppendScore(int score)
    {
        GAME_SCORE = "" + (int.Parse(GAME_SCORE) + score);
    }
    public static void ResetScore()
    {
        GAME_SCORE = "0";
    }


//-----------------------------------------------------------------------------

    //Coins(gameplay) functions
    public static void AppendCoin(int coins)
    {
        GAME_COIN = "" + (int.Parse(GAME_COIN) + coins);

        //add to main coins
        AddCoins(coins);
    }

    public static void ResetCoin()
    {
        GAME_COIN = "0";
    }

//-----------------------------------------------------------------------------

    //Main Coin functions
    public static void AddCoins(int coins)
    {
        if (CheckHash(KEY_COINS, KEY_COINS_HASH))
        {
            SetValue(KEY_COINS, KEY_COINS_HASH, ((int.Parse(PlayerPrefs.GetString(KEY_COINS)) + coins) + ""));
        }
    }

    public static bool PurchaseWithCoins(int coins)
    {
        if (CheckHash(KEY_COINS, KEY_COINS_HASH))
        {
            if (int.Parse(PlayerPrefs.GetString(KEY_COINS)) >= coins)
            {
                SetValue(KEY_COINS, KEY_COINS_HASH, ((int.Parse(PlayerPrefs.GetString(KEY_COINS)) - coins) + ""));
                return true;
            }
            return false;
        }
        return false;
    }


//-----------------------------------------------------------------------------

    //Check value with hash
    private static bool CheckHash(string variableKey, string hashKey)
    {
        if ((Md5Sum(PlayerPrefs.GetString(variableKey) + "" + key)) == PlayerPrefs.GetString(hashKey))
        {
            return true;
        }
        return false;
    }

    private static void SetValue(string variableKey, string hashKey, string value)
    {
        PlayerPrefs.SetString(variableKey, value);
        PlayerPrefs.SetString(hashKey, Md5Sum(value + "" + key));
    }


//-----------------------------------------------------------------------------

    //Total preference reset
    public static void TotalReset(){
        SetValue(KEY_COINS, KEY_COINS_HASH, "0");
    }


    //MD5 Hash function
    public static string Md5Sum(string strToEncrypt)
    {
        System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
        byte[] bytes = ue.GetBytes(strToEncrypt);

        // encrypt bytes
        System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] hashBytes = md5.ComputeHash(bytes);

        // Convert the encrypted bytes back to a string (base 16)
        string hashString = "";

        for (int i = 0; i < hashBytes.Length; i++)
        {
            hashString += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
        }

        return hashString.PadLeft(32, '0');
    }
}
