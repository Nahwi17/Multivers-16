using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider energySlider;
    public float energyDecreaseRate = 1f; // Nilai pengurangan energi per detik

    private float currentEnergy;

    private void Start()
    {
        currentEnergy = 100f; // Nilai energi awal
        energySlider.maxValue = currentEnergy;
        energySlider.value = currentEnergy;
        InvokeRepeating("DecreaseEnergy", 0f, 10f); // Memanggil fungsi DecreaseEnergy setiap 10 detik
    }

    private void DecreaseEnergy()
    {
        currentEnergy -= energyDecreaseRate;
        energySlider.value = currentEnergy;

        if (currentEnergy <= 0f)
        {
            // Panggil fungsi DecreaseHP dari script HPBar
            HPBar hpBar = FindObjectOfType<HPBar>();
            hpBar.DecreaseHP();
        }
    }
}

