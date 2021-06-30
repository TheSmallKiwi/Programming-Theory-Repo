using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Grass : Plant
{
    public GameObject grassPrefab;
    [SerializeField] private bool tooCrowded = false;
    [SerializeField] [Range(0.001f, 0.2f)] private float densityTolerance = 0.1f;
    [SerializeField] [Range(0.1f, 2f)] private float seedCastRadius = 0.5f;
    private static int numberOfGrass = 0;

    protected override void Start()
    {
        numberOfGrass++;
        transform.localScale = startingScale;
        base.Start();
    }

    public override void Grow()
    {
        base.Grow();

       
        float invSquare = Math.Min(1f / (age * age), .1f);
        Vector3 scale = new Vector3(invSquare * growthFactor.x, invSquare * growthFactor.y, invSquare * growthFactor.x);
        transform.localScale += scale;

        if (age % spawnRate == spawnRate - 1 && age < ageOfMaturity) // Create clone every 4th growth
        {
            Vector3 spawnPos = EmptySpace();
            if (!tooCrowded)
            {
                
                Instantiate(grassPrefab, spawnPos, Quaternion.identity);
                Debug.Log("Number of Grass: " + numberOfGrass);
            }
        }
    }

    private Vector3 EmptySpace()
    {
        Vector3 targetPos = Random.insideUnitCircle * seedCastRadius;
        targetPos.z = targetPos.y;
        targetPos.y = 0;
        targetPos += gameObject.transform.position;

        for (int i = 0; i < 10; i++)
        {
            if (!Physics.CheckSphere(targetPos, densityTolerance))
            {
                break;
            }

            targetPos = RotatePointAroundPivot(targetPos, transform.position, new Vector3(0, .99f, 0));

            if (numberOfGrass == 1)
            {
                targetPos = Random.insideUnitCircle;
                targetPos.z = targetPos.y;
                targetPos.y = 0;
                targetPos += gameObject.transform.position;
            }

            if (i == 9)
            {
                tooCrowded = true;
                CancelInvoke();
            }
        }

        return targetPos;
    }

    public Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        return Quaternion.Euler(angles) * (point - pivot) + pivot;
    }
}