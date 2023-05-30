using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleStat : MonoBehaviour
{
   public float damage;
   [Range(0,1)]public float maxDistance;

   string tt;

    void Update() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position , transform.up, out hit, maxDistance ))  
        {
            print("hit: " + hit.transform.name);
            // hit.transform.root
        }
    }

    void private void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position , transform.up * masDistance);
    }

    void OnGUI() {
        GUI.Label(new Rect(180, 50, 200, 20), tt);
   }
}
