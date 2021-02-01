using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator playerAnimator;
    public BoxCollider2D standBoxTrigger;
    public BoxCollider2D standBoxCollider;
    public CircleCollider2D playerCircle;
    public CircleCollider2D triggerColliderCrouch;
    public TMP_Text deathText;

    public float runSpeed = 30f;

    float horizontalMove;
    bool jump;
    bool crouch;

    void Update()
    {
        deathText.text = Globals.deathCounter.ToString();
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        playerAnimator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && !jump)
        {
            jump = true;
            playerAnimator.SetBool("isJump", true);        
        }
        else if (Input.GetButton("Crouch"))
        {
            crouch = true;
            standBoxTrigger.enabled = false;
            standBoxCollider.enabled = false;
            playerCircle.offset = new Vector2 (0.11f, 0f);
            playerCircle.radius = 0.436f;
            triggerColliderCrouch.offset = new Vector2(0.11f, 0f);
            triggerColliderCrouch.radius = 0.44f;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            standBoxTrigger.enabled = true;
            standBoxCollider.enabled = true;
            playerCircle.offset = new Vector2(0f, -0.26f);
            playerCircle.radius = 0.336f;
            triggerColliderCrouch.offset = new Vector2(0f, -0.26f);
            triggerColliderCrouch.radius = 0.34f;
        }
    }

    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        playerAnimator.SetBool("isJump", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        playerAnimator.SetBool("isCrouch", isCrouching);
    }

    public void IncreaseCounter()
    {
        Globals.deathCounter++;
    }
}
