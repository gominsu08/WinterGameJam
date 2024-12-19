using System.IO;
using UnityEngine;



public class JustSwordDataManager : MonoSingleton<JustSwordDataManager>
{
    private string path;

    private bool isStart;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath, "database.json");

        var obj = FindObjectsOfType<JustSwordDataManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int _atk = 15;
    public float _speed = 20f;
    public float _range = 7f;
    public float _size = 1f;
    public float _pickDelay = 0.5f;

    public int atkBuyGold = 10;
    public int speedBuyGold = 10;
    public int rangeBuyGold = 10;
    public int pickBuyGold = 10;


    

    private void Update()
    {
        Debug.Log(PlayerDataManager.Instance.Gold);
    }


    public int GetAtk() => _atk;
    public float GetSpeed() => _speed;
    public float GetRange() => _range;
    public float GetPickDelay() => _pickDelay;
    public float GetSize() => _size;

    public void SetAtk(int count)
    {
        _atk += count;
    }

    public void SetSpeed(float count)
    {
        _speed += count;
    }
    public void SetRange(float count)
    {
        _range += count;
    }

    public void SetPickDelay(float count)
    {
        _size += count;
    }

    public void SetSize(float count)
    {
        _size += count;
    }

}
