using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] private float EnemySpeed;

    [SerializeField] private float EnemyRotationSpeed;

    private Rigidbody2D rb;

    private PlayerAwareController PlayerAwareScript;

    private Vector2 PlayerTargetDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerAwareScript = GetComponent<PlayerAwareController>();
    }

    void FixedUpdate()
    {

        TargetDirectionUpdate();
        TargetRotateUpdate();
        VelocitySet();
        
    }

    private void TargetDirectionUpdate()
    {
        if(PlayerAwareScript.PlayerAware)
        {

            PlayerTargetDirection = PlayerAwareScript.EnemyDirection;

        }
        else
        {
            PlayerTargetDirection = Vector2.zero;

        }


    }

    private void TargetRotateUpdate()
    {
        if(PlayerTargetDirection == Vector2.zero)
        {
            return;
        }

        Quaternion RotationTarget = Quaternion.LookRotation(transform.forward, PlayerTargetDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, RotationTarget, EnemyRotationSpeed * Time.deltaTime);

        rb.SetRotation(rotation);
    }

    private void VelocitySet()
    {
        if (PlayerTargetDirection == Vector2.zero)
        {
            rb.velocity = Vector2.zero;

        }
        else
        {
            rb.velocity = transform.up * EnemySpeed;
        }
    }

}
