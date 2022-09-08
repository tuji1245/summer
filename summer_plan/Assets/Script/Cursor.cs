using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Cursor : MonoBehaviour
{
	private void Start()
	{
	#if !UNITY_EDITOR
		UnityEngine.Cursor.visible = false;
	#endif
	}
	private void FixedUpdate()
	{
		RePoint();	
	}

	void RePoint()
	{
		Mouse mouse = Mouse.current;
		if(mouse == null){ return; }
		Vector2 mousePos = mouse.position.ReadValue();
		float z = (float)LayerConfig.OrderByZ.Cursor;
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, z));
	}
}
