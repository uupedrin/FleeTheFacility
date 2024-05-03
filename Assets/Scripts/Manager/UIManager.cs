using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	void Start()
	{
		//GameManager.instance.uiManager = this;
	}
	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
