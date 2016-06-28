using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	public LayerMask moveSurfaceLayermask;
	public float moveSpeed;
	public AnimationCurve smoothing;
	public NavMeshAgent navMeshAgent;

	private bool isMoving;
	private Vector3 currentDestination;
	private float distance;
	private Collider playerCollider;

	void Start()
	{
		playerCollider = GetComponent<Collider> ();
	}

	// Update is called once per frame
	void Update () 
	{
		MovePlayer ();
	}

	void MovePlayer()
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

			if (Physics.Raycast(ray, out hit, 100f, moveSurfaceLayermask))
			{
				isMoving = true;
				currentDestination = hit.point;
				currentDestination = new Vector3 (currentDestination.x, currentDestination.y + (playerCollider.bounds.extents.y/2), currentDestination.z);

				distance = Vector3.Distance (transform.position, currentDestination);
			}
			else
			{
				isMoving = false;
			}

		}


		if (isMoving)
		{
			//transform.position = Vector3.MoveTowards (transform.position, currentDestination, moveSpeed * smoothing.Evaluate(1 - (Vector3.Distance (transform.position, currentDestination)/distance)));
		
			navMeshAgent.destination = currentDestination;

			navMeshAgent.speed = moveSpeed * smoothing.Evaluate (1 - (Vector3.Distance (transform.position, currentDestination) / distance));
		}
	}
}
