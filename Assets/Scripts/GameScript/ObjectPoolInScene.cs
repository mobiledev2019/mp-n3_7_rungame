using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolInScene<T> : MonoBehaviour where T : MonoBehaviour {
    private static T instance;

    public T prefabs;
    public List<T> ListInGame;
    public Transform CameraTransform;
    public float LimitFirst;
    public float LimitLast;
    [SerializeField] private bool setStart;
 
    public virtual void Start() {
//        Init();
    }

    public virtual void Init() {
        if (ListInGame == null)
        {
            ListInGame = new List<T>();
        }

        for (int i = 0; i < ListInGame.Count; i++)
        {
            ListInGame[i].Recycle();
        }
        ListInGame.Clear();
        if (setStart)
        {
            ListInGame.Add(prefabs.Spawn(transform));
        } 
    }


    public virtual void CheckPool()
    {
        if (ListInGame.Count == 0) return;
        var last = ListInGame[ListInGame.Count - 1];
        if (IsInCamera(last)) {
            SpawnObject(last);
        }

        var first = ListInGame[0];
        if (IsOutOfCamera(first)) {
            RecycleObject();
        }
    }

    public virtual void SpawnObject(T last = null) {
        var prefabsTemp = prefabs.Spawn(transform);
        ListInGame.Add(prefabsTemp);
    }

    public void RecycleObject() {
        T first = ListInGame[0];
        first.Recycle(); 
  
        ListInGame.RemoveAt(0);

    }

    public  bool IsOutOfCamera(T first) {
        if (first.transform.position.z < CameraTransform.position.z + LimitFirst || first.transform.position.y < -10) {
            return true;
        }

        return false;
    }

    public bool IsInCamera(T last) {
        if (last.transform.position.z < CameraTransform.position.z + LimitLast) {
            return true;
        }
        return false;
    }
}
