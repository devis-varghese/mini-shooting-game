using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlanetGenerator : MonoBehaviour {
	public GameObject[] planets;
	Queue<GameObject> avaliablePlanets = new Queue<GameObject>();
	// Use this for initialization
	void Start () {
		
		avaliablePlanets.Enqueue (planets [0]);
		avaliablePlanets.Enqueue (planets [1]);
		avaliablePlanets.Enqueue (planets [2]);
		
		InvokeRepeating("MovePlanet", 0, 20f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void MovePlanet() {
		EnqueuePlanets ();
		// Queue 
		if (avaliablePlanets.Count == 0)
			return;

		// get planets
		GameObject aplanet = avaliablePlanets.Dequeue();
		aplanet.GetComponent<Planet> ().isMoving = true;
	}

	// planets 
	void EnqueuePlanets() {
		//int i = 0;
		foreach(GameObject a_planet in planets) {
			if ( (a_planet.transform.position.y < 0) && !(a_planet.GetComponent<Planet>().isMoving) ) {
				a_planet.GetComponent<Planet> ().ResetPosition ();
				avaliablePlanets.Enqueue (a_planet);
				//print ("The" + (i++) + "Planets pos: " + a_planet.transform.position.x+", "+a_planet.transform.position.y);
			}
		}
	}
}
