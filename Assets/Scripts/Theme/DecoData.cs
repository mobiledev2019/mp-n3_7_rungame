using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deco", menuName = "DecoData", order = 1)]
public class DecoData : ScriptableObject
{
    [SerializeField] private string Name;
    public List<Deco> Decos;

}

