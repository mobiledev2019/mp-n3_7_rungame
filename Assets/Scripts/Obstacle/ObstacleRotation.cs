using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ObstacleRotation : MonoBehaviour
{

    [SerializeField] private Vector3 directorRotation;
    [SerializeField] private float limitRotation;
    private float temp;
    private bool IsRotation;

	void Update ()
	{
	    if (IsRotation)
	    {
	        IsRotation = false;
            rotation();
	    }

	}

    private void rotation()
    {
        DOVirtual.Float(-limitRotation, limitRotation, 2f, temp => { transform.eulerAngles = directorRotation * temp; })
            .OnComplete(() =>
            {
                DOVirtual.Float(-limitRotation, limitRotation, 2f,
                    temp => { transform.eulerAngles = directorRotation * temp; }).OnComplete(() =>
                    {
                        IsRotation = true;
                    });
                
            });
    }
}
