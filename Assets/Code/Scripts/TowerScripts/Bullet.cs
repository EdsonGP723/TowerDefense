using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float speed = .1f;
   
    // Update is called once per frame
    void Update()
    {
	    transform.Translate(Vector2.down * speed);
    }
    
	// Sent when another object enters a trigger collider attached to this object (2D physics only).
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			gameObject.SetActive(false);
		}
	}
}
