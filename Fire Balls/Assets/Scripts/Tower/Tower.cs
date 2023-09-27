using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder towerBuilder;

    private List<Block> blocks;

    public event UnityAction<int> SizeUpdate;
    private void Start()
    {
        towerBuilder = GetComponent<TowerBuilder>();
        blocks = towerBuilder.Build();

        foreach (var block in blocks)
        {
            block.BulletHit += OnBulletHit;
        }

        SizeUpdate?.Invoke(blocks.Count);
    }

    private void OnBulletHit(Block hitedBlock)
    {
        hitedBlock.BulletHit -= OnBulletHit;

        blocks.Remove(hitedBlock);

        foreach(var block in blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x, block.transform.position.y - block.transform.localScale.y / 10, block.transform.position.z);
        }

        SizeUpdate?.Invoke(blocks.Count);
    }
}
