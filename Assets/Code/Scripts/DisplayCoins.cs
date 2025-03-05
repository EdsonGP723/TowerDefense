using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayCoins : MonoBehaviour
{
	public TMP_Text Coins;

    // Update is called once per frame
    void Update()
    {
	    Coins.text = GameGlobals.coins.ToString();
    }
}
