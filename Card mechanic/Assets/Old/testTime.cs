using UnityEngine;
using System.Collections;

public class testTime : MonoBehaviour
{
	public bool isTimerRunning;
	public float currTime = 0.0f;
	public float maxTime = 0.0f;

	public card_mechanic_UI cardMechUIScript;

	// Use this for initialization
	void Start ()
	{
		cardMechUIScript.GetComponent<card_mechanic_UI>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isTimerRunning)
		{
			DelayTimer();
		}
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isTimerRunning = true;
        }
	}

	void DelayTimer()
	{
		currTime += Time.deltaTime;
		if(currTime >= maxTime)
		{
			cardMechUIScript.useDim = true;
			currTime = 0f;
			isTimerRunning = false;
		}
	}

}
