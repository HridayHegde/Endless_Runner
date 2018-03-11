using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public Transform platformGenerator;
	private Vector3 platformStartpoint;

	public PlayerController ThePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager ScoreMan;

	private GameObject OnDeathCanvas;
	public GameObject EndScoreText;

	private GameObject OnPauseCanvas;
	public bool Paused = false;

    public bool DED;


	// Use this for initialization
	void Start () {
		platformStartpoint = platformGenerator.position;
		playerStartPoint = ThePlayer.transform.position;

		ScoreMan = GameObject.Find ("ScoreManager").GetComponent<ScoreManager> ();


		EndScoreText = GameObject.Find ("EndScoreText");
		OnDeathCanvas = GameObject.Find ("OnDeathCanvas");
		OnPauseCanvas = GameObject.Find ("OnPauseCanvas");
		OnDeathCanvas.SetActive (false);
		OnPauseCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Death()
	{
        DED = true;

        EndScoreText.GetComponent<Text> ().text = ScoreMan.scoreText.text;
		OnDeathCanvas.SetActive (true);
		Time.timeScale = 0f;
	
	}

	public void Pause()
	{
        if (!DED)
        {
            if (Paused)
            {
                Paused = false;
                OnPauseCanvas.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                Paused = true;
                OnPauseCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
	}

	public void RestartGame()
	{
        DED = false;
		Time.timeScale = 1f;
		EndScoreText.GetComponent<Text>().text = "Score : ";
		OnDeathCanvas.SetActive (false);
		StartCoroutine ("RestartGameCo");

	}

	public IEnumerator RestartGameCo()
	{
		ScoreMan.scoreCount = 0f;
		ThePlayer.gameObject.SetActive (false);

		yield return new WaitForSeconds (0.5f);
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) {
			platformList [i].gameObject.SetActive (false);
		
		}
		ThePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartpoint;
		ThePlayer.gameObject.SetActive (true);

	}
}
