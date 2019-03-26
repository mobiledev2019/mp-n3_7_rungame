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

    public static T Instance {
        get {
            if (instance == null) {
                instance = GameObject.FindObjectOfType<T>();
                if (instance == null) instance = new GameObject("Singleton", typeof(T)).GetComponent<T>();
            }

            return instance;
        }
        set { instance = value; }
    }

    public virtual void Start() {
        Init();
    }

    private void Init() {
        ListInGame = new List<T>();
        ListInGame.Add(prefabs.Spawn(transform));
    }

    public virtual void CheckPool()
    {
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
        ListInGame.RemoveAt(0);
        first.Recycle();
    }

    public  bool IsOutOfCamera(T first) {
        if (first.transform.position.z < CameraTransform.position.z + LimitFirst) {
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
