using UnityEngine;
using System.Collections;

public class UIFodderGen : MonoBehaviour 
{
    // how many fodder be generated each second 
    public float m_speed;
    public UILabel m_txtStatus;

    protected bool m_working;

	// Use this for initialization
	void Start () 
	{
        m_working = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO 
	}

    /// <summary>
    /// set fodder
    /// </summary>
    /// <param name="type"></param>
	public void SetFodder( eFodderType type )
    {
        Debug.Log("[UIFodderGen]: " + type.ToString());

		if( type == eFodderType.eFodderTypeNone )
		{
			m_txtStatus.text = "None";
		}
		else
		{
			m_txtStatus.text = type.ToString() + "\nin\ndroping!";
		}
    }

    /// <summary>
    /// set the fodder gen working or not 
    /// </summary>
    public bool WORKING
    {
        set
        {
            if( value )
            {
                //
            }
            else
            {
                m_txtStatus.text = "none";
            }

            m_working = value;
        }
    }
}

