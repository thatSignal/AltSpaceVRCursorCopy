using UnityEngine;
using System.Collections;

public class MathTools
{
    public static float Dist3(Vector3 pos1, Vector3 pos2)
    {
        return Mathf.Sqrt(Mathf.Pow((pos2.x - pos1.x), 2) + Mathf.Pow((pos2.y - pos1.y), 2) + Mathf.Pow((pos2.z - pos1.z), 2) );
    }
}