using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class SceneController : MonoBehaviour
 {
	public void LoadMenuScene() {
        SceneManager.LoadScene("MenuScene");
    }

    public void NextScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

	public void LoadSceneByIndex(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

	public void ReloadScene() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

	public static IEnumerator WaitThenLoadScene(float seconds, int sceneIndex)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(sceneIndex);
    }
}