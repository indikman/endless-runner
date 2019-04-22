using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    
    void OnEnable()
    {
        GetComponent<Animator>().Play("coin_rotate", -1, Random.Range(0.0f, 1.0f));
    }

}
