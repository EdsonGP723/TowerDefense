using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public float speed;
	public int life;
	public float atackSpeed;
	public GameObject atack;
	private bool canMove = true;
	RaycastHit2D hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
	{
		StartCoroutine(Atack());
    }

    // Update is called once per frame
    void Update()
	{
		if (canMove == true)
		{
			Move();
		}
		Debug.DrawRay(transform.position, Vector3.up*.5f,Color.magenta, 0);
		hit = Physics2D.Raycast(transform.position,Vector2.up,.5f,LayerMask.GetMask("TowerMask"));
		
		if (hit.collider != null)
		{
			if (hit.collider.CompareTag("Tower"))
			{
				Debug.Log("Encontré torre");
				canMove = false;
			}
		}
    }
    
	private void Move(){
		transform.Translate(Vector2.up * speed);
	}
	    
	private IEnumerator Atack(){
		while (true)
		{
			atack.SetActive(false);
			Debug.DrawRay(transform.position, Vector3.up*.5f,Color.magenta, 0);
			RaycastHit2D atackRaycast = Physics2D.Raycast(transform.position,Vector2.up,.5f,LayerMask.GetMask("TowerMask"));
		
			if (atackRaycast.collider != null)
			{
				if (atackRaycast.collider.CompareTag("Tower"))
				{
					Debug.Log("Ataco torre");
					atack.SetActive(true);
					yield return new WaitForSeconds(atackSpeed);
					atack.SetActive(false);
				}
			}
			yield return new WaitForSeconds(atackSpeed);
		}
	}
}
