using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
	int level1 = 1;
	int win = 2;
	int lose = 3;
	public void LoadNextScene() //Next Scene
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}
	public void LoadPrevScene() //Previous Scene
    {
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex - 1);
	}
	public void LoadLevel1Scene()
	{
		int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(level1);
	}
	public void LoadStartScene() //Start
    {
		SceneManager.LoadScene(0);
    }
	public void LoadWinScene() //Win
    {
		SceneManager.LoadScene(win);
    }
	public void LoadLoseScene() //Lose
	{
		SceneManager.LoadScene(lose);
	}
	public void QuitGame() //Close Game
    {
		Application.Quit();
    }
}
