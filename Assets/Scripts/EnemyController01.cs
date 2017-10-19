using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController01 : MonoBehaviour {
	//Harder enemy with increased speeds


	[SerializeField]
	float minYSpeed = -1f;
	[SerializeField]
	float maxYSpeed = 1f;
	[SerializeField]
	float minXSpeed = 10f;
	[SerializeField]
	float maxXSpeed = 15f;

	private Transform _transform;
	private Vector2 _currentPos;
	private Vector2 _currentSpeed;

	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
		Reset ();
	}

	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		_currentPos -= _currentSpeed;
		_transform.position = _currentPos;

		//Checks to see if enemy is offscreen and replaces it
		if (_currentPos.x <= -500) {
			Reset ();
		}
		if (_currentPos.y <= -352) {
			Reset ();
		}
		if (_currentPos.y >= 352) {
			Reset ();
		}
	}

	public void Reset(){
		float xSpeed = Random.Range (minXSpeed, maxXSpeed);
		float ySpeed = Random.Range (minYSpeed, maxYSpeed);

		_currentSpeed = new Vector2 (xSpeed, ySpeed);

		//Place enemy in random location off of the screen
		//Harder enemy has a further x placement to decrease frequency
		float x = Random.Range (2500, 4000);
		float y = Random.Range (-150, 150);
		_transform.position = 
			new Vector2 (x, y);

	}

}
