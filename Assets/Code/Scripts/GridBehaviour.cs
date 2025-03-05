using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
	public GameObject cell;
	public GameObject tower;
	private Grid grid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    grid = new Grid(4,3,2f,cell,new Vector3(-4,-2));
    }

	// Update is called every frame, if the MonoBehaviour is enabled.
	private void Update()
	{
		if(Input.GetMouseButtonDown(0)){
			grid.SetTower(GetWorldPosition(),tower);
		}
	}
	
	private Vector3 GetWorldPosition(){
		Vector3 vec = GetMouseWorldPosition(Input.mousePosition);
		vec.z = 0f;
		return vec;
	}
	
	private Vector3 GetMouseWorldPosition(Vector3 screenPosition){
		Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
		return worldPosition;
	}
}
