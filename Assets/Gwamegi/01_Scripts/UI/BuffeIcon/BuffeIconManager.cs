using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffeIconManager : MonoSingleton<BuffeIconManager>
{
    [SerializeField] private Image _image;
    private Dictionary<string,Image> BuffeIconDictionary = new Dictionary<string,Image>();

    private void Awake()
    {
        _image.gameObject.SetActive(false);
    }

    public void AddBuffeIcon(string name, Sprite image)
    {
        Image icon = Instantiate(_image,transform);
        icon.sprite = image;
        icon.gameObject.SetActive(true);
        BuffeIconDictionary.Add(name, icon);
    }

    public void AddSecondsBuffeIcon(string name, Sprite image, int time)
    {
        Image icon = Instantiate(_image, transform);
        icon.sprite = image;
        icon.gameObject.SetActive(true);
        BuffeIconDictionary.Add(name, icon);
        StartCoroutine(DestroySecondsBuffeIcon(name,time));
    }

    private IEnumerator DestroySecondsBuffeIcon(string name, int time)
    {
        yield return new WaitForSeconds(time);
        DestroyBuffeIcon(name);
    }

    public void DestroyBuffeIcon(string name)
    {
        Destroy( BuffeIconDictionary[name]);
    }



}
