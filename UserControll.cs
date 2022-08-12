using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserControll : MonoBehaviour {
	public GameObject gameManager; 
	public float speed;
	public GameObject bullets;    
	public GameObject bulletPosition1;
	public GameObject bulletPosition2;
	public GameObject exposion;     
	private const float firstX = 0.01f;
	private const float firstY = -2.53f;
	private Animator anim;
	float firerate = 0.25f;
	private float nextFire = 0.15f;

	public Text lives;    
	const int MaxLive = 3;
	int NowLive;    

	public void Init() {
		NowLive = MaxLive;
		lives.text = NowLive.ToString();    
		gameObject.transform.position = new Vector2 (firstX, firstY);
		gameObject.SetActive(true);   
	}
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if ( Input.GetKey(KeyCode.C) && Time.time > nextFire ) {
			animationChooser ("shooting");
			gameObject.GetComponent<AudioSource> ().Play ();    // 音效
			GameObject bullets01 = (GameObject)Instantiate (bullets);
			bullets01.transform.position = bulletPosition1.transform.position;

			GameObject bullets02 = (GameObject)Instantiate (bullets);
			bullets02.transform.position = bulletPosition2.transform.position;
			nextFire = Time.time + firerate;
		} else if ( Input.GetKeyDown(KeyCode.Alpha1) ) {
			speed = 2f;
		} else if ( Input.GetKeyDown(KeyCode.Alpha2) ) {
			speed = 4f;
		} else if ( Input.GetKeyDown(KeyCode.Alpha3) ) {
			speed = 6f;
		} else if ( Input.GetKeyDown(KeyCode.Alpha4) ) {
			speed = 8f;
		}
			
		float x = Input.GetAxisRaw ("Horizontal");   
		float y = Input.GetAxisRaw ("Vertical");      
		
		Vector2 direction = new Vector2 (x, y).normalized;    
        Move (direction);
	}

	void Move (Vector2 dir) {
       
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));    
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));    

		// Sprite x, y 
		//float player_x = GetComponent<SpriteRenderer>().bounds.size.x;
		//float player_y = GetComponent<SpriteRenderer>().bounds.size.y;
		//float half = 2.0f;
		//print ("Player X: " +player_x);
		//print ("Player Y: " +player_y);
        
        // Sprite 
		max.x = max.x - 0.15f;    //  Player Sprite
		min.x = min.x + 0.2f;    //  Player Sprite 
		max.y = max.y - 0.15f;    //  Player Sprite
		min.y = min.y + 0.2f;    //  Player Sprite 

        
        Vector2 pos = transform.position;

       
        pos += dir * speed * Time.deltaTime;

        
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        
        transform.position = pos;
	}

	void OnTriggerEnter2D(Collider2D _collider) {
		
		if ( _collider.tag == "EnemyShipTag" || _collider.tag == "EnemyBulletTag" ) {
			NowLive--;
			lives.text = NowLive.ToString ();
			GameObject expo = (GameObject)Instantiate (exposion);
			expo.transform.position = transform.position;
			if ( NowLive == 0 ) {
				
				gameManager.GetComponent<GameManager> ().SetGameState (GameManager.GameStates.GameOver);
				gameObject.SetActive (false);   
			} else {
				//Destroy (gameObject);
				gameObject.SetActive (false);
				Invoke ("airplaneRebirth", 2f);  
			}
		}

	}

	public void airplaneRebirth() {
		// return first place
		gameObject.transform.position = new Vector2 (firstX, firstY);
		gameObject.SetActive (true);
	}

	public void animationChooser(string action) {
		switch(action) {
		case "shooting":
			anim.SetBool ("Shooting", true);
			break;
		case "unshooting":
			anim.SetBool ("Shooting", false);
			break;
		default:
			break;
		}
	}
}