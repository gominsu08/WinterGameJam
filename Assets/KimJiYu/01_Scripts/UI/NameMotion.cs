using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameMotion : MonoBehaviour
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        NameMove();
    }

    private void NameMove()
    {
        _rect.DOMoveY(_rect.position.y - 15f, 1f).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }
}
