using UnityEngine;
using System;
using System.Collections;

public class UICatalogueItem : MonoBehaviour 
{
	public eMoumouType m_moumouType;
	public GameObject m_lockMask;

	// Use this for initialization
	void Start () 
	{
		//TODO 
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO 
	}

	/// <summary>
	/// lock this item
	/// </summary>
	public void Lock()
	{
		m_lockMask.SetActive(true);
	}

	/// <summary>
	/// unlock the item
	/// </summary>
	public void Unlock()
	{
		m_lockMask.SetActive(false);
	}
}
