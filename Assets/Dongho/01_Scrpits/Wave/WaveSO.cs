using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "SO/Wave")]
public class WaveSO : ScriptableObject
{
    public List<GameObject> monsters;
    public List<int> monstersNumber;
    public int wave;
}
