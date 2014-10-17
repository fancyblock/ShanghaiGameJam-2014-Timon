using UnityEngine;
using System.Collections;

public class UICatalogue : MonoBehaviour 
{
	void Awake() 
	{
        //TODO
    }

	// Use this for initialization
	void Start () 
	{
        transform.localPosition = new Vector3(0.0f, 800.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		//TODO 
	}

    /// <summary>
    /// hide the catalogue 
    /// </summary>
    public void onBack()
    {
        Show(false);
    }

    /// <summary>
    /// show or hide the catalogue 
    /// </summary>
    /// <param name="show"></param>
	public void Show( bool show )
    {
        Debug.Log("[UICatalogue]: " + show.ToString() );

        if( show )
        {
            TweenPosition.Begin(gameObject, 0.28f, Vector3.zero);
        }
        else
        {
            TweenPosition.Begin(gameObject, 0.28f, new Vector3( 0.0f, 800.0f, 0.0f) );
        }
    }

}
