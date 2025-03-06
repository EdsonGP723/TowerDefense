using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Base : MonoBehaviour
{
	public GameObject GameOverPanel;  
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			GameOverPanel.SetActive(true);
		}
	}
}
