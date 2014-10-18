using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameController : MonoBehaviour 
{
    static protected GameController m_instance = null;

    /// <summary>
    /// retuen the GameController singleton 
    /// </summary>
    static public GameController Instance
    {
        get
        {
            return m_instance;
        }
    }


    public UIToggle[] m_toggleFodder;
    public UIFodderGen m_fodderGen;
    public UICatalogue m_uiCatalogue;
    public UIClock m_uiClock;
	public float m_eatFodderTime;
	public UIMoumou m_moumou;

    protected eFodderType m_curFodder;
	protected eGameStatus m_status;
	protected List<eFodderType> m_fodderList;
	protected float m_timer;
	protected eMoumouType m_curMoumouType;
	protected eMoumouType m_resultMoumouType;

	void Awake() 
	{
        m_instance = this;
    }

	// Use this for initialization
	void Start () 
	{
		// initial 
		GlobalWork.Instance.Init();

		// init the game 
		m_fodderList = new List<eFodderType>();
		m_status = eGameStatus.eGamePending;
		m_curMoumouType = eMoumouType.eMoumouTypeInit;
		m_timer = 0.0f;

        // start the game 
        StartCoroutine("startingGame");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( m_status == eGameStatus.eGameRunning )
		{
			m_timer += Time.deltaTime;

			// add the fodder to the list 
			if( m_timer >= m_eatFodderTime )
			{
				m_timer -= m_eatFodderTime;

				if( m_curFodder != eFodderType.eFodderTypeNone )
				{
					m_fodderList.Add( m_curFodder );
				}
			}
		}
	}

    /// <summary>
    /// when a cycle end, calculate which Moumou you got
    /// </summary>
    public void onCycleEnd()
    {
        m_fodderGen.WORKING = false;

		// calculate the result Moumou 
		eMoumouType resultMoumou = eMoumouType.eMoumouTypeInit;
		int fodderAA = 0;
		int fodderBB = 0;

		foreach( eFodderType type in m_fodderList )
		{
			if( type == eFodderType.eFodderAAA )
			{
				fodderAA ++;
			}
			else if( type == eFodderType.eFodderBBB )
			{
				fodderBB ++;
			}
		}

		if( fodderAA > 0 && fodderBB == 0 )
		{
			// type 1
			resultMoumou = eMoumouType.eMoumouType01;
		}
		else if( fodderBB > 0 && fodderAA == 0 )
		{
			// type 2
			resultMoumou = eMoumouType.eMoumouType02;
		}
		else if( fodderAA > 0 && fodderBB > 0 )
		{
			eFodderType firstFodder = m_fodderList[0];

			if( firstFodder == eFodderType.eFodderAAA )
			{
				if( fodderAA > fodderBB )
				{
					// type 3
					resultMoumou = eMoumouType.eMoumouType03;
				}
				else
				{
					// type 4
					resultMoumou = eMoumouType.eMoumouType04;
				}
			}
			else if( firstFodder == eFodderType.eFodderBBB )
			{
				if( fodderAA > fodderBB )
				{
					// type 5
					resultMoumou = eMoumouType.eMoumouType05;
				}
				else
				{
					// type 6
					resultMoumou = eMoumouType.eMoumouType06;
				}
			}
		}
		else
		{
			// type 7 
			resultMoumou = eMoumouType.eMoumouType07;
		}

		m_resultMoumouType = resultMoumou;

		StartCoroutine("changeToNewMoumou");
    }

    /// <summary>
    /// on fodder changed 
    /// </summary>
    public void onFodderChanged()
    {
        foreach( UIToggle toggle in m_toggleFodder )
        {
            if( toggle.value )
            {
                m_curFodder = toggle.GetComponent<Fodder>().m_type;
                m_fodderGen.SetFodder(m_curFodder);

                break;
            }
        }
    }

    /// <summary>
    /// show catalogue 
    /// </summary>
    public void onShowCatalogue()
    {
        Debug.Log("[GameController]: onShowCatalogue");

        m_uiCatalogue.Show(true);
    }

    /// <summary>
    /// starting the game 
    /// </summary>
    /// <returns></returns>
    protected IEnumerator startingGame()
    {
        yield return new WaitForFixedUpdate();

        //TODO 

		start();
    }

	/// <summary>
	/// Cchange to new moumou
	/// </summary>
	/// <returns>The to new moumou.</returns>
	protected IEnumerator changeToNewMoumou()
	{
		yield return new WaitForFixedUpdate();

		//TODO 
		m_moumou.SetMoumou( m_resultMoumouType );

		// set as next 
		m_curMoumouType = m_resultMoumouType;

		// add to catalogue 
		GlobalWork.Instance.CATALOGUE.MakeAsOwned( m_resultMoumouType );

		if( GlobalWork.Instance.CATALOGUE.IsCollectDone() )
		{
			// game finish 
			m_status = eGameStatus.eGameEnd;
		}
		else
		{
			// start a new turn 
			start();
		}
	}

	/// <summary>
	/// Start droping
	/// </summary>
	protected void start()
	{
		m_timer = 0.0f;
		m_curFodder = eFodderType.eFodderTypeNone;
		m_fodderList.Clear();
		//TODO 
		m_status = eGameStatus.eGameRunning;

		m_uiClock.Startup();
		m_fodderGen.WORKING = true;
		m_fodderGen.SetFodder(m_curFodder);
		
		m_status = eGameStatus.eGameRunning;
	}

}

