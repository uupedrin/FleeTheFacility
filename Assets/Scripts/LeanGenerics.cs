using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanGenerics : MonoBehaviour
{
	
	public void Grow(float amount)
	{
		LeanTween.scale(gameObject, new Vector3(amount,amount,amount), .2f);
	}
}
