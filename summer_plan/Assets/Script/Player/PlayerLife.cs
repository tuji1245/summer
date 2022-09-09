using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerLife : MonoBehaviour
{
	Player _player;
	TextMeshProUGUI _tmp;
	private void Start()
	{
		_player = GameObject.Find("Player").GetComponent<Player>();
		_tmp = GetComponent<TextMeshProUGUI>();
	}

	private void Update()
	{
		DrawHP(_player._HP);
	}

	void DrawHP(int val)
	{
		_tmp.text = "Life: " + val;
	}
}
