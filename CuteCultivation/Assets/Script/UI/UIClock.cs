using UnityEngine;
using System.Collections;

public class UIClock : MonoBehaviour 
{
    public UILabel m_txtTime;
    public float m_cycle;		// the cycle time 

    protected float m_timer;
    protected bool m_running;

	// Use this for initialization
	void Start () 
	{
        m_timer = 0.0f;
        m_running = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
        if( m_running )
        {
			m_txtTime.text = ((int)(CYCLE_PERCENT*100)) + "%";

			// increate the time 
            m_timer += Time.deltaTime;

			// end the Clock 
            if (m_timer >= m_cycle)
            {
                m_timer = 0.0f;
                m_txtTime.text = "STOP";
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
