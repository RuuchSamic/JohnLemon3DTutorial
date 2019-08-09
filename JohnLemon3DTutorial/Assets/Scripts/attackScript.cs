using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public Observer observeObj;
    public Transform player;
    public PlayerStats playerStats;

    private int damage = 20;
    private float prevAtkTime = 0;
    private float timeToNextAttack = 3.0f;
    private bool m_IsPlayerInAttackRange = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInAttackRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInAttackRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInAttackRange)
        {
            //2 is attack state
            observeObj.SetState(2);
            if (Time.time - prevAtkTime > timeToNextAttack)
            {
                playerStats.damagePlayer(damage);
                prevAtkTime = Time.time;
            }
        }
        else
        {
            //Only want the bad guy to chase again if player was being attack and then left the attack range.
            if (observeObj.GetState() == 2)
            {
                //1 is chase state
                observeObj.SetState(1);
            }
        }
    }
}
