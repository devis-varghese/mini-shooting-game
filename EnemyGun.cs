using UnityEngine;
using System.Collections;

public class EnemyGun : MonoBehaviour {
	public GameObject enemyBullets;    // prefab
	public GameObject enemyObject;   

	void Start () {
		
		Invoke ("EnemyFireBullets", 1f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void EnemyFireBullets() {
		
		GameObject playerAirplane = GameObject.Find ("AirCraft");
		if (playerAirplane != null) {
			enemyObject.GetComponent<EnemyController> ().animationChooser ("shooting");

			
			GameObject bullets = (GameObject)Instantiate (enemyBullets);
			
			GameObject bullets2 = (GameObject)Instantiate (enemyBullets);
			
			GameObject bullets3 = (GameObject)Instantiate (enemyBullets);

			
			bullets.transform.position = transform.position;
			bullets2.transform.position = transform.position;
			bullets3.transform.position = transform.position;

			
			Vector2 direction = playerAirplane.transform.position - bullets.transform.position;

			
			bullets.GetComponent<EnemyBullets> ().setBulletsDirection (direction);
			bullets2.GetComponent<EnemyBullets> ().setBulletsDirection (new Vector2(direction.x + 2, direction.y));
			bullets3.GetComponent<EnemyBullets> ().setBulletsDirection (new Vector2(direction.x - 2, direction.y));
		}
	}

}
