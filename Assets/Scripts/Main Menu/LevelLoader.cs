using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	private static LevelLoader instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}
		DontDestroyOnLoad (gameObject);
	}

	public IEnumerator LoadAsyncronously(string sceneName) {

		AsyncOperation operation = SceneManager.LoadSceneAsync (sceneName);

		while (!operation.isDone) {
			Debug.Log (operation.progress);
			yield return null;
		}
	}
}