using UnityEngine;
using System.Collections;

public class UIFodderGen : MonoBehaviour 
{
    // how many fodder be generated per second 
    public float m_speed;
    public UILabel m_txtStatus;
	public GameObject m_fodderAAA;
	public GameObject m_fodderBBB;

    protected bool m_working;
	protected GameObject m_curFodder;
	protected float m_genCycle;
	protected float m_timer;

	// Use this for initialization
	void Start () 
	{
        m_working = false;
		m_genCycle = 1.0f / m_speed;
		m_timer = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( m_working )
		{
			m_timer += Time.deltaTime;

			if( m_timer >= m_genCycle )
			{
				m_timer -= m_genCycle;

				genRandomFodder();
			}
		}
	}

    /// <summary>
    /// set fodder
    /// </summary>
    /// <param name="type"></param>
	public void SetFodder( eFodderType type )
    {
		// show the status 
		if( type == eFodderType.eFodderAAA )
		{
			m_curFodder = m_fodderAAA;
		}
		else if( type == eFodderType.eFodderBBB )
		{
			m_curFodder = m_fodderBBB;
		}
		else
		{
			m_curFodder = null;
		}

		// change the look 
		//TODO 
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
				m_timer = 0.0f;
            }
            else
            {
                //TODO 
            }

            m_working = value;
        }
    }

	/// <summary>
	/// Ggenerate a rodder with random position 
	/// </summary>
	protected void genRandomFodder()
	{
		if( m_curFodder != null )
		{
			GameObject go = Instantiate( m_curFodder ) as GameObject;
			UIFodder fodder = go.GetComponent<UIFodder>();

			go.transform.parent = transform;
			go.transform.localScale = Vector3.one;
			go.transform.localPosition = new Vector3( Random.Range( -70.0f, 70.0f ), 0.0f, 0.0f );

			fodder.m_acce = Random.Range( 0.07f, 0.2f );
			fodder.m_angleVelocity = Random.Range( 0.3f, 0.8f );
		}
	}

}

