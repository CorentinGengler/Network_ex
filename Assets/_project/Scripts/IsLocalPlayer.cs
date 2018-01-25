using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class IsLocalPlayer : NetworkBehaviour
{

    [SerializeField]
    private bool _isLocalPlayer;
    [SerializeField]
    private bool _isServer;
    private NetworkIdentity _networkIdentity;

    public UnityEvent _ifIsLocalPlayer;
    public UnityEvent _ifIsOtherPlayer;
    public UnityEvent _ifIsServer;

    public void Start()
    {
        _networkIdentity = GetComponent<NetworkIdentity>();
        _isLocalPlayer = _networkIdentity.isLocalPlayer;
        _isServer = _networkIdentity.isServer;

        if (_isLocalPlayer)
            _ifIsLocalPlayer.Invoke();
        else _ifIsOtherPlayer.Invoke();

        if (_isServer)
            _ifIsServer.Invoke();

    }

}
