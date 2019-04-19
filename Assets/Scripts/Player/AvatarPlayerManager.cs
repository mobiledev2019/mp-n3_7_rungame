using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPlayerManager : MonoBehaviour
{

    [SerializeField] private PlayerDesign _playerDesign;
    [SerializeField] private GameObject SkinChil;
    [SerializeField] private Vector3 positionAvatar;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        SkinChil = transform.GetChild(0).gameObject;
        
    }

    public void UpdateSkin(PlayerDesign skin)
    {
        positionAvatar = SkinChil.transform.position;
        SkinChil.Recycle();
        SkinChil = skin.avatar.Spawn(transform);
        SkinChil.transform.position = positionAvatar;
    }
}
