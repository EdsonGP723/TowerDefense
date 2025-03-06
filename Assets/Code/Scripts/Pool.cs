using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	public static Pool instance;
	
	private List<GameObject> pooledObjects = new List<GameObject>();
	private int amountToPool = 50;
	
	[SerializeField]
	private GameObject bulletPrefab;
	
	// Awake is called when the script instance is being loaded.
	private void Awake()
	{
		if(instance == null){
			instance = this;
		}
	}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    for (int i = 0; i < amountToPool; i++) {
	    	GameObject obj = Instantiate(bulletPrefab);
	    	obj.SetActive(false);
	    	pooledObjects.Add(obj);
	    }
    }

	public GameObject GetPooledObject(){
		for (int i = 0; i < pooledObjects.Count; i++) {
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		return null;
	}
}
