using UnityEngine;
using System.Collections;

public class PlayerResources : MonoBehaviour {
    public float crystal;
    public float ironOre;
    public float elixir;
    public float essence;

	public float mineRate;
	public float maxMineDist;

	public LayerMask resourceLayerMask;

	private GameObject currentMiningObj;
	private Resource currentMiningResource;
	private Resource.ResourceType currentResourceType;
	private bool isCurrentlyMining;

	void FixedUpdate()
	{
		Mining ();
	}

	void Mining()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) || Input.touchCount > 0)
		{

			Ray ray = new Ray();

			if (Input.GetKeyDown(KeyCode.Mouse0))
			{
				ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			}
			else if (Input.touchCount > 0)
			{
				ray = Camera.main.ScreenPointToRay (Input.GetTouch(0).position);
			}

			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100f, resourceLayerMask))
			{
				currentMiningObj = hit.collider.gameObject;
				currentMiningResource = currentMiningObj.GetComponent<Resource>();
				isCurrentlyMining = true;

				currentResourceType = currentMiningResource.GetResourceType ();
			}
			else
			{
				isCurrentlyMining = false;
			}
		}

		float mineDist = Mathf.Infinity;

		if (currentMiningObj != null)
		{
			mineDist = Vector3.Distance (transform.position, currentMiningObj.transform.position);
		}


		if (isCurrentlyMining && mineDist < maxMineDist)
		{
			float newResourceAmount = currentMiningResource.TakeResource (mineRate);

			if (currentResourceType == Resource.ResourceType.crystal)
			{
				crystal += newResourceAmount;
			}
			if (currentResourceType == Resource.ResourceType.elixir)
			{
				elixir += newResourceAmount;
			}
			if (currentResourceType == Resource.ResourceType.essence)
			{
				essence += newResourceAmount;
			}
			if (currentResourceType == Resource.ResourceType.ironOre)
			{
				ironOre += newResourceAmount;
			}
		}
	}
}
