using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public GameObject confirmObject;
	public GameObject credits;
	public LevelLoader levelLoader;

	void Awake(){
		levelLoader = ServiceLocator.GetService<LevelLoader>();
	}

	public void StartGame(string sceneName){
		StartCoroutine (levelLoader.LoadAsyncronously (sceneName));
	}
		
	public void Confirm(){
		confirmObject.SetActive (true);
	}

	public void ConfirmNo(){
		confirmObject.SetActive (false);
	}

	public void Credit(){
		credits.SetActive (true);
		Invoke ("QuitGame", 30);
	}

	public void QuitGame(){
		#if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false;
         #elif UNITY_WEBPLAYER
         Application.OpenURL("http://google.com");
         #else
         Application.Quit();
         #endif
	}
}
