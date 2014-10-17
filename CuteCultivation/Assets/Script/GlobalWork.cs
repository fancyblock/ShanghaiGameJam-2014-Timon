using UnityEngine;
using System.Collections;

public class GlobalWork 
{
    static protected GlobalWork m_instance = null;

    /// <summary>
    /// instance 
    /// </summary>
    static public GlobalWork Instance
    {
        get
        {
            if( m_instance != null )
            {
                m_instance = new GlobalWork();
            }

            return m_instance;
        }
    }

    /// <summary>
    /// constructor 
    /// </summary>
    public GlobalWork()
    {
    }

    /// <summary>
    /// initial the GlobalWork
    /// </summary>
    public void Init()
    {
        //TODO 
    }

}
