using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwareController : MonoBehaviour
{

    public bool PlayerAware {  get; private set; } // Allows others scripts to use this
    public Vector2 EnemyDirection { get; private set; }

    [SerializeField]
    private float DistanceFromPlayer;

    private Transform PlayerTransform;


    private void Awake()
    {
        PlayerTransform = FindObjectOfType<PlayerMovementTopDown>().transform;
    }
    void Update()
    {
        Vector2 EnemyDistanceToPlayerVector = PlayerTransform.position - transform.position; // finds where player is
        EnemyDirection = EnemyDistanceToPlayerVector.normalized;

        if(EnemyDistanceToPlayerVector.magnitude <= DistanceFromPlayer)
        {
            PlayerAware = true;
        }
        else
        {
            PlayerAware = false;
        }
    }
}
