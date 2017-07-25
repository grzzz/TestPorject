using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    public static MusicManager instance;
    public float value;

    private void Start()
    {
        instance = this;
    }
 
    public void SetVolume(float a)
    {
        value = a;

    }
}
