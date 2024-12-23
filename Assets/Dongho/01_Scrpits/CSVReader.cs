using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public static CSVReader instance = null;

    private void Awake()
    {
        instance = this;
    }

    public string csvFileName = "WaveCSV.csv";

    public Dictionary<int, Menu> dicMenu = new Dictionary<int, Menu>();

    [System.Serializable]
    public class Menu
    {
        public int waveCount;
        public string[] monsters;
        public string[] monsterNumber;
    }

    private void Start()
    {
        ReadCSV2();
    }

    private void ReadCSV2()
    {
        TextAsset csvFile = Resources.Load<TextAsset>(csvFileName);
        if (csvFile != null)
        {
            string[] lines = csvFile.text.Split('\n');
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                if (fields[0] == string.Empty)
                    break;

                Menu menu = new Menu();

                menu.waveCount = int.Parse(fields[0]);
                for (int i = 0; i < fields.Length; i++)
                {
                    if (fields[i] == "and")
                    {
                        int monsterCount = i - 1;
                        int numberCount = fields.Length - (i + 1);

                        menu.monsters = new string[monsterCount];
                        menu.monsterNumber = new string[numberCount];

                        for (int j = 1; j <= monsterCount; j++)
                        {
                            menu.monsters[j - 1] = fields[j];
                        }

                        for (int j = i + 1, k = 0; j < fields.Length; j++, k++)
                        {
                            menu.monsterNumber[k] = fields[j];
                        }
                        break;
                    }
                }

                dicMenu.Add(menu.waveCount, menu);
            }
        }
        else
        {
            Debug.LogError("CSV 파일을 찾을 수 없습니다.");
        }
    }
}
