using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	float speed;
	public int score;
	public int life;
	public GameObject exposion;    // prefab
	GameObject scoreTextUI;   
	private Animator anim;
	// Use this for initialization
	void Start () {
		speed = 2f;    
		scoreTextUI = GameObject.FindGameObjectWithTag("ScoreUITag");
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		Vector2 position = transform.position;

		
		position = new Vector2 (position.x, position.y - speed * Time.deltaTime);
		transform.position = position;

		
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		if ( transform.position.y < min.y ) {
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D _collider) {
		
		if ( _collider.tag == "PlayerBulletTag" ) {
			life--;
			if ( life == 0 ) {
				Destroy (gameObject);
				scoreTextUI.GetComponent<GameScore> ().Score += score;    // 更新分數
				GameObject expo = (GameObject)Instantiate (exposion);
				expo.transform.position = transform.position;
			}
		}
	}

	public void animationChooser(string method) {
		switch(method) {
		case "shooting":
			anim.SetBool ("shooting", true);
			break;
		case "unshooting":
			anim.SetBool ("shooting", false);
			break;
		default:
			break;
		}
	}
}
