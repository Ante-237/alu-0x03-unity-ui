using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSpin : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed = 100f;
    void Update()
    { 
        transform.Rotate(Direction  * Speed * Time.deltaTime);
    }
}
