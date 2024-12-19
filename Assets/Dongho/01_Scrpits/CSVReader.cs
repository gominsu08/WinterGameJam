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

    // �о� �� ���� �̸�
    public string csvFileName;

    // key:value ���·� ����
    // key(�޴���)�� value�� �̾ƿ��� ����
    // ���ϴ� ���·� �����ص� ����
    public Dictionary<int, Menu> dicMenu = new Dictionary<int, Menu>(); 

    // �о� �� �����͸� ���� ����ü
    // ���� Ŭ������ �����߽��ϴ�! struct�� �����ص� �����ؿ�.
    [System.Serializable]
    public class Menu
    {
        public int waveCount;
        public string[] monsters;
        public string[] monsterNumber;
    }

    private void Start()
    {
        ReadCSV();
    }

    // ������ �о� ���� �޼���
    private void ReadCSV()
    {
        // ���� �̸�.Ȯ����
        string path = "WaveCSV.csv";

        // �����͸� �����ϴ� ����Ʈ
        // ���ϰ� �����ϱ� ���� List�� ����
        // ���ϴ� ���·� �����Ͻø� �˴ϴ�!
        List<Menu> menuList = new List<Menu>();

        // stream reader
        // UTF-8�� ���ڵ� �Ϸ��� �ش� StreamReader�� �ʿ���!!
        // Application.dataPath�� Unity�� Assets������ ������
        // �ڿ� �������� ������ �ִ� ��θ� �ۼ�
        // ex) Assets > Files�� menu.csv�� ��������? "/" + "Files/menu.csv"�߰�
        StreamReader reader = new StreamReader(Application.dataPath + "/" + path);

        // ������ ���� �Ǻ��ϱ� ���� bool Ÿ�� ����
        bool isFinish = false;


        while (isFinish == false)
        {
            // ReadLine�� ���پ� �о string���� ��ȯ�ϴ� �޼���
            // ���پ� �о data������ ������
            string data = reader.ReadLine(); // �� �� �б�

            // data ������ ������� Ȯ��
            if (data == null)
            {
                // ���� ����ٸ�? ������ �� == ������ �����̴�
                // isFinish�� true�� ����� �ݺ��� Ż��
                isFinish = true;
                break;
            }

            // .csv�� ,(�޸�)�� �������� �����Ͱ� ���еǾ� �����Ƿ�
            // ,(�޸�)�� �������� �����͸� ������ list�� ����
            // ex) ������ġ,200��,���־��! => [������ġ][200��][���־��!]
            var splitData = data.Split(','); // �޸��� ������ ����

            // ���� �����ߴ� �޴� ��ü�� �������ְ�
            Menu menu = new Menu();

            // �޴��� ����Ʈ�� �ִ� �����ͷ� �ʱ�ȭ
            // menu.name�� splitData[0]��° �ִ� �����͸� ��´ٴ� �ǹ�
            // ��, menu ��ü name�������� splitData[0]�� ��� "������ġ"�� ���ϴ�.
            menu.waveCount = int.Parse(splitData[0]);

            for (int i = 0; i < splitData.Length; i++)
            {
                if (splitData[i] == "and")
                {
                    int monsterCount = i - 1;
                    int numberCount = splitData.Length - (i + 1);

                    menu.monsters = new string[monsterCount];
                    menu.monsterNumber = new string[numberCount];

                    for (int j = 1; j <= monsterCount; j++)
                    {
                        menu.monsters[j - 1] = splitData[j];
                    }

                    for (int j = i + 1, k = 0; j < splitData.Length; j++, k++)
                    {
                        menu.monsterNumber[k] = splitData[j];
                    }
                    break;
                }
            }


            // menu ��ü�� �� ��Ҵٸ� dictionary�� key�� value������ ����
            // �̷��� �صθ� dicMenu.Add("������ġ");�� menu.name, menu.price .. ���� ����
            dicMenu.Add(menu.waveCount, menu);
        }
    }
}
