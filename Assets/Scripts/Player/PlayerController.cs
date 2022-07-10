using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private Shooter shooter;
    private Rigidbody2D rig;
    private AudioSource playerSound;
    private bool isAlive;
    private EnemyController enemyController;
    private SpriteRenderer playerSprite;

    [SerializeField] private int playerLife;
    [SerializeField] ParticleSystem particles;


    private void Awake()
    {
        shooter = GetComponentInChildren<Shooter>();
        rig = GetComponent<Rigidbody2D>();
        enemyController = FindObjectOfType<EnemyController>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        isAlive = true;
        UIController.instance.SetLife(playerLife);
    }

    private void Update()
    {
        Shooting();
        playerSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (isAlive)
        {
            float movX = Input.GetAxis("Horizontal");
            float movY = Input.GetAxis("Vertical");

            rig.velocity = new Vector2(movX, movY) * speed;
        }
    }

    private void Shooting()
    {
       if (Input.GetMouseButtonDown(0))
       {
            playerSound.Play ();
            shooter.Shooting();
       }
    }

    public void Hurt(int hurt)
    {
        playerLife -= hurt;
        UIController.instance.SetLife(playerLife);

        if (playerLife <= 0)
        {
            isAlive = false;
            UIController.instance.EndGameText("Game Over!");
            enemyController.PlayerIsdead();
            playerSprite.enabled = false;
            particles.Play();
        }
     
    }
}
