﻿using UnityEngine;
using System.Collections;

public class getZoneBuff : MonoBehaviour
{
	public OptimalZone optimalZone;
	bool added = false;

	void Update()
	{
		if (!added)
		{
			optimalZone.onTowerDrop(gameObject);
			added = true;
		}
	}
}
