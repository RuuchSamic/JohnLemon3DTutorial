using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;

    private int enemyState;
    private bool m_IsPlayerInRange;

    public enum state { patrol, chase, attack };

    private void Start()
    {
        enemyState = (int)state.patrol;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (m_IsPlayerInRange)
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);
            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))
            {
                if (raycastHit.collider.transform == player && enemyState == (int)state.patrol)
                {
                    //gameEnding.CaughtPlayer();
                    enemyState = (int)state.chase;
                }
            }
        }
    }

    public int GetState()
    {
        return enemyState;
    }

    public void SetState(int newState)
    {
        enemyState = newState;
    }
}
