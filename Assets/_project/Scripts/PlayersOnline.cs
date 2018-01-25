using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayersOnline  : MonoBehaviour
{
    public SyncPlayerInformation[] players;

    [Header("Debug")]
    public Text m_displayPlayers;

    public void Start()
    {
        InvokeRepeating("CheckForPlayer", 0, 1);
    }
    public void CheckForPlayer()
    {
        string playersName = "Players: \n";
        players = GameObject.FindObjectsOfType<SyncPlayerInformation>();
        if (players.Length > 0)
        {
            for (int i = 0; i < players.Length; i++)
            {
                playersName += players[i].m_name + "\n ";
            }
        }
        else
        {
            playersName = "no players";
        }
        m_displayPlayers.text = playersName;
        
    }

}
