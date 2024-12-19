using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopUI : MonoBehaviour
{
    public static TopUI instance;
    public event Action OnNextWave;
    public event Action<int> OnChangeEnemyCount;
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
    public int enemyCount
    {
        get
        {
            return _enemyCount;
        }
        private set
        {
            _enemyCount = value;
        }
    }

    [SerializeField] private TextMeshProUGUI _remaineEnemy;
    [SerializeField] private TextMeshProUGUI _remaineTime;
    [SerializeField] private TextMeshProUGUI _coinText;

    private int _coin = 0;
    private int _enemyCount = 0;

    private void Awake()
    {
        instance = this;
        _remaineEnemy.gameObject.SetActive(false);
        _remaineTime.gameObject.SetActive(false);
    }
    private void Start()
    {
        SetRemainTime(3);
    }

    public int GetCoin(int getCoin)
    {
        coin += getCoin;
        return coin;
    }
    public void SetCoin()
    {
        _coinText.text = $"재화 : {_coin}";
    }
    public void SetEnemyCount(int enemy)
    {
        if (enemy == 0)
            SetRemainTime(3);
        OnChangeEnemyCount?.Invoke(enemy);
        _enemyCount = enemy;
        _remaineEnemy.text = $"남은 적 : {enemy}";
        _remaineTime.gameObject.SetActive(false);
        _remaineEnemy.gameObject.SetActive(true);
    }
    private void SetRemainTime(int time)
    {
        _remaineEnemy.gameObject.SetActive(false);
        _remaineTime.gameObject.SetActive(true);
        StartCoroutine(NextWaveTimerCoroutine(time));
    }
    private IEnumerator NextWaveTimerCoroutine(int time)
    {
        Debug.Log(time);
        _remaineTime.text = $"다음 웨이브까지 {time--}초...";
        yield return new WaitForSeconds(1f);
        if (time < 0)
        {
            Debug.Log("OnNextWave");
            OnNextWave?.Invoke();
            StopCoroutine("NextWaveTimerCoroutine");
        }
        else
            StartCoroutine(NextWaveTimerCoroutine(time));
    }
}
