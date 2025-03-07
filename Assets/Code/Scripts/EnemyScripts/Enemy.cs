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

    void Start()
	{
		StartCoroutine(Atack());
    }


    void Update()
	{
		if (canMove == true)
		{
			Move();
		}
		
		Debug.DrawRay(transform.position, Vector3.up*.5f,Color.magenta, 0);
		
		// Sistema de detección: lanza un rayo hacia arriba para detectar torres
		hit = Physics2D.Raycast(transform.position,Vector2.up,.5f,LayerMask.GetMask("TowerMask"));
		
		if (hit.collider != null)
		{
			// Si detecta una torre, se detiene
			if (hit.collider.CompareTag("Tower"))
			{
				canMove = false;
			}
			else
			{
				canMove = true;
			}
		}
		
		// Sistema de muerte: actualiza contadores globales y desactiva el objeto
		if (life <= 0)
		{
			// Reduce el contador de enemigos vivos (importante para el sistema de oleadas)
			WaveSystem.EnemiesAlive -= 1;
			// Recompensa al jugador con monedas
			GameGlobals.coins += 2;
			this.gameObject.SetActive(false);
		}
    }
    
	private void Move(){
		transform.Translate(Vector2.up * speed);
	}
	    
	// Sistema de ataque: verifica continuamente si hay torres para atacar
	private IEnumerator Atack(){
		while (true)
		{
			atack.SetActive(false);
			Debug.DrawRay(transform.position, Vector3.up*.5f,Color.magenta, 0);
			RaycastHit2D atackRaycast = Physics2D.Raycast(transform.position,Vector2.up,.5f,LayerMask.GetMask("TowerMask"));
		
			if (atackRaycast.collider != null)
			{
				// Si detecta una torre, activa el ataque por un tiempo determinado
				if (atackRaycast.collider.CompareTag("Tower"))
				{
					atack.SetActive(true);
					yield return new WaitForSeconds(atackSpeed);
					atack.SetActive(false);
				}
			}
			yield return new WaitForSeconds(atackSpeed);
		}
	}
	
	// Sistema de daño: detecta colisiones con proyectiles
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Bullet"))
		{
			life -=4;
		}
	}
}
