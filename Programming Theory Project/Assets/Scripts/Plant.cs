using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public int age = 0;
    
    
    public virtual void Grow()
    {
        age++;
        Vector3 scaleChange = gameObject.transform.localScale / age;
        scaleChange.x /= age;
        scaleChange.z /= age;
        gameObject.transform.localScale += scaleChange;
    }
}
