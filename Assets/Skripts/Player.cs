using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource damageSound;
    [SerializeField] private AudioSource missAttack;
    [SerializeField] private AudioSource attackMob;
    [SerializeField] private float speed = 3f; 
    [SerializeField] private int health; 
    [SerializeField] private float jumpForce = 15f;
    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;
    
    
    public static Player Instance { get; set; }
    
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    
    private bool isGrounded = false;
    public bool isAttacking = false;
    public bool isRecharged = true;

    public Transform attackpos;
    public float attackRange;
    public LayerMask enemy;

    private int lives;
    private const string menuSceneName = "MenuScenes"; 

    private void Awake()
    {
        lives = 5;
        health = lives;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        Instance = this;
        isRecharged = true;
    }

    private void FixedUpdate()
        {
            CheckGround();
        }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 6;
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = 3;
            }
        }

        if (isGrounded && !isAttacking)
        {
            State = States.idle;
        }

        if (!isAttacking && Input.GetButton("Horizontal"))
        {
            Run();
        }

        if (!isAttacking && isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        if (health > lives)
        {
            health = lives;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = aliveHeart;
            }
            else
            {
                hearts[i].sprite = deadHeart;
            }

            if (i < lives)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    private void Run()
    {
        if (isGrounded)
        {
            State = States.run;
        }

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(
            transform.position,
             transform.position + direction,
            speed * Time.deltaTime
        );

        sprite.flipX = direction.x < 0.0f;
    }
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        jumpSound.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackpos.position, attackRange);
    }
    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        isGrounded = colliders.Length > 1;

        if (!isGrounded)
        {
            State = States.jump;
        }
    }

    private States State
    {
        get => (States)anim.GetInteger("state");
        set => anim.SetInteger("state", (int)value);
    }
    private void Attack()
    {
        if (isGrounded && isRecharged)
        {
            State = States.attack;
            isAttacking = true;
            isRecharged = false;

            StartCoroutine(AttackAnimation());
            StartCoroutine(AttackCoolDown());
        }
    }
    private void OnAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackpos.position, attackRange, enemy);

        if (colliders.Length == 0)
        {
            missAttack.Play();
        }
        else
        {
            attackMob.Play();

            foreach (Collider2D collider in colliders)
            {
                Entity entity = collider.GetComponent<Entity>();

                if (entity != null)
                {
                    entity.TakeDamage(1);
                    StartCoroutine(EnemyOnAttack(collider));
                }
            }
        }
    }
    public void GetDamage()
    {
        lives--;
        damageSound.Play();
        Debug.Log(lives);

        if (lives <= 0)
        {
            DieAndLoadMenuScene();
        }
    }

    private void DieAndLoadMenuScene()
    {
        Debug.Log(" ddied!");
        StartCoroutine(LoadMenuSceneAfterDelay()); 
    }

    private IEnumerator LoadMenuSceneAfterDelay()
    {
        yield return new WaitForSeconds(2f); // это задержка сцены
        SceneManager.LoadScene(menuSceneName); 
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(0.4f);
        isAttacking = false;
    }
    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        isRecharged = true;
    }

    private IEnumerator EnemyOnAttack(Collider2D enemy)
    {
        SpriteRenderer enemyColor = enemy.GetComponentInChildren<SpriteRenderer>();
        enemyColor.color = new Color(1f, 0.4375f, 0.4375f);
        yield return new WaitForSeconds(0.2f);
        enemyColor.color = new Color(1, 1, 1);
    }
}

public enum States
{
    idle,
    run,
    jump,
    attack
}