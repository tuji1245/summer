using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
	Material _material;
	Vector2 _textureSize;

	private void Start()
	{
		var _sprite = GetComponent<SpriteRenderer>();
		_material = _sprite.material;
		_textureSize = _sprite.size * 23;
	}
	private void FixedUpdate()
	{
		Scroll();
	}

	private void OnDestroy()
	{
		Destroy(_material); 
	}

	void Scroll()
	{
		Vector2 vec;
		vec.x = transform.position.x / _textureSize.x;
		vec.y = transform.position.y / _textureSize.y;
		_material.mainTextureOffset = vec;
	}
	


}
