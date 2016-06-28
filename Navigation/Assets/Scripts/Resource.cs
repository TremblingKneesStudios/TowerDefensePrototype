using UnityEngine;
using System.Collections;

public class Resource : MonoBehaviour {

	public enum ResourceType
	{
		crystal,
		ironOre,
		elixir,
		essence
	}

	public ResourceType currentType;

	public float resourceAmount;

	public ResourceType GetResourceType()
	{
		return currentType;
	}

	public float TakeResource(float mineRate)
	{
		float minedAmount;

		if (resourceAmount >= mineRate)
		{
			minedAmount = mineRate;
		}
		else
		{
			minedAmount = resourceAmount;
		}

		resourceAmount -= minedAmount;

		return minedAmount;
	}
}
