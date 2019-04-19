using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChildController : MonoBehaviour
{

    public PlayerChild playerMove;
    public AvatarPlayerManager playerAvatar;
     

    public void Init(PlayerDesign skin)
    {
        playerMove.Init(); 
        playerAvatar.UpdateSkin(skin);
    }
     
}
