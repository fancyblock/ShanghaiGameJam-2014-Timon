using UnityEngine;
using System.Collections;

public class Defines
{
    //TODO 
}

/// <summary>
/// game status 
/// </summary>
public enum eGameStatus
{
	eGamePending = 0,
	eGameRunning,
	eGamePause,
	eGameShowResult,
	eGameEnd
}

/// <summary>
/// moumou type enum
/// </summary>
public enum eMoumouType:int
{
	eMoumouTypeInit = 0,
    eMoumouType01,
    eMoumouType02,
    eMoumouType03,
    eMoumouType04,
    eMoumouType05,
    eMoumouType06,
    eMoumouType07,
    eMoumouTypeMax
};


/// <summary>
/// fodder type enum
/// </summary>
public enum eFodderType
{
    eFodderTypeNone = 0,
    eFodderAAA,
    eFodderBBB,
    eFodderTypeMax
};
