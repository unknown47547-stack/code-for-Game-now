using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController2D : MonoBehaviour
{
    [SerializeField] float MovementDirection;
    [SerializeField] float Speed = 7;
    [SerializeField] float JumpStrength = 30f;
    [SerializeField] float DashStrength = 30f;
    [SerializeField] bool CanDash = true;
    [SerializeField] bool IsDashing = false;
    [SerializeField] bool sacDash = false;



    [SerializeField] Rigidbody2D Rigidbody;
    [SerializeField] Transform GroundCheck;
    [SerializeField] LayerMask Ground;
    void Update()
    {

        MovementDirection = Input.GetAxis("Horizontal");

            if (Input.GetKeyDown(KeyCode.A)) 
            {
                Rigidbody.velocity = new Vector2(-1 * Speed, Rigidbody.velocity.y);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Rigidbody.velocity = new Vector2(1 * Speed, Rigidbody.velocity.y);
            }
        if (Input.GetKeyDown(KeyCode.Space) && (CheckGround()))
        {
           
            Rigidbody.AddForce(transform.up * JumpStrength, ForceMode2D.Impulse);
           
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            if(sacDash=false)
            StartCoroutine(Dash());
        }

        CheckGround();
    }

    private void FixedUpdate()
    {
        if (IsDashing)
        {
            return;
        }
        Rigidbody.velocity = new Vector2(MovementDirection * Speed, Rigidbody.velocity.y);
    }

    bool CheckGround()
    {
        if (Physics2D.OverlapCircle(GroundCheck.position, .25f, Ground))
        {
            return true;
        }
        return false;
    }

    int Direction()
    {
        if (MovementDirection > 0)
        {
            return 1;
        }
        if (MovementDirection < 0)
        {
            return -1;
        }
        return 0;
    }

    IEnumerator Dash()
    {
        CanDash = false;
        IsDashing = true;
        Rigidbody.gravityScale = 0;
        Rigidbody.velocity = new Vector2(Direction() * DashStrength, 0f);
        yield return new WaitForSeconds(.5f);
        Rigidbody.gravityScale = 1;
        IsDashing = false;
        CanDash = true;
    }
}

