using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemData", order = 1)]
public class ItemData : ScriptableObject {
    public List<ItemDesign> ItemDesigns = new List<ItemDesign>();

}

[Serializable]
public class ItemDesign {
    public ItemBase item;
}
