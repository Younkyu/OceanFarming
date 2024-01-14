using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;
    private bool chase = false;
    private float enemyDistancing = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // enemy ai for tracking the player
        Vector3 targetPosition = target.transform.position;
        Vector3 direction = (targetPosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        moveDirection = direction;

        // stop following when enemy is at certain distance so they don't push the player        
        if (Vector3.Distance(transform.position, targetPosition) >= enemyDistancing) {
            // if enemy is further than '1' away from player, keep chasing
            chase = true;
        } else {
            chase = false;
        }
    }

    void FixedUpdate() {
        if(target && chase) {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
        else if (target && !chase) {
            rb.velocity = Vector2.zero;
        }
    }
}
