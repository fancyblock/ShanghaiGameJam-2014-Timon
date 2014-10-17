using UnityEngine;
using System.Collections;

public class TimeSection 
{
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    public TimeSection( float from, float to )
    {
        FROM_TIME = from;
        TO_TIME = to;
    }

    public float FROM_TIME { get; set; }
    public float TO_TIME { get; set; }

}
