using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform player;
    public Transform enemy;
    //public EnemyStats enemyStats;
    public StopWatch attackInterval;
    public StopWatch messageInterval;

    private int damage = 25;
    private float timeToNextAttack = 4.0f;
    private float playerToEnemyMaximumDistance = 1.0f;
    private float playerToEnemyActualDistance;
    private float errorMessageInterval = 5.0f;
    private bool m_IsEnemyInAttackArea = false;
    private bool attackMode = false;
    private string tooFar = "You are too far away!";
    private string faceEnemy = "Enemy must be in front of you!";

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackMode)
        {
            playerToEnemyActualDistance = Vector3.Distance(player.position, enemy.position);

            if (playerToEnemyActualDistance > playerToEnemyMaximumDistance && messageInterval.repeatTime(errorMessageInterval))
            {
                Debug.Log(tooFar);
            }

            else if (!m_IsEnemyInAttackArea && messageInterval.repeatTime(errorMessageInterval))
            {
                Debug.Log(faceEnemy);
            }

            else
            {
                //Do DMG over time
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsEnemyInAttackArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsEnemyInAttackArea = false;
        }
    }
}
