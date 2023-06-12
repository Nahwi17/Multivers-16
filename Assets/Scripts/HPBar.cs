using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider hpSlider;
    public float hpDecreaseRate = 1f; // Nilai pengurangan HP per detik

    private float currentHP;

    private void Start()
    {
        currentHP = 100f; // Nilai HP awal
        hpSlider.maxValue = currentHP;
        hpSlider.value = currentHP;
    }

    public void DecreaseHP()
    {
        currentHP -= hpDecreaseRate;
        hpSlider.value = currentHP;

        if (currentHP <= 0f)
        {
            // Lakukan aksi jika HP mencapai 0 atau kurang dari 0
            Debug.Log("Game Over");
        }
    }
}
