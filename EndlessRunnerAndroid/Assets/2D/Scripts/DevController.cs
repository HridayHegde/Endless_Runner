using UnityEngine;
using System.Collections;

public class DevController : MonoBehaviour {

	public bool DeveloperMode;
	public bool VideoCaptureMode;
	//public GameObject DevCatcher;//For Not falling//This is no more a dev object..... 
	public GameObject DevCatcherforVideo;
	public GameObject RenderTextureForVideo;
	public GameObject CamforRenderTexture;
	public GameObject DirectionalLightReqRenderText;
	public bool QuitButtonActive;
	public KeyCode QuitButton;
	
		// Use this for initialization
	void Start () {

		if (DeveloperMode == true) {
			//DevCatcher.SetActive (true);
			DevCatcherforVideo.SetActive (true);
		} 
		else if (DeveloperMode == false) {
			//DevCatcher.SetActive(false);
			DevCatcherforVideo.SetActive(false);
		}

		if (VideoCaptureMode == true) {
			RenderTextureForVideo.SetActive (true);
			CamforRenderTexture.SetActive (true);
			DirectionalLightReqRenderText.SetActive (true);

		} 
		else if (VideoCaptureMode == false) {
			RenderTextureForVideo.SetActive(false);
			CamforRenderTexture.SetActive(false);
			DirectionalLightReqRenderText.SetActive(false);
			}
	}
	
	// Update is called once per frame
	void Update () {

		if (QuitButtonActive == true) {
			if(Input.GetKey(QuitButton))
			{
				Application.Quit();
			}
		
		}
	
	}
}
