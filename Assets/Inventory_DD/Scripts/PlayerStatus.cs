using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    //header hP
    // public int hp;
    public Slider hpSlider;
    public float hpDecreaseRate = 1f; // Nilai pengurangan HP per detik
    public float currentHP;

    //header energy
    public Slider energySlider;
    public float energyDecreaseRate = 1f; // Nilai pengurangan energi per detik
    public float currentEnergy;

    private void OnEnable()
    {
        Actions.IncreaseHP += IncreasePlayerHP;
        Actions.IncreaseWellness += IncreasePlayerEnergy;
    }

    private void OnDisable()
    {
        Actions.IncreaseHP -= IncreasePlayerHP;
        Actions.IncreaseWellness -= IncreasePlayerEnergy;
    }

    private void Start() {
        SetupHpBar(75);
        SetupEnergyBar(75);

        //hp bar 
        currentHP = 100f; // Nilai HP awal
        hpSlider.maxValue = currentHP;
        hpSlider.value = currentHP;

        //energy bar 
        currentEnergy = 100f; // Nilai energi awal
        energySlider.maxValue = currentEnergy;
        energySlider.value = currentEnergy;
        // InvokeRepeating("DecreaseEnergy", 0f, 10f); // Memanggil fungsi DecreaseEnergy setiap 10 detik
        
    }

    //mengurangi value hp 
    public void DecreaseHP()
    {
        currentHP -= hpDecreaseRate;
        // hpSlider.value = currentHP;

        SetupHpBar(currentHP);

        if (currentHP <= 0f)
        {
            // Lakukan aksi jika HP mencapai 0 atau kurang dari 0
            Debug.Log("Game Over");
        }
    }

    //energy
    private void DecreaseEnergy()
    {
        currentEnergy -= energyDecreaseRate;
        energySlider.value = currentEnergy;

        if (currentEnergy <= 0f)
        {
            // Panggil fungsi DecreaseHP dari script HPBar
            // HPBar hpBar = FindObjectOfType<HPBar>();
            // hpBar.DecreaseHP();
            DecreaseHP();
        }
    }


    public void IncreasePlayerHP(int value)
    {
        if (currentHP < 100)
        {
            currentHP += value;
            
            if(currentHP >= 100)
            {
                currentHP = 100;
            }

            SetupHpBar(currentHP);
        } 
    }

    public void IncreasePlayerEnergy(int value)
    { 
        if (currentEnergy < 100)
        {
            currentEnergy += value;

            if(currentEnergy >= 100)
            {
                currentEnergy = 100;
            }

            SetupEnergyBar(currentEnergy);
        }
    }

    public void SetupHpBar(float currentValue)
    {
        currentHP = currentValue;
        hpSlider.value = currentValue;
    }

    public void SetupEnergyBar(float currentValue)
    {
        currentEnergy = currentValue;
        energySlider.value = currentValue;
    }
}





