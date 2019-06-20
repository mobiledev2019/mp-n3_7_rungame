using UnityEngine;

public class DecoPool : ObjectPoolInScene<Deco>
{ 
    private DecoData decoes;
    [SerializeField] private int percent;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        decoes = ThemeServer.Instance.GetDeco();
    }

    public override void CheckPool()
    {
        if (ListInGame.Count == 0 || decoes == null ) return;
        var last = ListInGame[ListInGame.Count - 1];
        if (IsInCamera(last))
        {
            SpawnObject(last);
        }
    }

    public virtual void SpawnObject(Vector3 pos)
    {
        if (decoes == null) return;
        int ran = Random.Range(0, 101);
        if (ran < percent)
        {
            var prefabsTemp = RandomDeco().Spawn(transform);
            ListInGame.Add(prefabsTemp);
            prefabsTemp.transform.position = pos;
       
        }
    }

    private Deco RandomDeco()
    {
        int index = Random.Range(0, decoes.Decos.Count);
        return decoes.Decos[index];
    }

}
