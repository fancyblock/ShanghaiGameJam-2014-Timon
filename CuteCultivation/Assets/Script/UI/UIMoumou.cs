using UnityEngine;
using System;
using System.Collections;

public class UIMoumou : MonoBehaviour 
{
	public UISprite m_sprMoumou;
	public Animator m_animator;

	protected bool m_inAnimation;
	protected eMoumouType m_nextMoumouType;

	// Use this for initialization
	void Start () 
	{
		m_inAnimation = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO 
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
		//TODO 
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

}
