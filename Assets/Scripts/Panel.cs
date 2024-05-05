using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
	void OnEnable()
	{
		AudioManager.instance.TryPlay2DEffect(2);
		LeanTween.scale(gameObject,new Vector3(1,1,1), .5f).setEaseOutBack();
	}
	public void Close()
	{
		AudioManager.instance.TryPlay2DEffect(3);
		LeanTween.scale(gameObject,Vector3.zero, .5f).setEaseInBack().setOnComplete(Disable);
	}
	void Disable()
	{
		GameManager.instance.uiManager.ShowButtons();
		gameObject.SetActive(false);
	}
}
