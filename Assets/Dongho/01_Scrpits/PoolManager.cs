using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening.Core.Easing;

public interface IPool
{
    Transform parentTransform { get; set; } // 하이어라키 정리용
    Queue<GameObject> pool { get; set; } // 큐를 이용한 Pool

    GameObject Get(Action<GameObject> action = null); // pool로부터 오브젝트를 가져오는 함수
    void Return(GameObject obj, Action<GameObject> action = null); // pool로 오브젝트를 돌려보내는 함수
}
public class ObjectPool : IPool
{
    public Transform parentTransform { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject Get(Action<GameObject> action = null)
    {
        GameObject obj = pool.Dequeue();
        obj.SetActive(true);

        if (action != null)
        {
            action?.Invoke(obj);
        }
        return obj;
    }

    public void Return(GameObject obj, Action<GameObject> action = null)
    {
        pool.Enqueue(obj);
        obj.transform.SetParent(parentTransform);
        obj.SetActive(false);

        if (action != null)
        {
            action?.Invoke(obj);
        }
    }
}

public class PoolManager : MonoBehaviour
{
    // 풀들을 모아 관리하는 딕셔너리
    public Dictionary<string, IPool> poolDictionary = new Dictionary<string, IPool>();
    public static PoolManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    // path에 해당하는 풀을 반환하는 함수
    public IPool PoolingObj(string path)
    {
        if (poolDictionary.ContainsKey(path) == false)
        {
            AddPool(path);
        }

        if (poolDictionary[path].pool.Count <= 0) AddObj(path);

        return poolDictionary[path];
    }
    public IPool PoolingObj(string path, int number)
    {
        if (poolDictionary.ContainsKey(path) == false)
        {
            AddPool(path);
        }

        if (poolDictionary[path].pool.Count <= 0) AddObj(path, number);

        return poolDictionary[path];
    }
    // 새로운 풀을 생성하는 함수
    private void AddPool(string path)
    {
        GameObject obj = new GameObject(path + "Pool");
        obj.transform.SetParent(this.transform);
        ObjectPool objectPool = new ObjectPool();
        poolDictionary.Add(path, objectPool);

        objectPool.parentTransform = obj.transform;
    }
    // 오브젝트 생성한 후 풀로 들여보내는 함수
    private void AddObj(string path)
    {
        var go = Instantiate(Resources.Load<GameObject>("PoolObjects/" + path));
        poolDictionary[path].Return(go);
    }
    private void AddObj(string path, int number)
    {
        var item = Resources.LoadAll<GameObject>("PoolObjects/" + path);
        var go = Instantiate(item[number]);
        poolDictionary[path].Return(go);
    }
}

