using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopUI : MonoBehaviour
{
    public static TopUI instance;
    public int coin
    { 
        get
        {
            return _coin;
        }
        private set 
        {
            _coin = value;
        }
    }

    [SerializeField] private TextMeshProUGUI _remaineEnemy;
    [SerializeField] private TextMeshProUGUI _remaineTime;
    [SerializeField] private TextMeshProUGUI _coinText;

    private int _coin = 0;

    private void Awake()
    {
        instance = this;
        _remaineEnemy.gameObject.SetActive(false);
        _remaineTime.gameObject.SetActive(false);
    }

    public int GetCoin(int getCoin)
    {
        coin += getCoin;
        return coin;
    }
    public void SetCoin()
    {
        _coinText.text = $"��ȭ : {_coin}";
    }
    public void SetEnemyCount(int enemy)
    {
        _remaineEnemy.text = $"���� �� : {enemy}";
        _remaineTime.gameObject.SetActive(false);
        _remaineEnemy.gameObject.SetActive(true);
    }
    public void SetRemainTime(int time)
    {
        _remaineTime.text = $"���� ���̺���� {time}��...";
        _remaineEnemy.gameObject.SetActive(false);
        _remaineTime.gameObject.SetActive(true);
    }
}
