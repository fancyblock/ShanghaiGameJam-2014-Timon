using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


public class Catalogue 
{
	public Action<eMoumouType> CHANGED_CALLBACK { get; set; }

    protected List<CatalogueItem> m_itemList;

    /// <summary>
    /// constructor 
    /// </summary>
    public Catalogue()
    {
        m_itemList = new List<CatalogueItem>();

		for( int i = (int)eMoumouType.eMoumouTypeInit; i < (int)eMoumouType.eMoumouTypeMax; i++ )
		{
			m_itemList.Add( new CatalogueItem( (eMoumouType)i, false ) );
		}
		MakeAsOwned( eMoumouType.eMoumouTypeInit );
    }

    /// <summary>
    /// retuen the count of all the moumou 
    /// </summary>
    public int MOUMOU_COUNT
    {
        get
        {
            return m_itemList.Count;
        }
    }

    /// <summary>
    /// if this moumou is owned or not 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool IsOwned( eMoumouType type )
    {
        foreach( CatalogueItem item in m_itemList )
		{
			if( item.MOUMOU_TYPE == type )
			{
				return item.IS_OWNED;
			}
		}

        return false;
    }

    /// <summary>
    /// make as owned 
    /// </summary>
    /// <param name="type"></param>
    public void MakeAsOwned( eMoumouType type )
    {
		Debug.Log( "[Catalogue]: MakeAsOwned => " + type.ToString() );

        foreach( CatalogueItem item in m_itemList )
		{
			if( item.MOUMOU_TYPE == type )
			{
				item.IS_OWNED = true;

				break;
			}
		}

		if( CHANGED_CALLBACK != null )
		{
			CHANGED_CALLBACK( type );
		}
    }

	/// <summary>
	/// is collect done or not 
	/// </summary>
	/// <returns><c>true</c> if this instance is collect done; otherwise, <c>false</c>.</returns>
	public bool IsCollectDone()
	{
		foreach( CatalogueItem item in m_itemList )
		{
			if( item.IS_OWNED == false )
			{
				return false;
			}
		}

		return true;
	}

}
