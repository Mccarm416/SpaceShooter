using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {
	/*
	 * Created by Matthew McCarthy
	 * Date created: Oct 20, 2017
	 * Last modified: Oct 20, 2017
	 * Desc: Responsible for destroying the "explosion" animation
	*/
	//Removes the explosion animation
	public void DestroyMe() {
		Destroy (gameObject);
	}
}
