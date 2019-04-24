using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemService : MonoBehaviour {

    public static ItemService Instance;
    [SerializeField] private ItemData itemData;

    public void Start() {
        if (Instance == null) {
            Instance = this;
        }
    }

    public ItemBase getItemeData()
    {
        int i = Random.Range(0, itemData.ItemDesigns.Count);
        return itemData.ItemDesigns[i].item;
    }
}
