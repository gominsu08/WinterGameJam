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

    // 읽어 올 파일 이름
    public string csvFileName;

    // key:value 형태로 저장
    // key(메뉴명)로 value를 뽑아오기 위해
    // 원하는 형태로 선언해도 무방
    public Dictionary<int, Menu> dicMenu = new Dictionary<int, Menu>(); 

    // 읽어 온 데이터를 담을 구조체
    // 저는 클래스로 생성했습니다! struct로 생성해도 동일해요.
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

    // 파일을 읽어 오는 메서드
    private void ReadCSV()
    {
        // 파일 이름.확장자
        string path = "WaveCSV.csv";

        // 데이터를 저장하는 리스트
        // 편하게 관리하기 위해 List로 선언
        // 원하는 형태로 선언하시면 됩니다!
        List<Menu> menuList = new List<Menu>();

        // stream reader
        // UTF-8로 인코딩 하려면 해당 StreamReader가 필요함!!
        // Application.dataPath는 Unity의 Assets폴더의 절대경로
        // 뒤에 읽으려는 파일이 있는 경로를 작성
        // ex) Assets > Files에 menu.csv를 읽으려면? "/" + "Files/menu.csv"추가
        StreamReader reader = new StreamReader(Application.dataPath + "/" + path);

        // 마지막 줄을 판별하기 위한 bool 타입 변수
        bool isFinish = false;


        while (isFinish == false)
        {
            // ReadLine은 한줄씩 읽어서 string으로 반환하는 메서드
            // 한줄씩 읽어서 data변수에 담으면
            string data = reader.ReadLine(); // 한 줄 읽기

            // data 변수가 비었는지 확인
            if (data == null)
            {
                // 만약 비었다면? 마지막 줄 == 데이터 없음이니
                // isFinish를 true로 만들고 반복문 탈출
                isFinish = true;
                break;
            }

            // .csv는 ,(콤마)를 기준으로 데이터가 구분되어 있으므로
            // ,(콤마)를 기준으로 데이터를 나눠서 list에 담음
            // ex) 샌드위치,200원,맛있어요! => [샌드위치][200원][맛있어요!]
            var splitData = data.Split(','); // 콤마로 데이터 분할

            // 위에 새성했던 메뉴 객체를 선언해주고
            Menu menu = new Menu();

            // 메뉴를 리스트에 있던 데이터로 초기화
            // menu.name에 splitData[0]번째 있는 데이터를 담는다는 의미
            // 즉, menu 객체 name변수에는 splitData[0]에 담긴 "샌드위치"가 들어갑니다.
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


            // menu 객체에 다 담았다면 dictionary에 key와 value값으로 저장
            // 이렇게 해두면 dicMenu.Add("샌드위치");로 menu.name, menu.price .. 접근 가능
            dicMenu.Add(menu.waveCount, menu);
        }
    }
}
