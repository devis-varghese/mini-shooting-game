using UnityEngine;
using System.Collections;

public class Stars : MonoBehaviour {
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 position = transform.position;    
		position = new Vector2(position.x, position.y + speed * Time.deltaTime);
		transform.position = position;    
		
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0, 0));    
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1, 1));    
		if ( transform.position.y < min.y ) {
			transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);
		}
	}
}
