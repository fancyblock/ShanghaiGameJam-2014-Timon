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
	public SePlayer m_sePlayer;
	public GameObject m_maskPause;

    protected eFodderType m_curFodder;
	protected eGameStatus m_lastStatus;
	protected eGameStatus m_status;
	protected List<eFodderType> m_fodderList;
	protected float m_timer;
	protected eMoumouType m_curMoumouType;
	protected eMoumouType m_resultMoumouType;

	void Awake() 
	{
        m_instance = this;

		// initial 
		GlobalWork.Instance.Init();
    }

	// Use this for initialization
	void Start () 
	{
		m_uiCatalogue.ON_HIDE_CALLBACK = onHideCatalogue;

		// init the game 
		m_fodderList = new List<eFodderType>();
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

			if( m_curFodder != eFodderType.eFodderTypeNone )
			{
				m_moumou.PLAY = true;
			}
			else
			{
				m_moumou.PLAY = false;
			}
		}
		else
		{
			m_moumou.PLAY = false;
		}
	}

    /// <summary>
    /// when a cycle end, calculate which Moumou you got
    /// </summary>
    public void onCycleEnd()
    {
        m_fodderGen.WORKING = false;
		m_moumou.PLAY = false;

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
		pause();
        m_uiCatalogue.Show(true);
    }

	/// <summary>
	/// hide catalogue
	/// </summary>
	public void onHideCatalogue()
	{
	}

	/// <summary>
	/// Cchange to new moumou
	/// </summary>
	/// <returns>The to new moumou.</returns>
	protected IEnumerator changeToNewMoumou()
	{
		yield return new WaitForFixedUpdate();

		// player SE
		m_sePlayer.PlayTransition();

		m_moumou.SetMoumou( m_resultMoumouType );

		while( m_moumou.AnimationDone() == false )
		{
			yield return new WaitForFixedUpdate();
		}

		// set as next 
		m_curMoumouType = m_resultMoumouType;

		// add to catalogue 
		GlobalWork.Instance.CATALOGUE.MakeAsOwned( m_resultMoumouType );

		if( GlobalWork.Instance.CATALOGUE.IsCollectDone() )
		{
			// game finish 
			m_status = eGameStatus.eGameEnd;

			showWin();
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
	public void start()
	{
		m_maskPause.SetActive(false);
		m_status = eGameStatus.eGamePending;
		m_curMoumouType = eMoumouType.eMoumouTypeInit;

		m_timer = 0.0f;
		m_curFodder = eFodderType.eFodderTypeNone;
		m_fodderList.Clear();
		m_toggleFodder[0].value = true;
		m_toggleFodder[1].value = false;
		m_toggleFodder[2].value = false;
		m_status = eGameStatus.eGameRunning;

		m_uiClock.Startup();
		m_fodderGen.WORKING = true;
		m_fodderGen.SetFodder(m_curFodder);
		m_moumou.PLAY = true;
		
		m_status = eGameStatus.eGameRunning;
	}

	/// <summary>
	/// pause the game
	/// </summary>
	protected void pause()
	{
		m_lastStatus = m_status;
		m_status = eGameStatus.eGamePause;
		m_fodderGen.WORKING = false;

		m_maskPause.SetActive(true);
	}

	protected void showWin()
	{
		//TODO 
	}

}

