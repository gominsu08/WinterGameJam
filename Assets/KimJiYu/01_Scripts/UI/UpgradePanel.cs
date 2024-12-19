using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanel : MonoBehaviour
{
    [SerializeField] private GameObject _upPanel;

    private void Start()
    {
        _upPanel.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUpgrade();
        }
    }

    public void OpenUpgrade()
    {
        _upPanel.SetActive(true);
    }

    public void CloseUpgrade()
    {
        _upPanel.SetActive(false);
    }
}
