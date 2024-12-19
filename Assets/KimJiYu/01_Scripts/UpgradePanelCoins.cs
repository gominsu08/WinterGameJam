using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradePanelCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _coinText;

    private void Update()
    {
        _coinText.text = $"{PlayerDataManager.Instance.Gold}";
    }
}
