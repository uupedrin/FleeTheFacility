using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public MainMenuUI uiManager;
	void Awake()
	{
		if(instance != null  && instance != this)
		{
			Destroy(this);
		}
		else
		{
			instance = this;
		}
		transform.SetParent(null);
		DontDestroyOnLoad(gameObject);
	}
	
	
}
