using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private GameObject _line;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = _line.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float distance = (mousePos - (Vector2)transform.position).magnitude;
        Vector3 direction = mousePos - (Vector2)transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        _renderer.size = new Vector3(2f, distance * 2, 0);

    }
}
