using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Networking
{
    public struct PayloadResult
    {
        public bool Ok;
        public string Message;
    }

    // PayloadPlayerInputMove represents new user location
    struct PayloadPlayerInputMove
    {
        public int Location;
    }

    // PayloadPlayerUpdateMove represents new user location
    struct PayloadPlayerUpdateMove
    {
        public string UID;
        public int From;
        public int To;
        public PayloadResult Result;
    }

    // PayloadPlayerUpdateJoined represents the newly joined player
    struct PayloadPlayerUpdateJoined
    {
        public string UID;
    }

    // PayloadPlayerInputBuyProperty represents new user property
    struct PayloadPlayerInputBuyProperty
    {
        public int Location;
    }

    // PayloadPlayerUpdateBuyProperty represents new user property
    struct PayloadPlayerUpdateBuyProperty
    {
        public string UID;
        public int Location;
        public PayloadResult Result;
    }

    // PayloadPlayerInputUpgradeProperty represents new user location
    struct PayloadPlayerInputUpgradeProperty
    {
        public int Location;
    }

    // PayloadPlayerUpdateUpgradeProperty represents new user location
    struct PayloadPlayerUpdateUpgradeProperty
    {
        public string UID;
        public int Location;
        public PayloadResult Result;
    }

    // PayloadPlayerInputAttackProperty represents new user location
    struct PayloadPlayerInputAttackProperty
    {
        public int Location;
    }

    // PayloadPlayerUpdateAttackProperty represents user attacking property
    struct PayloadPlayerUpdateAttackProperty
    {
        public string UID;
        public int Location;
        public PayloadResult Result;
    }

    // PayloadPlayerUpdateHeal represents user healing
    struct PayloadPlayerUpdateHeal
    {
        public string UID;
        public int Location;
        public int NewHp;
        public PayloadResult Result;
    }

    // PayloadPlayerUpdateRespawned represents newly spawned user
    struct PayloadPlayerUpdateRespawned
    {
        public string UID;
        public int Location;
        public PayloadResult Result;
    }
}


