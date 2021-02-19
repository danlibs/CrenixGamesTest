using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    private DragAndDrop[] triggerCheck;
    [SerializeField]
    private Gear[] engrenagens;
    private GearPlace[] locaisEngrenagens;

    private void Start()
    {
        engrenagens = GameObject.FindObjectsOfType<Gear>();
        triggerCheck = GameObject.FindObjectsOfType<DragAndDrop>();
        locaisEngrenagens = GameObject.FindObjectsOfType<GearPlace>();
    }

    public void ResetGears()
    {
        foreach (GearPlace item in locaisEngrenagens)
        {
            item.hasGear = false;
        }

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
