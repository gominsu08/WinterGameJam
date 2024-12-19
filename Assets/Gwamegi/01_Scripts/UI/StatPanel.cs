using System;
using TMPro;
using UnityEngine;

public enum JustSwordStatEnum
{
    Atk,
    Speed,
    Range,
    Size,
    PickDelay
}

public class StatPanel : MonoBehaviour
{
    public JustSwordStatEnum JustSwordStatEnum;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _goldText;
    private int buyGold = 10;

    private void Start()
    {
        string var = "";

        switch (JustSwordStatEnum)
        {
            case JustSwordStatEnum.Atk:
                _goldText.SetText($"{JustSwordDataManager.Instance.atkBuyGold}G");
                var = $"<#=ff11f>{JustSwordDataManager.Instance.GetAtk()}</color> -> <color=green>{JustSwordDataManager.Instance.GetAtk() + 1}</color>";
                break;
            case JustSwordStatEnum.Speed:
                _goldText.SetText($"{JustSwordDataManager.Instance.speedBuyGold}G");
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetSpeed(), 1)}</color> -> <color=green>{Math.Round(JustSwordDataManager.Instance.GetSpeed() + 0.1f, 1)}</color>";
                break;
            case JustSwordStatEnum.Range:
                _goldText.SetText($"{JustSwordDataManager.Instance.rangeBuyGold}G");
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetRange(), 1)}</color> -> <color=green>{Math.Round(JustSwordDataManager.Instance.GetRange() + 0.1f, 1)}</color>";
                break;
            case JustSwordStatEnum.Size:
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetSize(), 2)}</color> -> <color=green>{Math.Round((JustSwordDataManager.Instance.GetSize() + 0.08f), 2)}</color>";
                break;
        }

        _text.SetText(var);
    }

    public void BtnClick()
    {
        string var = "";

        switch (JustSwordStatEnum)
        {
            case JustSwordStatEnum.Atk:
                if (PlayerDataManager.Instance.IsCanDiscountGold(JustSwordDataManager.Instance.atkBuyGold))
                {
                    PlayerDataManager.Instance.DiscountGold(JustSwordDataManager.Instance.atkBuyGold);
                    JustSwordDataManager.Instance.atkBuyGold = (int)(JustSwordDataManager.Instance.atkBuyGold * 1.1f);
                    _goldText.SetText($"{JustSwordDataManager.Instance.atkBuyGold}G");
                    JustSwordDataManager.Instance.SetAtk(1);
                }
                var = $"<#=ff11f>{JustSwordDataManager.Instance.GetAtk()}</color> -> <color=green>{JustSwordDataManager.Instance.GetAtk() + 1}</color>";
                break;
            case JustSwordStatEnum.Speed:
                if (PlayerDataManager.Instance.IsCanDiscountGold(JustSwordDataManager.Instance.speedBuyGold))
                {
                    PlayerDataManager.Instance.DiscountGold(JustSwordDataManager.Instance.speedBuyGold);
                    JustSwordDataManager.Instance.speedBuyGold = (int)(JustSwordDataManager.Instance.speedBuyGold * 1.1f);
                    _goldText.SetText($"{JustSwordDataManager.Instance.speedBuyGold}G");
                    JustSwordDataManager.Instance.SetSpeed(0.1f);
                }
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetSpeed(), 1)}</color> -> <color=green>{Math.Round(JustSwordDataManager.Instance.GetSpeed() + 0.1f, 1)}</color>";
                break;
            case JustSwordStatEnum.Range:
                if (PlayerDataManager.Instance.IsCanDiscountGold(JustSwordDataManager.Instance.rangeBuyGold))
                {
                    PlayerDataManager.Instance.DiscountGold(JustSwordDataManager.Instance.rangeBuyGold);
                    JustSwordDataManager.Instance.rangeBuyGold = (int)(JustSwordDataManager.Instance.rangeBuyGold * 1.1f);
                    _goldText.SetText($"{JustSwordDataManager.Instance.rangeBuyGold}G");
                    JustSwordDataManager.Instance.SetRange(0.1f);
                }
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetRange(), 1)}</color> -> <color=green>{Math.Round(JustSwordDataManager.Instance.GetRange() + 0.1f, 1)}</color>";
                break;
        }

        _text.SetText(var);
    }
}
