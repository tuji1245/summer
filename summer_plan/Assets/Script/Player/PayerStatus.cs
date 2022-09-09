using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus",menuName = "ScriptableObject/PlayereStatusObject")]
public class PayerStatus : ScriptableObject
{
	public int _Hp;
	public float _MoveSpeed;
}
