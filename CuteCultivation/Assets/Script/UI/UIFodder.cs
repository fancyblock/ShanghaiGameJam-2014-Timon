using UnityEngine;
using System;
using System.Collections;

public class UIFodder : MonoBehaviour 
{
	public float m_acce;
	public float m_angleVelocity;
	public float m_lifeTime;

	protected float m_timer;
	protected float m_velocity;

	// Use this for initialization
	void Start () 
	{
		m_timer = 0.0f;
		m_velocity += m_acce;
	}
	
	// Update is called once per frame
	void Update () 
	{
		m_velocity += m_acce;
		transform.Translate( 0.0f, -m_velocity * Time.deltaTime, 0.0f, Space.World );
		transform.Rotate( 0.0f, 0.0f, m_angleVelocity );

		m_timer += Time.deltaTime;
		if( m_timer >= m_lifeTime )
		{
			Destroy( gameObject );
		}
	}
}
