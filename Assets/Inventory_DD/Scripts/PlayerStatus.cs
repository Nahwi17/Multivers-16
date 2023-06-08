using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public int hp;
    public int wellness;
    public Slider hpSlider;
    public Slider wellnessSlider;
    

    private void OnEnable()
    {
        Actions.IncreaseHP += IncreasePlayerHP;
        Actions.IncreaseWellness += IncreasePlayerWellness;
    }

    private void OnDisable()
    {
        Actions.IncreaseHP -= IncreasePlayerHP;
        Actions.IncreaseWellness -= IncreasePlayerWellness;
    }

    private void Start() {
        SetupHpBar(75);
        SetupWellnessBar(75);
        
    }


    public void IncreasePlayerHP(int value)
    {
        if (hp < 100)
        {
            hp += value;
            
            if(hp >= 100)
            {
                hp = 100;
            }

            SetupHpBar(hp);
        } 
    }

    public void IncreasePlayerWellness(int value)
    { 
        if (wellness < 100)
        {
            wellness += value;

            if(wellness >= 100)
            {
                wellness= 100;
            }

            SetupWellnessBar(wellness);
        }
    }

    public void SetupHpBar(int currentValue)
    {
        hp = currentValue;
        hpSlider.value = currentValue;
    }

    public void SetupWellnessBar(int currentValue)
    {
        wellness = currentValue;
        wellnessSlider.value = currentValue;
    }
}





