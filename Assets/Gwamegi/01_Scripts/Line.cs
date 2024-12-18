using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private Transform playerTrm;
    [SerializeField] private GameObject _line;
    [SerializeField] private Transform _positionObject;
    private GetWeapon _getWeapon;
    private SpriteRenderer _renderer;


    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        transform.position = new Vector3(playerTrm.position.x, playerTrm.position.y - 0.3f, 0);
        transform.localScale = new Vector3(transform.localScale.x, 1, 0);
        gameObject.SetActive(true);
    }


    private void Awake()
    {
        _getWeapon = GameObject.Find("CheckWeapon").GetComponent<GetWeapon>();
    }

    private void Start()
    {
        _renderer = _line.GetComponent<SpriteRenderer>();
        
    }


    private void Update()
    {
        transform.position = new Vector3(playerTrm.position.x, playerTrm.position.y - 0.3f, 0);

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float distance = (mousePos - (Vector2)transform.position).magnitude;
        Vector3 direction = mousePos - (Vector2)transform.position;

        LineYScail(distance, direction, _getWeapon._swordDataSO.intersection > distance);

    }

    private void LineYScail(float distance, Vector2 direction, bool isCanScailUp)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (isCanScailUp)
        {
            _renderer.size = new Vector3(2f, distance, 0);
            _positionObject.localPosition = new Vector3(0,distance,0);
        }

    }
}
