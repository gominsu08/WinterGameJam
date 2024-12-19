using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TopUI : MonoBehaviour
{
    public static TopUI instance;
    public event Action OnNextWave;

    [SerializeField] private TextMeshProUGUI _remaineEnemy;
    [SerializeField] private TextMeshProUGUI _remaineTime;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _waveText;

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

    public int PlusCoin(int getCoin)
    {
        _coin += getCoin;
        SetCoin(_coin);
        return _coin;
    }
    public void SetCoin(int getCoin)
    {
        PlayerDataManager.Instance.AddGold(getCoin);
        _coinText.text = $"행복도 : {getCoin}";
    }
    public void SetEnemyCount(int enemy)
    {
        if (WaveManager.Instance.enemyCount == 0)
            SetRemainTime(3);
        _remaineEnemy.text = $"남은 적 : {enemy}";
        _remaineTime.gameObject.SetActive(false);
        _remaineEnemy.gameObject.SetActive(true);
    }
    private void SetRemainTime(int time)
    {
        StartCoroutine(NextWaveTimerCoroutine(time));
    }
    private IEnumerator NextWaveTimerCoroutine(int time)
    {
        _remaineEnemy.gameObject.SetActive(false);
        _remaineTime.gameObject.SetActive(true);
        _remaineTime.text = $"다음 웨이브까지 {time--}초...";
        yield return new WaitForSeconds(1f);
        if (time <= 0)
        {
            OnNextWave?.Invoke();
            StopCoroutine("NextWaveTimerCoroutine");
        }
        else
            StartCoroutine(NextWaveTimerCoroutine(time));
    }
    public void SetWaveText(int wave)
    {
        _waveText.text = $"웨이브 : {wave}";
    }
}
