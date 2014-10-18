using UnityEngine;
using System.Collections;

public class CatalogueItem  
{
    /// <summary>
    /// constructor 
    /// </summary>
    public CatalogueItem()
    {
        IS_OWNED = false;
    }

	/// <summary>
	/// constructor
	/// </summary>
	/// <param name="type">Type.</param>
	/// <param name="isOwned">If set to <c>true</c> is owned.</param>
	public CatalogueItem( eMoumouType type, bool isOwned )
	{
		MOUMOU_TYPE = type;
		IS_OWNED = isOwned;
	}

    /// <summary>
    /// moumou 
    /// </summary>
    public eMoumouType MOUMOU_TYPE { get; set; }

    /// <summary>
    /// if is owned or not 
    /// </summary>
    public bool IS_OWNED { get; set; }

}
