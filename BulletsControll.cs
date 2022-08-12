using UnityEngine;
using System.Collections;

public class BulletsControll : MonoBehaviour {
	float speed;
	// Use this for initialization
	void Start () {
		speed = 8f;
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 position = transform.position;

	
		position = new Vector2 (position.x, position.y + speed * Time.deltaTime);

		
		transform.position = position;
		//print (position);


		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		
		if (transform.position.y > max.y) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D _collider) {
	
		if ( _collider.tag == "EnemyShipTag" ) {
			Destroy (gameObject);
		}
	}
}
