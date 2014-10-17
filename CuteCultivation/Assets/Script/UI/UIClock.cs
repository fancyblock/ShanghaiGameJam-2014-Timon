using UnityEngine;
using System.Collections;

public class UIClock : MonoBehaviour 
{
    public UILabel m_txtTime;
    public float m_cycle;

    protected float m_timer;
    protected bool m_running;

	void Awake() 
	{
        //TODO 
    }

	// Use this for initialization
	void Start () 
	{
        m_timer = 0.0f;
        m_running = false;

        Startup();
	}
	
	// Update is called once per frame
	void Update () 
	{
        if( m_running )
        {
            m_txtTime.text = ((int)m_timer).ToString();

            m_timer += Time.deltaTime;

            if (m_timer >= m_cycle)
            {
                m_timer = 0.0f;

                //[TEMP]
                m_txtTime.text = "STOP";
                //[TEMP]

                m_running = false;
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
    public float TIME
    {
        get
        {
            return m_timer;
        }
    }

}
