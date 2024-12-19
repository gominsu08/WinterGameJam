using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Sword/SwordObjectListSO")]
public class SwordObjectListSO : ScriptableObject
{
    public List<Sword> swords = new List<Sword>();
    public List<Sword> tier_S_Sword = new List<Sword>();
    public List<Sword> tier_A_Sword = new List<Sword>();
    public List<Sword> tier_B_Sword = new List<Sword>();
    public List<Sword> tier_C_Sword = new List<Sword>();
    public List<Sword> tier_D_Sword = new List<Sword>();

    private void OnValidate()
    {
        if (swords == null) return;
        tier_S_Sword.Clear();
        tier_A_Sword.Clear();
        tier_B_Sword.Clear();
        tier_C_Sword.Clear();
        tier_D_Sword.Clear();

        foreach (Sword item in swords)
        {
            if (item == null) return;
            SwordDataContains swordDataContains = item.GetComponent<SwordDataContains>();
            if (swordDataContains == null) return;

            switch (swordDataContains.GetSwordDataSO().swordGroupEnum)
            {
                case SwordGroupEnum.S:
                    tier_S_Sword.Add(item); break;
                case SwordGroupEnum.A:
                    tier_A_Sword.Add(item); break;
                case SwordGroupEnum.B:
                    tier_B_Sword.Add(item); break;
                case SwordGroupEnum.C:
                    tier_C_Sword.Add(item); break;
                case SwordGroupEnum.D:
                    tier_D_Sword.Add(item); break;
                default: break;
            }
        }
    }

    public Sword GetSword(SwordGroupEnum groupEnum, bool isAllRandom = false)
    {
        if (!isAllRandom)
        {
            switch (groupEnum)
            {
                case SwordGroupEnum.S:
                    return tier_S_Sword[Random.Range(0, tier_S_Sword.Count)];
                case SwordGroupEnum.A:
                    return tier_A_Sword[Random.Range(0, tier_A_Sword.Count)];
                case SwordGroupEnum.B:
                    return tier_B_Sword[Random.Range(0, tier_B_Sword.Count)];
                case SwordGroupEnum.C:
                    return tier_C_Sword[Random.Range(0, tier_C_Sword.Count)];
                case SwordGroupEnum.D:
                    return tier_D_Sword[Random.Range(0, tier_D_Sword.Count)];
                default:
                    return swords[Random.Range(0, swords.Count)];
            }
        }
        else
        {
            return swords[Random.Range(0, swords.Count)];
        }
    }
}
