using UnityEngine;
using System.Collections;

public class test : MonoBehaviour
{
    public OptimalZone optimalZone;

    void Start()
    {
        optimalZone.onTowerDrop(gameObject);
    }
}
