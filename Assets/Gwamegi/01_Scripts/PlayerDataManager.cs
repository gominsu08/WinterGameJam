using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : MonoSingleton<PlayerDataManager>
{
    private void Awake()
    {
        

        var obj = FindObjectsOfType<PlayerDataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public int Gold { get; private set; }

    public bool IsCanDiscountGold(int count) => Gold - count > 0;

    public void DiscountGold(int count) => Gold -= count;
    public void AddGold(int count) => Gold = count;


}
