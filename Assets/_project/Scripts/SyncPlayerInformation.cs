using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SyncPlayerInformation  : NetworkBehaviour
{

    #region Public Members
    [SyncVar]
    public string m_name;
    
    public TextMesh m_displayPlayerName;

    public InputField m_fieldToHide;

    public void SetNameTo(string name)
    {
        CmdChangeName(name);
        m_fieldToHide.gameObject.SetActive(false);
        m_displayPlayerName.text = name;
    }

    [Command]
    public void CmdChangeName(string name)
    {
        Debug.Log("SERVER CHANGE NAME : " + name);
        m_name = name;
        m_displayPlayerName.text = name;
    }
    #endregion


    #region Public Void

    #endregion


    #region System


    #endregion

    #region Private Void

    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Members

    #endregion

}
