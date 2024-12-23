using DG.Tweening.Plugins.Core.PathCore;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;



public class DataSave : MonoBehaviour
{
    private string path;

    [ContextMenu("FileReset")]
    public void FileReset()
    {
        File.Delete(System.IO.Path.Combine(Application.dataPath, "database.json"));


    }
    private void Awake()
    {
        JsonLoad();
        path = System.IO.Path.Combine(Application.dataPath, "database.json");
    }

    public void JsonLoad()
    {
        SaveData saveData = new SaveData();

        try
        {
            string loadJson = File.ReadAllText(path);
            saveData = JsonUtility.FromJson<SaveData>(loadJson);



            PlayerDataManager.Instance.Gold = saveData.gold;

            JustSwordDataManager.Instance._atk = saveData._atk;
            JustSwordDataManager.Instance._speed = saveData._speed;
            JustSwordDataManager.Instance._range = saveData._range;

            JustSwordDataManager.Instance.atkBuyGold = saveData.atkBuyGold;
            JustSwordDataManager.Instance.speedBuyGold = saveData.speedBuyGold;
            JustSwordDataManager.Instance.rangeBuyGold = saveData.rangeBuyGold;


        }
        catch
        {
            File.CreateText(path);
        }
    }

    private void OnDestroy()
    {
        JsonSave();
    }

    public void JsonSave()
    {
        SaveData saveData = new SaveData();

        saveData.gold = PlayerDataManager.Instance.Gold;

        saveData._atk = JustSwordDataManager.Instance._atk;
        saveData._speed = JustSwordDataManager.Instance._speed;
        saveData._range = JustSwordDataManager.Instance._range;

        saveData.atkBuyGold = JustSwordDataManager.Instance.atkBuyGold;
        saveData.speedBuyGold = JustSwordDataManager.Instance.speedBuyGold;
        saveData.rangeBuyGold = JustSwordDataManager.Instance.rangeBuyGold;


        string json = JsonUtility.ToJson(saveData, true);

        File.WriteAllText(path, json);
    }

    private void OnApplicationQuit()
    {
        JsonSave();
    }
}
