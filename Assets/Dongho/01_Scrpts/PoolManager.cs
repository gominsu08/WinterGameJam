using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening.Core.Easing;

public interface IPool
{
    Transform parentTransform { get; set; } // ���̾��Ű ������
    Queue<GameObject> pool { get; set; } // ť�� �̿��� Pool

    GameObject Get(Action<GameObject> action = null); // pool�κ��� ������Ʈ�� �������� �Լ�
    void Return(GameObject obj, Action<GameObject> action = null); // pool�� ������Ʈ�� ���������� �Լ�
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
    // Ǯ���� ��� �����ϴ� ��ųʸ�
    public Dictionary<string, IPool> poolDictionary = new Dictionary<string, IPool>();
    public static PoolManager instance = null;

    private void Awake()
    {
        instance = this;
    }

    // path�� �ش��ϴ� Ǯ�� ��ȯ�ϴ� �Լ�
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
    // ���ο� Ǯ�� �����ϴ� �Լ�
    private void AddPool(string path)
    {
        GameObject obj = new GameObject(path + "Pool");
        obj.transform.SetParent(this.transform);
        ObjectPool objectPool = new ObjectPool();
        poolDictionary.Add(path, objectPool);

        objectPool.parentTransform = obj.transform;
    }
    // ������Ʈ ������ �� Ǯ�� �鿩������ �Լ�
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

