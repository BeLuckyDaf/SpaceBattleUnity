using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    public enum Commands
    {
        StateSnapshot         = 7,// server only
        PlayerJoined          = 8,// server only
        PlayerLeft            = 9,
        PlayerMove            = 10,
        PlayerBuyProperty     = 11,
        PlayerUpgradeProperty = 12,
        PlayerAttackPlayer    = 13,
        PlayerAttackProperty  = 14,
        PlayerHeal            = 15,
        PlayerKilled          = 16, // server only
        PlayerRespawned       = 17,
        GamePause             = 18, // server only
        GameUnpause           = 19, // server only
        GameEnd               = 20, // server only
        GameServerMessage     = 21, // server only
    }
}
