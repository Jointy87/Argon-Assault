using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	void Start()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		if(currentScene.name == "Splash")
		{
			Invoke("LoadNextScene", 2f);
		}
	}

	public void LoadNextScene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadSceneAsync(currentSceneIndex + 1);
	}

	public void RestartGame()
	{
		SceneManager.LoadSceneAsync("Splash");
	}
}
