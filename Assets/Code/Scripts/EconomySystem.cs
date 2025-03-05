using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    
    void Start()
    {
	    StartCoroutine(GetCoins());
    }
    
	private IEnumerator GetCoins(){
		while (true)
		{
			GameGlobals.coins ++;
			yield return new WaitForSeconds(5f);
		}
	}
}
