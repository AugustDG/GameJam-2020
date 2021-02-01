using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float enemyMovementSpeed;
    [SerializeField] private GameMenu gameMenu;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = playerMovement.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameMenu.tutorialStage == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, enemyMovementSpeed * Time.deltaTime);
        }
    }
}
