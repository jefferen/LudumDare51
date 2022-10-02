using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvent : MonoBehaviour
{
    [SerializeField]
    GameMaster gameMaster;
    public void CallDeathStare()
    {
        gameMaster.DeathStare();
    }
    public void StopDeathStare()
    {
        gameMaster.StopDeathStare();
    }
}
