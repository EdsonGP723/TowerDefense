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
	
   
    void Start()
    {
	    StartCoroutine(RaycastEnemy());
    }

    
    void Update()
	{
		if (Life <= 0)
		{
			this.gameObject.SetActive(false);
		}
    }
    
	private IEnumerator RaycastEnemy(){
		// Corrutina que se ejecuta continuamente para detectar enemigos
		while (true)
		{
			Debug.DrawRay(transform.position, Vector3.down*5,Color.magenta, 0);
			// Lanza un rayo hacia abajo para detectar enemigos en la capa "EnemyMask"
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
		// Obtiene una bala del sistema de pool de objetos
		GameObject bullet = Pool.instance.GetPooledObject();
		if (bullet != null)
		{
			bullet.transform.position = ShootPoint.position;
			bullet.SetActive(true);
		}
	}
	
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("EnemyAtack"))
		{
			Life -= 2;
		}
	}
	
	
	
}
