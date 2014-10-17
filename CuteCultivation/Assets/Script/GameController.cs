using UnityEngine;
using System.Collections;

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

	void Awake() 
	{
        m_instance = this;
    }

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

	void OnDestroy() 
	{
        //TODO 
    }
}
