using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameObserver : MonoBehaviour
{
	public enum GameMode
	{
		Game,
		Result
	}
	static GameMode _curMode;

	private void Start()
	{
		_curMode = GameMode.Game;
	}

	public static void ChangeMode(GameMode gameMode)
	{
		if (_curMode == gameMode) return;

		switch(gameMode)
		{
			case GameMode.Game:
				SceneManager.LoadScene("game");
				break;
			case GameMode.Result:
				MyTime.gameObjectTimeCoef = 0.0f;
				MyTime.resultObjectTimeCoef = 1.0f;
				break;
		}
	}
}
