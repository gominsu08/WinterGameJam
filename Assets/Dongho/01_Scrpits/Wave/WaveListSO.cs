using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "SO/WaveList")]
public class WaveListSO : ScriptableObject
{
    public List<WaveSO> _waves;
}
