using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private Heath playerHeath;
    [SerializeField] private Image totalHeathBar;
    [SerializeField] private Image currentHeathBar;
    private void Start()
    {
        totalHeathBar.fillAmount = playerHeath.currentHeath / 10;
    }
    private void Update()
    {
        currentHeathBar.fillAmount = playerHeath.currentHeath / 10;
    }
}
