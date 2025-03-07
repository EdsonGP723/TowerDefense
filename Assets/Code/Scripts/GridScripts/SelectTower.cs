using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTower : MonoBehaviour
{
	public void SetTower1(){
		if (GameGlobals.coins >= 10)
		{
			GameGlobals.towerType = 1;
			GameGlobals.coins -= 10;
			GameGlobals.canPlace = true;
		}
	}
	public void SetTower2(){
		if (GameGlobals.coins >= 15)
		{
			GameGlobals.towerType = 2;
			GameGlobals.coins -= 15;
			GameGlobals.canPlace = true;
		}
	}
	public void SetTower3(){
		if (GameGlobals.coins >= 20)
		{
			GameGlobals.towerType = 3;
			GameGlobals.coins -= 20;
			GameGlobals.canPlace = true;
		}
	}
}
