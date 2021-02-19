using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPlace : MonoBehaviour
{
    public bool hasGear;

    private CircleCollider2D collider;
    private DragAndDrop _triggerCheck;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (hasGear)
        {
            collider.isTrigger = false;
        }
        else
        {
            collider.isTrigger = true;
        }
    }


}
