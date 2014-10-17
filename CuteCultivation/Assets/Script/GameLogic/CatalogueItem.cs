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
    /// moumou 
    /// </summary>
    public Moumou MOUMOU { get; set; }

    /// <summary>
    /// if is owned or not 
    /// </summary>
    public bool IS_OWNED { get; set; }

}
