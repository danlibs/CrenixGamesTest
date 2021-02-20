using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Gerenciador da animação e mudança de fala do Nugget:
public class Manager : MonoBehaviour
{
    [SerializeField]
    private bool _areAllGearsInPlace; // Preenchimento de todos os locais de engrenagem.
    [SerializeField]
    private GearPlace[] _gearPlaces;
    [SerializeField]
    private GameObject[] _gears;
    [SerializeField]
    private TMPro.TextMeshProUGUI _textNugget; // Fala do Nugget.

    private void Start()
    {
        _gears = GameObject.FindGameObjectsWithTag("Gear");
    }

    private void Update()
    {
        VerifyGears();
        AnimateGears();
    }

    private void VerifyGears() // Verifica se todos os locais de engrenagem possuem alguma engrenagem.
    {
        if (_gearPlaces[0].hasGear && 
            _gearPlaces[1].hasGear &&
            _gearPlaces[2].hasGear &&
            _gearPlaces[3].hasGear &&
            _gearPlaces[4].hasGear)
        {
            _areAllGearsInPlace = true;
            _textNugget.text = "YAY, PARABÉNS, TASK CONCLUÍDA!";
        }
        else
        {
            _areAllGearsInPlace = false;
            _textNugget.text = "ENCAIXE AS ENGRENAGENS EM QUALQUER ORDEM.";
        }
    }

    private void AnimateGears() // Inicia e interrompe a animação das engrenagens com base na variável _areAllGearsInPlace:
    {
        if (_areAllGearsInPlace)
        {
            for (int i = 0; i < _gearPlaces.Length; i++) // Verifica onde cada engrenagem foi colocada para, então, determinar qual animação será tocada. Os elementos da lista _gearPlaces foram definidos diretamente no editor, o que tornou mais simples a verificação aqui de quais engrenagens fariam a animação girando em sentido horário ("AnimClockwise") ou em sentido anti-horário ("AnimAnticlockwise"). 
            {
                if ((_gears[i].GetComponent<RectTransform>().anchoredPosition == _gearPlaces[0].GetComponent<RectTransform>().anchoredPosition) ||
                    (_gears[i].GetComponent<RectTransform>().anchoredPosition == _gearPlaces[2].GetComponent<RectTransform>().anchoredPosition) ||
                    (_gears[i].GetComponent<RectTransform>().anchoredPosition == _gearPlaces[4].GetComponent<RectTransform>().anchoredPosition))
                {
                    _gears[i].GetComponent<Animation>().Play("AnimClockwise");
                }
                
                if ((_gears[i].GetComponent<RectTransform>().anchoredPosition == _gearPlaces[1].GetComponent<RectTransform>().anchoredPosition) ||
                   (_gears[i].GetComponent<RectTransform>().anchoredPosition == _gearPlaces[3].GetComponent<RectTransform>().anchoredPosition))
                {
                    _gears[i].GetComponent<Animation>().Play("AnimAnticlockwise");
                }
            }
        }
        else
        {
            for (int i = 0; i < _gearPlaces.Length; i++)
            {
                _gears[i].GetComponent<Animation>().Stop();
            }
        }
    }
}
