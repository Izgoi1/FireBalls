using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float towerSize;
    [SerializeField] private Transform buildPoint;
    [SerializeField] private Block block;
    [SerializeField] private Color[] colors;

    private List<Block> blocks;

    public List<Block> Build()
    {
        blocks = new List<Block>();
        Transform currentPoint = buildPoint;

        for (int i = 0; i < towerSize; i++)
        {
            Block newBlock = BuildBlock(currentPoint);
            newBlock.SetColor(colors[Random.Range(0, colors.Length)]);
            blocks.Add(newBlock);
            currentPoint = newBlock.transform;
        }

        return blocks;
    }

    private Block BuildBlock(Transform currentBuildPoint)
    {
        return Instantiate(block, GetBuildPoint(currentBuildPoint), Quaternion.identity, buildPoint);
    }

    private Vector3 GetBuildPoint(Transform currentSegment)
    {
        return new Vector3(buildPoint.position.x, currentSegment.position.y + currentSegment.localScale.y / 10, buildPoint.position.z);
    }
}
