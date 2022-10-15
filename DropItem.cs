using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{                         
    [SerializeField] private Item[] itens;

    public void Drop(){
        foreach (Item it in itens)
        {        
            int rand = Random.Range(1,100);
           

            if (rand < it.itemDropRate)
            {
                int amount = Random.Range(it.minDrop, it.maxDrop);

                for (int i = 0; i < amount; i++)
                {
                    Instantiate(it.item, transform.position, transform.rotation);
                }
            }
        }
    }

    [System.Serializable]
    public class Item{

        public GameObject item;
        public int itemDropRate;
        public int minDrop;
        public int maxDrop;
    }

        

}    