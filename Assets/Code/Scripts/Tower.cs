using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	public float FireRate;
	public float Range;
	public int Life;
	public Transform ShootPoint;
	public bool canShoot;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    StartCoroutine(RaycastEnemy());
    }

    // Update is called once per frame
    void Update()
	{
    }
    
	private IEnumerator RaycastEnemy(){
		
		while (true)
		{
			Debug.DrawRay(transform.position, Vector3.down*5,Color.magenta, 0);
			RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,Range,LayerMask.GetMask("EnemyMask"));
		
			if (hit.collider != null)
			{
				if (hit.collider.CompareTag("Enemy"))
				{
					Shoot();
				}
			}
			yield return new WaitForSeconds(FireRate);
		}
		
	}
    
	private void Shoot(){
		GameObject bullet = Pool.instance.GetPooledObject();
		if (bullet != null)
		{
			bullet.transform.position = ShootPoint.position;
			bullet.SetActive(true);
		}
	}
	
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("EnemyAtack"))
		{
			
		}
	}
	
	
	
}
