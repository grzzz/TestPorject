using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Voluem : MonoBehaviour
{
    private Slider volume;

	void Start ()
	{
	    volume = GetComponent<Slider>();
	}
	
	
	void Update ()
	{
	    volume.value = MusicManager.instance.value;
	}
}
