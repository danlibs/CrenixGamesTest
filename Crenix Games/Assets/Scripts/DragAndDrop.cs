using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    public bool isTriggered;

    private ResetButton resetButton;
    [SerializeField]
    private bool _isDragging;
    [SerializeField]
    private Vector2 _triggerPosition;

    private void Start()
    {
        resetButton = GameObject.FindObjectOfType<ResetButton>();
    }

    private void Update()
    {
        if (_isDragging)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
        else
        {
            if (isTriggered)
            {
                this.transform.position = _triggerPosition;
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
        if (collision.gameObject.CompareTag("GearPlace"))
        {
            isTriggered = true;
            _triggerPosition = collision.transform.position;
        }      
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GearPlace"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GearPlace"))
        {
            isTriggered = false;
        }
    }
}
