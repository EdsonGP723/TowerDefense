using UnityEngine;

public class Bullet : MonoBehaviour
{
	private float speed = .1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(Vector2.down * speed);
    }
    
	// Sent when an incoming collider makes contact with this object's collider (2D physics only).
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			gameObject.SetActive(false);
		}
	}
}
