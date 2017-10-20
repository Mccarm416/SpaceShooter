using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	/*
	 * Created by Matthew McCarthy
	 * Date created: Oct 20, 2017
	 * Last modified: Oct 20, 2017
	 * Desc: Handles functions of the UI
	*/

	//Life total in the upper right during game
	[SerializeField]
	Text lblLife;
	//Score total in the upper left during game
	[SerializeField]
	Text lblScore;
	//High score label displayed during game over
	[SerializeField]
	Text lblHighScore;
	//Game over label
	[SerializeField]
	Text lblGameOver;
	//Restart button displayed during game over; restarts the game.
	[SerializeField]
	Button btnRestart;


	private int _highScore;
	private int _score = 0;
	private int _life = 3;

	//Getters and setters
	public int Score { 
		get { return _score; }
		set { _score = value; 
			lblScore.text = "Score: " + +_score;
		}
	}

	public int Life {
		get { return _life; }
		set { _life = value; 
			//Update UI
			if (_life <= 0) {
				gameOver ();
			}
			else {
				lblLife.text = "Life: " + _life;
			}
		}
	}

	public int HighScore {
		get { return _highScore; }
		set { _highScore = value; }
	}

	private void initialize() {
		//Initialize the UI, scores, and life
		_highScore = PlayerPrefs.GetInt("highScore");
		Debug.Log("High Score is: " + _highScore);
		_score = 0;
		_life = 3;
		//Hide and display relevant labels
		lblGameOver.gameObject.SetActive (false);
		lblHighScore.gameObject.SetActive (false);
		btnRestart.gameObject.SetActive (false);

		lblLife.gameObject.SetActive (true);
		lblScore.gameObject.SetActive (true);
	}

	private void gameOver() {
		//Show game over screen, update highscore if needed
		if (_highScore < _score) {
			lblHighScore.text = "High Score: " + _score;
			_highScore = _score;
			PlayerPrefs.SetInt ("highScore", _highScore);
			PlayerPrefs.Save ();
			Debug.Log ("High Score of " + _highScore + " has been saved!");
		} 
		else {
			lblHighScore.text = "High Score: " + _highScore;
		}
		//Hide and display relevant labels
		lblGameOver.gameObject.SetActive (true);
		lblHighScore.gameObject.SetActive (true);
		btnRestart.gameObject.SetActive (true);

		lblLife.gameObject.SetActive (false);
		lblScore.gameObject.SetActive (false);
	}

	public void btnResetClick() {
		//Resets the game
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
	// Use this for initialization
	void Start () {
		initialize ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
