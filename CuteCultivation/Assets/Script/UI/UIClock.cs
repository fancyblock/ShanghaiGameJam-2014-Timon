using UnityEngine;
using System.Collections;

public class UIClock : MonoBehaviour 
{
	public UISprite m_bgNight;
	public UISprite m_bgNoon;
	public UISprite m_sunmoon;
    public float m_cycle;		// the cycle time 

    protected float m_timer;
    protected bool m_running;

	// Use this for initialization
	void Start () 
	{
        m_timer = 0.0f;
        m_running = false;

		m_bgNight.alpha = 1.0f;
		m_bgNoon.alpha = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if( m_running )
        {
			m_sunmoon.transform.localRotation = Quaternion.Euler( 0.0f, 0.0f, CYCLE_PERCENT * 360.0f );

			if( CYCLE_PERCENT > 0.5f )
			{
				m_bgNight.alpha = 0.0f;
				m_bgNoon.alpha = 1.0f;
			}
			else
			{
				m_bgNight.alpha = 1.0f;
				m_bgNoon.alpha = 0.0f;
			}

			// increate the time 
            m_timer += Time.deltaTime;

			// end the Clock 
            if (m_timer >= m_cycle)
            {
                m_timer = 0.0f;
				m_sunmoon.transform.localRotation = Quaternion.Euler( 0.0f, 0.0f, 0.0f );
				m_bgNight.alpha = 1.0f;
				m_bgNoon.alpha = 0.0f;
                m_running = false;

                GameController.Instance.onCycleEnd();
            }
        }
	}


    /// <summary>
    /// startup the timer 
    /// </summary>
    public void Startup()
    {
        m_timer = 0.0f;
        m_running = true;
    }

    /// <summary>
    /// if is running or not 
    /// </summary>
    public bool IS_RUNNING
    {
        get
        {
			return m_running;
        }
    }

    /// <summary>
    /// return the current time 
    /// </summary>
    public float CYCLE_PERCENT
    {
        get
        {
			return m_timer / m_cycle;
        }
    }

}
