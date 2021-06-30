using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Plant : MonoBehaviour
{
    public int age = 0;
    private static int numberOfPlants = 0;
    [SerializeField] protected int spawnRate = 5;
    [SerializeField] protected int ageOfMaturity = 50;
    [SerializeField] protected Vector2 growthFactor;
    [SerializeField] protected Vector3 startingScale = new Vector3(1,1,1);

    protected virtual void Start()
    {
        numberOfPlants++;
        age = 0;
        
        InvokeRepeating(nameof(Grow), 0.1f, Random.Range(0.05f, 0.1f));
    }

    public virtual void Grow()
    {
        age++;
        if (age >= ageOfMaturity)
        {
            CancelInvoke();
        }
    }
}
