using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public Animator playerAnimator;
    public Animator gameOverAnimator;
    public EnemyMovement enemyMovement;
    public LightsaberManager lightsaberManager;
    public PlayerMovement playerMovement;

    private int newDeathAnimThatIHaveToImplementInThisCode = 0;

    IEnumerator OnTriggerEnter2D(Collider2D hitInfo)
    {
        
        if (hitInfo.gameObject.CompareTag("EnemyFatal") || hitInfo.gameObject.CompareTag("ChutesBrume")) //player dead
        {
            if (lightsaberManager.hitting)
            {
                if (hitInfo.gameObject.layer == 10) Destroy(hitInfo.gameObject);
            }
            else
            {
                if (hitInfo.gameObject.name == "enemySprite")
                {
                    GetComponent<Transform>().position = new Vector3(0.5f, 0f, 0f) + hitInfo.GetComponent<Transform>().position;
                }
                else if (hitInfo.gameObject.CompareTag("ChutesBrume") || (hitInfo.gameObject.name.Substring(0, 5) == "Ronce"))
                {
                    GetComponent<Transform>().position = hitInfo.GetComponent<BoxCollider2D>().bounds.center;
                    if (hitInfo.gameObject.CompareTag("ChutesBrume"))
                    {
                        newDeathAnimThatIHaveToImplementInThisCode = 2;
                    } else
                    {
                        newDeathAnimThatIHaveToImplementInThisCode = 1;
                    }
                }
                else
                {
                    GetComponent<Transform>().position = hitInfo.GetComponent<Transform>().position;
                }

                GetComponent<AudioSource>().Play();
                GetComponent<PlayerMovement>().enabled = false;
                GetComponent<Rigidbody2D>().gravityScale = 0;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<CharacterController2D>().enabled = false;
                enemyMovement.enabled = false;

                if (newDeathAnimThatIHaveToImplementInThisCode == 0)
                {
                    playerAnimator.Play("Died");
                }
                else if (newDeathAnimThatIHaveToImplementInThisCode == 1)
                {
                    playerAnimator.Play("mortAnim");
                }
                else if (newDeathAnimThatIHaveToImplementInThisCode == 2)
                {
                    playerAnimator.Play("mortAnimEau");
                }

                Animator obstacleAnim = hitInfo.gameObject.GetComponent<Animator>();
                if (obstacleAnim != null)
                {
                    obstacleAnim.SetTrigger("hasKilled");
                }

                yield return new WaitForSeconds(4f);

                gameOverAnimator.SetTrigger("isDead");
            }

        }
        else if (hitInfo.gameObject.CompareTag("EnemySlow")) //player slowed down
        {
            hitInfo.GetComponent<AudioSource>().Play();
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        GetComponent<PlayerMovement>().runSpeed = 10;
        playerAnimator.SetBool("isHurting", true);
        yield return new WaitForSeconds(1.5f);
        GetComponent<PlayerMovement>().runSpeed = 30;
        playerAnimator.SetBool("isHurting", false);
    }


}
