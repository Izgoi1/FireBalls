using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Transform shootPosition;
    [SerializeField] private Bullet bulletTemplate;
    [SerializeField] private float deleyBetweenShoot;
    [SerializeField] private float recoilDistance;

    private float timeAfterShoot;

    private void Update()
    {
        timeAfterShoot += Time.deltaTime;

        if (Input.GetMouseButton(0))
        {
            if (timeAfterShoot > deleyBetweenShoot)
            {
                Shoot();
                transform.DOMoveZ(transform.position.z - recoilDistance, deleyBetweenShoot / 2).SetLoops(2, LoopType.Yoyo); /*using DOTween for animate obstacle*/
                timeAfterShoot = 0;
            }
        }
    }

    private void Shoot()
    {
        Instantiate(bulletTemplate, shootPosition.transform.position, Quaternion.identity);
    }
}
