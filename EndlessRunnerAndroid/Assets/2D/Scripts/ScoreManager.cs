using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text hiscoreText;

	public float scoreCount;
	public float hiscoreCount;

	public float pointsPerSecond;

	public bool scoreincreasing;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("HighScore"))
		{
			hiscoreCount = PlayerPrefs.GetFloat("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (scoreincreasing) 
		{
			scoreCount += pointsPerSecond * Time.deltaTime;
		}
		if (scoreCount > hiscoreCount)
		{
			hiscoreCount = scoreCount;
			PlayerPrefs.SetFloat("HighScore",hiscoreCount);
		}

		scoreText.text = "Score: " + Mathf.Round (scoreCount);
		hiscoreText.text = "High Score: " + Mathf.Round(hiscoreCount);

	
	}

	public void AddScore(int pointsToAdd)
	{
		scoreCount += pointsToAdd;
	}
}
