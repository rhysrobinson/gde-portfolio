using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public static int Money;
	public int startMoney = 500;

	void Start()
	{
		Money = startMoney;
	}
}
