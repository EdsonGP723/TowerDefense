using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	public static Pool instance;
	
	private List<GameObject> pooledObjects = new List<GameObject>();
	private int amountToPool = 30;
	
	[SerializeField]
	private GameObject bulletPrefab;
	
	// Este método asegura que solo exista una instancia de Pool en la escena
	private void Awake()
	{
		if(instance == null){
			instance = this;
		}
	}
    
    void Start()
	{
		// Instancia todos los objetos y los desactiva para tenerlos listos para usar
	    for (int i = 0; i < amountToPool; i++) {
	    	GameObject obj = Instantiate(bulletPrefab);
	    	obj.SetActive(false);
	    	pooledObjects.Add(obj);
	    }
    }

	// Método principal para obtener un objeto disponible del pool
	public GameObject GetPooledObject(){
		// Busca el primer objeto inactivo y lo devuelve para ser utilizado
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		// Devuelve null si todos los objetos están en uso
		return null; 
	}
}
