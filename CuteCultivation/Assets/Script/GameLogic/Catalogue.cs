using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Catalogue 
{
    protected List<CatalogueItem> m_itemList;

    /// <summary>
    /// constructor 
    /// </summary>
    public Catalogue()
    {
        m_itemList = new List<CatalogueItem>();
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
        //TODO 

        return false;
    }

    /// <summary>
    /// make as owned 
    /// </summary>
    /// <param name="type"></param>
    public void MakeAsOwned( eMoumouType type )
    {
        //TODO 
    }

}
