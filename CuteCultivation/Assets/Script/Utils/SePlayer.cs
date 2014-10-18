using UnityEngine;
using System;
using System.Collections;

public class SePlayer : MonoBehaviour 
{
	public AudioClip m_clipTransition;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	public void PlayTransition()
	{
		AudioSource.PlayClipAtPoint( m_clipTransition, Vector3.one );
	}

}
