using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    public int time;
    void Start() => Destroy(gameObject, time);
}
