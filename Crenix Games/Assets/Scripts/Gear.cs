using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public Vector2 initialPosition;

    private DragAndDrop triggerCheck;

    private void Awake()
    {
        initialPosition = this.transform.position;
        triggerCheck = this.GetComponent<DragAndDrop>();
    }
}
