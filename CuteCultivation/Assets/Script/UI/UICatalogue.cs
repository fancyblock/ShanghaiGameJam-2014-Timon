using UnityEngine;
using System.Collections;

public class UICatalogue : MonoBehaviour 
{
	public UICatalogueItem[] m_catalogueItems;

	void Awake() 
	{
        //TODO
    }

	// Use this for initialization
	void Start () 
	{
        transform.localPosition = new Vector3(0.0f, 800.0f, 0.0f);

		GlobalWork.Instance.CATALOGUE.CHANGED_CALLBACK = onCatalogueChanged;
		refreshCatalogue();
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

	/// <summary>
	/// callback when catalogue changed
	/// </summary>
	public void onCatalogueChanged( eMoumouType type )
	{
		refreshCatalogue();
	}

	/// <summary>
	/// catalogue changed 
	/// </summary>
	protected void refreshCatalogue()
	{
		foreach( UICatalogueItem item in m_catalogueItems )
		{
			if( GlobalWork.Instance.CATALOGUE.IsOwned( item.m_moumouType ) )
			{
				item.Unlock();
			}
			else
			{
				item.Lock();
			}
		}
	}

}
