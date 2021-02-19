using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField]
    private Gear[] engrenagens;

    private void Start()
    {
        engrenagens = GameObject.FindObjectsOfType<Gear>();
    }

    public void ResetGears()
    {
        foreach (Gear engrenagem in engrenagens)
        {
            engrenagem.transform.position = engrenagem.initialPosition;
        }
    }

}
