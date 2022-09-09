using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTime
{
	public static float gameObjectTime { get { return Time.fixedDeltaTime * gameObjectTimeCoef; } }
	public static float gameObjectTimeCoef = 1.0f;
	public static float titleObjectTime { get { return Time.fixedDeltaTime * titleObjectTimeCoef; } }
	public static float titleObjectTimeCoef = 1.0f;
	public static float resultObjectTime { get { return Time.fixedDeltaTime * resultObjectTimeCoef; } }
	public static float resultObjectTimeCoef = 1.0f;
}
