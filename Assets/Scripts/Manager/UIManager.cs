using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
	public bool createSoundEffects = false;
	IEnumerator Start()
	{
		yield return new WaitForSeconds(.2f);
		if(createSoundEffects)
		{
			AudioManager.instance.CreateSFX();
		}
	}
	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
	
	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
