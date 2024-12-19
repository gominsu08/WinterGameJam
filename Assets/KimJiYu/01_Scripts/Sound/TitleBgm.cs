using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleBgm : MonoBehaviour
{
    private void Start()
    {
        SoundManager.Instance.PlaySound("TitleBG");
    }
}
