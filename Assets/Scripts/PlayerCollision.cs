using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {


	private AudioSource _explosionSound;
	[SerializeField]
	GameObject explosion;

	// Use this for initialization
	void Start () {
		_explosionSound = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnTriggerEnter2D(Collider2D other) {
		//Detects collision with objects and responds accordingly
	
		if (other.gameObject.tag.Equals ("enemy01")) {
			Debug.Log ("Collision enemy01\n");
			if (_explosionSound != null)
				_explosionSound.Play ();
			
			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;
			other.gameObject.GetComponent<EnemyController01> ().Reset ();
		}
		else if (other.gameObject.tag.Equals ("enemy02")) {
			Debug.Log ("Collision enemy02\n");
			if (_explosionSound != null)
				_explosionSound.Play ();

			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;
			other.gameObject.GetComponent<EnemyController02> ().Reset ();
		}
		else if (other.gameObject.tag.Equals ("enemy03")) {
			Debug.Log ("Collision enemy03\n");
			if (_explosionSound != null)
				_explosionSound.Play ();

			Instantiate (explosion).GetComponent<Transform> ().position = other.gameObject.GetComponent<Transform> ().position;
			other.gameObject.GetComponent<EnemyController03> ().Reset ();
		}
		else if (other.gameObject.tag.Equals ("pickup")) {
			Debug.Log ("Collision pickup\n");
		}
	}
}
