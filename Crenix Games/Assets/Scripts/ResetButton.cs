using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private DragAndDrop[] triggerCheck;
    [SerializeField]
    private Gear[] engrenagens;

    private void Start()
    {
        engrenagens = GameObject.FindObjectsOfType<Gear>();
        triggerCheck = GameObject.FindObjectsOfType<DragAndDrop>();
    }

    public void ResetGears()
    {
        foreach (DragAndDrop item in triggerCheck)
        {
            item.isTriggered = false;
        }

        foreach (Gear engrenagem in engrenagens)
        {
            engrenagem.transform.position = engrenagem.initialPosition;
        }
    }

}
