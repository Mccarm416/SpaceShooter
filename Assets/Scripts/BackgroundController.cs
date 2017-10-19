using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	//Public variables, acessible from unity
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float startX;
	[SerializeField]
	private float endX;

	//Private variables
	private Transform _transform;
	private Vector2 _currentPos;

	void Start () {
		//Identifies the background
		_transform = gameObject.GetComponent<Transform> ();
		//Gets the background position
		_currentPos = _transform.position;
		Reset ();
	}
	
	// Update is called once per frame
	void Update () {
		_currentPos = _transform.position;
		//Move background horizontally
		_currentPos -= new Vector2 (speed, 0);
		//Check position for reset
		if (_currentPos.x < endX) {
			Debug.Log ("Reseting at" + _currentPos + "\n");
			Reset ();
		}
		//Apply changes
		_transform.position = _currentPos;
	}

	void Reset () {
		//Resests background image
		_currentPos = new Vector2 (startX, 0);
	}
}
	