using UnityEngine;
using System.Collections;

public class HeroStats : MonoBehaviour
{
    public float moveSpeed;
    public float health;

    public float baseMoveSpeed;
    public float baseHealth;

    void Start()
    {
        baseHealth = health;
        baseMoveSpeed = moveSpeed;
    }
}
