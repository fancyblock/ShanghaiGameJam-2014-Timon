using UnityEngine;
using System.Collections;

public class ScreenSettings : MonoBehaviour 
{
    public int m_width;
    public int m_height;
    public int m_fps;

	void Awake() 
	{
		Screen.SetResolution(m_width, m_height, false, m_fps);
    }

	// Use this for initialization
	void Start () 
	{
		//TODO 
	}

}
