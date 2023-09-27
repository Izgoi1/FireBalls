using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerSizeView : MonoBehaviour
{
    [SerializeField] private TMP_Text sizeView;
    [SerializeField] private Tower tower;

    private void OnEnable()
    {
        tower.SizeUpdate += OnSizeUpdate;
    }

    private void OnDisable()
    {
        tower.SizeUpdate -= OnSizeUpdate;
    }

    private void OnSizeUpdate(int size)
    {
        sizeView.text = size.ToString();
    }
}
