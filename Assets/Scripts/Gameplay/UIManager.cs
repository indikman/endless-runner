using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [Header("Score UIS")]
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : "+ Utils.score + "  Coins " +Utils.coin_count + (Utils.isScoreBoost?" <coin_boost> ":" ")+(Utils.isShield?"<shield> ":" ");
    }
}
