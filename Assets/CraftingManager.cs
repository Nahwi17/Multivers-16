using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    public List<ItemBase> mixer;
    public ItemBase potionResult;
    public ResepData resepdata;
    public Inventory inventory;
    public int correctCount;

    public void StirUp() //Cek Resep
    {
        if (CompareLists(mixer, resepdata.ResepItem))
        {
            // Debug.Log("LIST SAMA " + recipeData[i].recipeName);
            // potionResult = recipeData[i];
            
            inventory.itemList.Add(potionResult);
            mixer.Clear();
            // break;
        }
        // Debug.Log("STIRRING");
        // for (int i = 0; i < recipeData.Count; i++)
        // {
      
        // }
    }

    private void OnEnable()
    {
        Actions.AddItemToMixer += AddMixer;
  
    }

    private void OnDisable()
    {
        Actions.AddItemToMixer -= AddMixer;
      
    }

    public void AddMixer(ItemBase itmBase)
    {
        mixer.Add(itmBase);
    }

    public bool CompareLists(List<ItemBase> list1, List<ItemBase> list2)
    {
        if (list1 == null || list2 == null)
        {
            Debug.LogWarning("Salah satu List kosong.");
            return false;
        }

        if (list1.Count != list2.Count)
        {
            Debug.LogWarning("Jumlah elemen pada kedua List tidak sama.");
            return false;
        }

        
        for (int i = 0; i < list1.Count; i++)
        {
            //correctCount = 0;

            for (int j = 0; j < list2.Count; j++)
            {
                if (list1[i] != list2[j])
                {
                    // Debug.LogWarning("Elemen pada indeks [" + i + "] tidak sama. " + list1[i].ingredient + " " + list2[j].ingredient);
                    Debug.Log("element tidak sama");
                }
                else
                {
                    // Debug.LogWarning("Elemen pada indeks [" + i + "] sama. " + list1[i].ingredient + " " + list2[j].ingredient);
                    Debug.Log("elemen sama ");
                    correctCount++;
                    Debug.Log(correctCount + "/" + list2.Count);
                    break;
                }
            }
        }

        if (correctCount == list2.Count)
        {
            Debug.Log("RESEP DITEMUKAN");
            correctCount = 0;
            return true;
        }
        else
        {
            Debug.Log("RESEP TIDAK DITEMUKAN");
            correctCount = 0;
            return false;
        }
        
    }

}
