using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerAutoChange : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -100);
        }
    }
}
