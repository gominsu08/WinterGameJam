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

    public void BtnClick()
    {
        string var = "";

        switch (JustSwordStatEnum)
        {
            case JustSwordStatEnum.Atk:
                if (PlayerDataManager.Instance.IsCanDiscountGold(buyGold))
                {
                    PlayerDataManager.Instance.DiscountGold(buyGold);
                    buyGold = (int)(buyGold * 1.1f);
                    _goldText.SetText($"{buyGold}G");
                    JustSwordDataManager.Instance.SetAtk(1);
                }
                var = $"<#=ff11f>{JustSwordDataManager.Instance.GetAtk()}</color> -> <color=green>{JustSwordDataManager.Instance.GetAtk() + 1}</color>";
                break;
            case JustSwordStatEnum.Speed:
                if (PlayerDataManager.Instance.IsCanDiscountGold(buyGold))
                {
                    PlayerDataManager.Instance.DiscountGold(buyGold);
                    buyGold = (int)(buyGold * 1.1f);
                    _goldText.SetText($"{buyGold}G");
                    JustSwordDataManager.Instance.SetSpeed(0.1f);
                }
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetSpeed(), 1)}</color> -> <color=green>{Math.Round(JustSwordDataManager.Instance.GetSpeed() + 0.1f, 1)}</color>";
                break;
            case JustSwordStatEnum.Range:
                if (PlayerDataManager.Instance.IsCanDiscountGold(buyGold))
                {
                    PlayerDataManager.Instance.DiscountGold(buyGold);
                    buyGold = (int)(buyGold * 1.1f);
                    _goldText.SetText($"{buyGold}G");
                    JustSwordDataManager.Instance.SetRange(0.1f);
                }
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetRange(), 1)}</color> -> <color=green>{Math.Round(JustSwordDataManager.Instance.GetRange() + 0.1f, 1)}</color>";
                break;
            case JustSwordStatEnum.Size:
                if (PlayerDataManager.Instance.IsCanDiscountGold(buyGold))
                {
                    PlayerDataManager.Instance.DiscountGold(buyGold);
                    buyGold = (int)(buyGold * 1.1f);
                    _goldText.SetText($"{buyGold}G");
                    JustSwordDataManager.Instance.SetSize(0.08f);
                }
                var = $"<#=ff11f>{Math.Round(JustSwordDataManager.Instance.GetSize(), 2)}</color> -> <color=green>{Math.Round((JustSwordDataManager.Instance.GetSize() + 0.08f), 2)}</color>";
                break;
        }

        _text.SetText(var);
    }
}
