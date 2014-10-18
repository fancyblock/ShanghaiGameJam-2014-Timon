using UnityEngine;
using System;
using System.Collections;

public class UIMoumou : MonoBehaviour 
{
	public UISprite m_sprMoumou;
	public Animator m_animator;
	public float m_aniElapsed;
	public bool PLAY
	{
		set
		{
			if( value )
			{
				//TODO 
			}
			else
			{
				m_sprMoumou.spriteName = m_spriteName + "1";
			}

			m_isPlaying = value;
		}
	}

	protected bool m_inAnimation;
	protected eMoumouType m_nextMoumouType;
	protected string m_spriteName;
	protected float m_timer;
	protected bool m_isPlaying;

	// Use this for initialization
	void Start () 
	{
		m_inAnimation = false;
		m_timer = 0.0f;
		m_spriteName = "1_";
		m_isPlaying = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( m_isPlaying )
		{
			m_timer += Time.deltaTime;

			if( m_timer >= m_aniElapsed )
			{
				m_timer -= m_aniElapsed;

				string firstFrame = m_spriteName + "1";
				if( m_sprMoumou.spriteName == firstFrame )
				{
					m_sprMoumou.spriteName = m_spriteName + "2";
				}
				else
				{
					m_sprMoumou.spriteName = firstFrame;
				}
			}
		}
	}

	/// <summary>
	/// Set moumou
	/// </summary>
	/// <param name="type">Type.</param>
	public void SetMoumou( eMoumouType type )
	{
		m_inAnimation = true;
		m_nextMoumouType = type;

		m_animator.Play("aniMoumouTrans");
	}

	/// <summary>
	/// on change time
	/// </summary>
	public void onChangeTime()
	{
		// change the moumou look 
		setByType( m_nextMoumouType );
	}

	/// <summary>
	/// on chnge done
	/// </summary>
	public void onChangeDone()
	{
		m_inAnimation = false;
	}

	/// <summary>
	/// if animation done or not
	/// </summary>
	/// <returns><c>true</c>, if done was animationed, <c>false</c> otherwise.</returns>
	public bool AnimationDone()
	{
		return !m_inAnimation;
	}

	/// <summary>
	/// Set by type
	/// </summary>
	/// <param name="type">Type.</param>
	protected void setByType( eMoumouType type )
	{
		switch( type )
		{
		case eMoumouType.eMoumouType01:
			m_spriteName = "2_";
			break;
		case eMoumouType.eMoumouType02:
			m_spriteName = "3_";
			break;
		case eMoumouType.eMoumouType03:
			m_spriteName = "4_";
			break;
		case eMoumouType.eMoumouType04:
			m_spriteName = "5_";
			break;
		case eMoumouType.eMoumouType05:
			m_spriteName = "6_";
			break;
		case eMoumouType.eMoumouType06:
			m_spriteName = "7_";
			break;
		case eMoumouType.eMoumouType07:
			m_spriteName = "8_";
			break;
		case eMoumouType.eMoumouTypeInit:
		default:
			m_spriteName = "1_";
			break;
		}

		m_sprMoumou.spriteName = m_spriteName + "1";
	}

}
