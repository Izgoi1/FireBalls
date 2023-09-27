using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float animationDuration; 

    private void Start()
    {
        /*using DOTween for animate obstacle*/
        transform.DORotate(new Vector3(0, 360, 0), animationDuration, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }
}
