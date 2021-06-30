using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trunk : Plant
{
    private static int numberOfTrees = 0;
    

    protected override void Start()
    {
        numberOfTrees++;
        transform.localScale = startingScale;
        base.Start();
    }

    public override void Grow()
    {
        base.Grow();
        
        
    }
}