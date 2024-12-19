using System.IO;
using UnityEngine;


[System.Serializable]
public class SaveData
{
    public int _atk;
    public float _speed;
    public float _range;

    public int atkBuyGold;
    public int speedBuyGold;
    public int rangeBuyGold;

    public int gold;
}
public class JustSwordDataManager : MonoSingleton<JustSwordDataManager>
{
    private string path;

    private void Awake()
    {
        path = Path.Combine(Application.dataPath, "database.json");
        JsonLoad();

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

    private int _atk = 15;
    private float _speed = 20f;
    private float _range = 7f;
    private float _size = 1f;
    private float _pickDelay = 0.5f;

    public int atkBuyGold = 10;
    public int speedBuyGold = 10;
    public int rangeBuyGold = 10;
    public int pickBuyGold = 10;


    [ContextMenu("FileReset")]
    public void FileReset()
    {
        File.Delete(Path.Combine(Application.dataPath, "database.json"));


    }
    void Start()
    {
        
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        try
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);



            PlayerDataManager.Instance.Gold = saveData.gold;
            _atk = saveData._atk;
            _speed = saveData._speed;
            _range = saveData._range;

            atkBuyGold = saveData.atkBuyGold;
            speedBuyGold = saveData.speedBuyGold;
            rangeBuyGold = saveData.rangeBuyGold;


        }
        catch
        {
            File.CreateText(path);
        }
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.gold = PlayerDataManager.Instance.Gold;

        saveData._atk = _atk;
        saveData._speed = _speed;
        saveData._range = _range;

        saveData.atkBuyGold = atkBuyGold;
        saveData.speedBuyGold = speedBuyGold;
        saveData.rangeBuyGold = rangeBuyGold;


        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    private void OnApplicationQuit()
    {
        JsonSave();
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
