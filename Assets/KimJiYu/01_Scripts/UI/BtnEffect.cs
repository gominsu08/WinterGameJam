using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using TMPro;


public class BtnEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _txtSize;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeText();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        DiscardText();
    }

    public void ChangeText()
    {
        _text.color = Color.red;
        _text.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f);
    }

    public void DiscardText()
    {
        _text.color = Color.white;
        _text.transform.DOScale(Vector3.one, 0.1f);
    }
}
