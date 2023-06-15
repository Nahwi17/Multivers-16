using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageEnemy : MonoBehaviour
{
    public bool playerInRange = false;

    int interval = 1;
    float nextTime = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {

            //do something every interval seconds
            if (playerInRange)
            {
                PlayerStatus.Instance.currentHP -= 12;
            }

            nextTime += interval;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
