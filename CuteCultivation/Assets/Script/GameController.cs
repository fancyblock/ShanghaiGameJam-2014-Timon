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


    public UIToggle[] m_toggleFodder;
    public UIFodderGen m_fodderGen;
    public UICatalogue m_uiCatalogue;

    protected eFodderType m_curFodder;

	void Awake() 
	{
        m_instance = this;
    }

	// Use this for initialization
	void Start () 
	{
        // start the game 
        StartCoroutine("startingGame");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO 
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
    }

}
