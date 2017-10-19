using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float rightX;
	[SerializeField]
	private float leftX;
	[SerializeField]
	private float topY;
	[SerializeField]
	private float botY;



	private Transform _transform;
	private Vector2 _currentPos;

	void Start () {
		_transform = gameObject.GetComponent<Transform> ();
		_currentPos = _transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
			_currentPos -= new Vector2 (speed, 0);
		}
		if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) {
			_currentPos += new Vector2 (speed, 0);
		}
		if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.UpArrow)) {
			_currentPos += new Vector2 (0, speed);
		}
		if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.DownArrow)) {
			_currentPos -= new Vector2 (0, speed);
		}
		CheckBoundary ();
		_transform.position = _currentPos;
	}
		
	private void CheckBoundary() {
		//Checks the players position against the camera boundary to prevent them from moving off of it
		if (_currentPos.x < leftX) {
			_currentPos.x = leftX;
		}
		if (_currentPos.x > rightX) {
			_currentPos.x = rightX;
		}
		if (_currentPos.y > topY) {
			_currentPos.y = topY;
		}
		if (_currentPos.y < botY) {
			_currentPos.y = botY;
		}
	}
}
