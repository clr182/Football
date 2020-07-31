using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AppData
{
    #region Player
    #endregion

    #region GameMode Data
    
    #endregion

}


public enum Selections
{

    Defender,
    Striker,
    Midfielder,
}

public enum Actions
{
    Move,
    Pass,
    Shoot,
    Tackle,
}

public enum HexDirection { 
    NE, 
    E, 
    SE, 
    SW, 
    W, 
    NW,
}

public enum HexType
{
    playable,
    nonplayable,
    active,
    neighbor,
}


