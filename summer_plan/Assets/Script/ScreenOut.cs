using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenOut : MonoBehaviour
{
	Renderer _renderer;

	private void Start()
	{
		_renderer = transform.Find("Sprite").GetComponent<Renderer>();
	}

	private void FixedUpdate()
	{
		// ‰æ–ÊŠO
		if (!_renderer.isVisible)
		{
			Destroy(gameObject);
		}
	}
}
