using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Selection : MonoBehaviour
{
	Vector3 pos;
	[SerializeField] Transform mousePointer;
	[SerializeField] float offset;
	public List<GameObject> selectedItems = new List<GameObject>();

	[SerializeField] RectTransform selectionBox;
	Vector2 mouseStart;
	[SerializeField] List<GameObject> unitList;
	public LayerMask unitMask;

	void Start()
	{

	}

	void Update()
	{
		pos = Input.mousePosition;
		pos.z = offset;
		mousePointer.position = Camera.main.ScreenToWorldPoint(pos);
		transform.LookAt(mousePointer);
		if(Input.GetButtonDown("Fire1")) 
		{
			selectedItems.Clear();
			selectionBox.gameObject.SetActive(true);
			selectionBox.sizeDelta = Vector2.zero;
			mouseStart = Input.mousePosition;
			for(int i = 0; i < unitList.Count; i++)
			{
				unitList[i].tag =  "Unselected";
			}
		}
		if(Input.GetButton("Fire1")) 
		{
			BoxSize();
		}
		else if(Input.GetButtonUp("Fire1"))
		{
			if(selectionBox.sizeDelta == Vector2.zero) QuickClick();
			Debug.Log(selectedItems.Count);
			selectionBox.sizeDelta = Vector2.zero;
			selectionBox.gameObject.SetActive(false);
			for(int i = 0; i < selectedItems.Count; i++)
			{
				Debug.Log(selectedItems[i].name);
			}
		}
		if(Input.GetMouseButtonDown(1))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(selectedItems.Count > 0)
			{
				if(Physics.Raycast(ray, out hit))
				{
					for (int i = 0; i < selectedItems.Count; i++)
					{
						
						selectedItems[i].GetComponent<NavMeshAgent>().SetDestination(hit.point);
					}
				}
			}
		}
	}

	void QuickClick()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, unitMask)) 
		{
			hit.transform.gameObject.tag = "Selected";
			selectedItems.Add(hit.transform.gameObject);
		}
	}

	void BoxSize()
	{
		float width = Input.mousePosition.x - mouseStart.x;
		float height = Input.mousePosition.y - mouseStart.y;
		selectionBox.anchoredPosition = mouseStart + new Vector2(width/2, height/2);
		selectionBox.sizeDelta = new Vector2(Math.Abs(width), Math.Abs(height));
		Bounds bounds = new Bounds(selectionBox.anchoredPosition, selectionBox.sizeDelta);
		for(int i = 0; i < unitList.Count; i++)
		{
			if(UnitIsInBox(Camera.main.WorldToScreenPoint(unitList[i].transform.position), bounds) && unitList[i].tag == "Unselected")
			{
				selectedItems.Add(unitList[i]);
				unitList[i].tag =  "Selected";
			}
		}
	}

	bool UnitIsInBox(Vector2 position, Bounds bounds)
	{
		return position.x > bounds.min.x && position.x < bounds.max.x && position.y > bounds.min.y && position.y < bounds.max.y;
	}
}
