using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomID : MonoBehaviour
{
    public static string GetRandomId()
    {
        return "" + (int)(Random.Range(0.1f, 0.999f) * 1000000);
    }
}
