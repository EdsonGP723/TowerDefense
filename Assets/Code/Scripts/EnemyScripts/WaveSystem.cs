using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
	public GameObject WinPanel;
	public GameObject[] Enemies;
	public Transform[] SpawnPoints;
	public static int EnemiesAlive;
	public int enemyCount;
	public int waveCount = 0;
	public float spawnDelay = 0.5f; 
	private int maxWave = 4;
	private float timer = 10f;
	private bool canSpawn = true;
	private bool waveCompleted = false;
	private bool waveStarted = false;
    
	void Start()
	{
		// Inicializar para la primera oleada
		UpdateEnemyCount();
	}
    
	void Update()
	{
		Debug.Log("Timer: " + timer + ", Wave: " + waveCount + ", Enemies: " + EnemiesAlive + ", waveCompleted: " + waveCompleted);
        
		if (waveCount < maxWave)
		{
			// Si no hay enemigos vivos y la oleada ha comenzado pero no ha sido marcada como completada
			if (EnemiesAlive <= 0 && waveStarted && !waveCompleted)
			{
				waveCompleted = true; // Marca la oleada como completada
				waveStarted = false;  // Reinicia el estado de inicio de oleada
				waveCount++;          // Avanza a la siguiente oleada
                
				if (waveCount < maxWave)
				{
					UpdateEnemyCount(); // Actualiza el conteo de enemigos para la nueva oleada
					ResetTimer();       // Reinicia el temporizador para la próxima oleada
					canSpawn = true;    // Permite generar enemigos para la próxima oleada
				}
			}
            
			// Reduce el temporizador constantemente
			timer -= Time.deltaTime;
            
			// Si podemos generar y el temporizador llegó a cero
			if (canSpawn && timer <= 0)
			{
				SpawnEnemies();
				canSpawn = false;
				waveCompleted = false;
				waveStarted = true;
				ResetTimer(); // Reinicia el temporizador para la próxima oleada
			}
		}
		else
		{
			WinPanel.SetActive(true);
		}
	}
    
	private void SpawnEnemies()
	{
		EnemiesAlive = enemyCount; // Actualiza el contador de enemigos vivos
		StartCoroutine(SpawnEnemiesWithDelay());
		Debug.Log("Oleada " + waveCount + ": Iniciando generación de " + enemyCount + " enemigos");
	}
    
	private IEnumerator SpawnEnemiesWithDelay()
	{
		for (int i = 0; i < enemyCount; i++) 
		{
			int spawnobj = Random.Range(0, Enemies.Length);
			int spawnpoint = Random.Range(0, SpawnPoints.Length);
            
			GameObject enemy = Instantiate(Enemies[spawnobj], SpawnPoints[spawnpoint].position, SpawnPoints[spawnpoint].rotation);
			
            
			yield return new WaitForSeconds(spawnDelay);
		}
	}
    
	private void ResetTimer()
	{
		timer = 10f;
	}
    
	private void UpdateEnemyCount()
	{
		switch (waveCount)
		{
		case 0:
			enemyCount = 10;
			break;
		case 1:
			enemyCount = 15;
			break;
		case 2:
			enemyCount = 20;
			break;
		default:
			enemyCount = 10;
			break;
		}
	}
}