using UnityEngine;
using System.Collections;

public class EnemyBullets : MonoBehaviour {
	float speed;    
	Vector2 bulletDirection;    
	bool isReady;    

	// initialize variables or game state before the game starts
	void Awake() {
		speed = 5f;
		isReady = false;
	}

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if ( isReady ) {
			
			Vector2 position = transform.position;
			
			position += bulletDirection * speed * Time.deltaTime;
			
			transform.position = position;

			
			Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
			
			Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
			if ( transform.position.x > max.x || transform.position.y > max.y || 
				transform.position.x < min.x  || transform.position.y < min.y ) {
				Destroy (gameObject);
			}
		}
	}

	
	public void setBulletsDirection( Vector2 dir ) {
		bulletDirection = dir.normalized;
		isReady = true;
	}

	void OnTriggerEnter2D(Collider2D _collider) {
		
		if ( _collider.tag == "PlayerShipTag" ) {
			Destroy (gameObject);
		}
	}

}
