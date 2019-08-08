using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{

    public Transform player;
    public Observer observeObj;

    private bool m_IsPlayerInAttackRange;

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
