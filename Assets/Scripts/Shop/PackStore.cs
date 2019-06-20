using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "packData", menuName = "PackShopData", order = 1)]
public class PackStore : ScriptableObject { 

    public List<packTheme> packs;
}

[Serializable]
public class packTheme {
    public int price;
    public string des;
    public int index;
    public string name;
}
