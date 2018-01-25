using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class SyncOpenFire  : NetworkBehaviour
{

    #region Public Members
    public GameObject m_bulletPrefab;
    public Transform m_spawnTransform;

    public float m_minForce = 2f;
    public float m_maxForce = 20f;
    public float m_timeBeforeAutoDestruct = 5f;
    [Range(0, 1)]
    public float m_forceApplied = 0.5f;

    public GameObject m_instanciatedBullet;
    
    #endregion


    #region Public Void
    public void SetForceApplied(float force)
    {
        m_forceApplied = force;
    }

    public void Fire()
    {
        CmdFire(m_forceApplied);
    }
    [Command]
    void CmdFire(float forceApplied)
    {
        if (m_instanciatedBullet == null)
        {
            GameObject bullet = Instantiate(m_bulletPrefab, m_spawnTransform.position, m_spawnTransform.rotation);
            m_instanciatedBullet = bullet;
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * Mathf.Lerp(m_minForce, m_maxForce, forceApplied);
            NetworkServer.Spawn(bullet);
            Destroy(bullet, m_timeBeforeAutoDestruct);
        }
    }
    #endregion


    #region System


    void Update () 
    {
        if (!isLocalPlayer)
        {
            return;
        }


        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Fire!");
            Fire();
        }
    }
    
    #endregion

    #region Private Void

    #endregion

    #region Tools Debug And Utility

    #endregion


    #region Private And Protected Members

    #endregion

}
