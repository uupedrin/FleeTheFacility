using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMenuCamera : MonoBehaviour
{
	void Update()
	{
		transform.RotateAround(Vector3.zero, Vector3.up, 10 * Time.deltaTime);
	}
}
