using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float bounceForce;
    [SerializeField] private float bounceRadius;

    private Vector3 moveDirection;

    private void Start()
    {
        moveDirection = Vector3.forward;
    }

    private void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }

        if (other.TryGetComponent(out Obstacle obstacle))
        {
            Bounce();
        }
    }

    private void Bounce()
    {
        moveDirection = Vector3.back + Vector3.up;
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.AddExplosionForce(bounceForce, transform.position + new Vector3(0, -1, 1), bounceRadius);
    }
}
