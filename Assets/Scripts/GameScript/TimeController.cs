using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TimeController : MonoBehaviour
{

    public static TimeController Instance;

    private int timeToScale = 0;
	
	void Start () {
	    if (Instance == null)
	    {
	        Instance = this;
	    }
	}

    private void Update()
    {
        if (timeToScale > 0)
        {
            timeToScale--;
            if (timeToScale == 0)
            {
                Time.timeScale = 1;
            }
        }
    }

    public void ScaleTime(float timeScale)
    {
        Time.timeScale = timeScale;
        timeToScale = 50;
    }

    
	
}
