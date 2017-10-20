using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField]
	Text lblLife;
	[SerializeField]
	Text lblScore;
	[SerializeField]
	Text lblHighScore;
	[SerializeField]
	Text lblGameOver;
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
