using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemy;    
	float maxSpawnRateInSecond = 5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	//  Method
	void SpawnEnemy() {
		
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));
		
		GameObject enemy01 = (GameObject)Instantiate (enemy);
		enemy01.transform.position = new Vector2 (Random.Range(min.x, max.x), max.y);

		NextSpawnSheduler ();
	}

	
	void NextSpawnSheduler() {
		float spawnInNSec;
		if ( maxSpawnRateInSecond > 1f ) {
			
			spawnInNSec = Random.Range (1f, maxSpawnRateInSecond);
		} else {
			spawnInNSec = 1f;
		}
		Invoke ("SpawnEnemy", spawnInNSec);
	}

	
	void IncreseSpawnRate() {
		if ( maxSpawnRateInSecond > 1f ) {
			maxSpawnRateInSecond--;
		}

		if ( maxSpawnRateInSecond == 1f ) {
			CancelInvoke ("IncreseSpawnRate");
		}
	}

	
	public void StartEnemySpawn() {
		maxSpawnRateInSecond = 5f;   
		Invoke ("SpawnEnemy", maxSpawnRateInSecond);
		
		InvokeRepeating("IncreseSpawnRate", 0f, 30f);
	}

	
	public void StopEnemySpawn() {
		CancelInvoke ("SpawnEnemy");
		CancelInvoke ("IncreseSpawnRate");
	}

}
