using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isTriggered;

    [SerializeField]
    private bool _isDragging;
    [SerializeField]
    private Vector2 _triggerPosition;
    [SerializeField]
    private GearPlace _gearPlace;

    private void Update()
    {
        if (_isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
            if (_gearPlace != null)
            {
                _gearPlace.hasGear = false;
            }
        }
        else
        {
            if (isTriggered)
            {
                transform.position = _triggerPosition;
                _gearPlace.hasGear = true;
            }
        }

    }

    private void OnMouseDown()
    {
        _isDragging = true;
    }

    private void OnMouseUp()
    {
        _isDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _gearPlace = collision.GetComponent<GearPlace>();
        if (collision.gameObject.CompareTag("GearPlace") && !_gearPlace.hasGear)
        {
            isTriggered = true;
            _triggerPosition = collision.transform.position;
        }      
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        _gearPlace = collision.GetComponent<GearPlace>();
        if (collision.gameObject.CompareTag("GearPlace"))
        {
            isTriggered = true;
            _triggerPosition = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _gearPlace = collision.GetComponent<GearPlace>();
        if (collision.gameObject.CompareTag("GearPlace"))
        {
            isTriggered = false;
        }
    }
}
