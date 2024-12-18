using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "SO/Sword/SwordObjectListSO" )]
public class SwordObjectListSO : ScriptableObject
{
    public List<Sword> swords = new List<Sword>();
}
