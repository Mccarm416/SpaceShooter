using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

	//Removes the explosion animation
	public void DestroyMe() {
		Destroy (gameObject);
	}
}
