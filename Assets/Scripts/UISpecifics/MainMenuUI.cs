using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class MainMenuUI : UIManager
{
	public TMP_Text title;
	public Button[] menuItems;
	public float buttonDelay = .2f;
	public GameObject transitionBoxes;
	
	void Start()
	{
		GameManager.instance.uiManager = this;
		
		LeanTween.scaleY(transitionBoxes.transform.GetChild(0).gameObject, 0, 0);
		LeanTween.scaleY(transitionBoxes.transform.GetChild(1).gameObject, 0, 0);
		for (int i = 0; i < menuItems.Count(); i++)
		{
			Vector3 originalMenuPos = menuItems[i].transform.position;
			LeanTween.move(menuItems[i].gameObject, originalMenuPos + Vector3.down * 300, 0);
		}
		TitleAnimation();
	}
	
	private void TitleAnimation()
	{
		Vector3 originalTitlePos = title.transform.position;
		LeanTween.move(title.gameObject,originalTitlePos + Vector3.up * 200, 0);
		LeanTween.move(title.gameObject,originalTitlePos,2).setEaseInOutElastic().setOnComplete(ShowStart);
		
	}
	
	void RotateTitle()
	{
		LeanTween.rotateZ(title.gameObject, -3, 1f);
		LeanTween.rotateZ(title.gameObject, 3, 1.5f).setLoopPingPong().setDelay(1f);
	}
	
	void ShowStart()
	{
		RotateTitle();
		ShowButtons();
	}
	
	public void ShowButtons()
	{
		for (int i = 0; i < menuItems.Count(); i++)
		{
			Vector3 originalMenuPos = menuItems[i].transform.position;
			LeanTween.move(menuItems[i].gameObject, originalMenuPos + Vector3.up * 300, .35f).setEaseOutSine().setDelay(i * buttonDelay);
		}
	}
	
	public void HideButtons()
	{
		for (int i = menuItems.Count() -1, j = 0; i >= 0; i--, j++)
		{
			Vector3 originalMenuPos = menuItems[i].transform.position;
			LeanTween.move(menuItems[i].gameObject, originalMenuPos + Vector3.down * 300, .35f).setEaseInSine().setDelay(j * buttonDelay);
		}
	}
	
	public void StartTransition()
	{
		GameObject UpBox = transitionBoxes.transform.GetChild(0).gameObject;
		GameObject LowBox = transitionBoxes.transform.GetChild(1).gameObject;
		
		LeanTween.scaleY(UpBox, 1, 2).setEaseOutBounce();
		LeanTween.scaleY(LowBox, 1, 2).setEaseOutBounce().setOnComplete(ChangeScene);
	}
	
	public void ChangeScene()
	{
		//Change Scene Here
		QuitGame();
	}
}
