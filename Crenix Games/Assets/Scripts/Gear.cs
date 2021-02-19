using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public Vector2 initialPosition;

    private void Awake()
    {
        initialPosition = this.transform.position;
    }

}
