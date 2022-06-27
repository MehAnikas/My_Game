using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Anika_Player : MonoBehaviour
{
    [Header("Ходьба")]
    public int speed;
    public int speedFast;
    Animator anim;
    public GameObject player;
    BoxCollider2D boxCollider;

    [Header("Прыжок")]
    public float buttonTime = 0.3f;
    public float jumpAmount = 20;
    float jumpTime;
    public Rigidbody2D rb;
    bool jumping;
    public bool OnGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    [Header("Щит")]
    public GameObject shield;
    private bool Xpos;

    [Header("Квест")]
    public int razhresh;
    public int orujie = 1;

    [Header("Атака")]
    public GameObject attackPos_R;
    public Transform pos_R;
    public Transform pos_L;

    [Header("Игрок")]
    public float health = 6;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHeart;
    public int heal;
    public float StartTime;
    private float EndTime;
    public int coins = 0;
    public TextMeshProUGUI coini;
    public TextMeshProUGUI Aura_Hunter_txt;
    public int aura_hunter;
    public int zapolnenie;



    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        Xpos = false;
        razhresh = PlayerPrefs.GetInt("Razresh");
        orujie = PlayerPrefs.GetInt("Oryzhie");
        coins = PlayerPrefs.GetInt("Coins");
        aura_hunter = PlayerPrefs.GetInt("Hunter");
        zapolnenie = PlayerPrefs.GetInt("Zapolnenie");
        coini.text = coins.ToString();
        Aura_Hunter_txt.text = aura_hunter.ToString();
        transform.position = new Vector2(PlayerPrefs.GetFloat("Xpos"), PlayerPrefs.GetFloat("Ypos"));
        TriggerMonolog.Do = true;
        attackPos_R.GetComponent<CircleCollider2D>().enabled = false;

    }

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Razresh"))
        {
            PlayerPrefs.SetInt("Razresh", 0);
        }
        if (!PlayerPrefs.HasKey("Oryzhie"))
        {
            PlayerPrefs.SetInt("Oryzhie", 1);
        }
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
        if (!PlayerPrefs.HasKey("Hunter"))
        {
            PlayerPrefs.SetInt("Hunter", 0);
        }
        if (!PlayerPrefs.HasKey("Zapolnenie"))
        {
            PlayerPrefs.SetInt("Zapolnenie", 0);
        }
    }


    void Update()
    {
        Aura_Hunter_txt.text = aura_hunter.ToString();
        coini.text = coins.ToString();
        PlayerPrefs.SetInt("Hunter", aura_hunter);
        if (Input.GetKey(KeyCode.S) && TriggerMonolog.Do==true)
        {
            anim.SetInteger("Sit", 0);
            boxCollider.size = new Vector2(2.4f, 2.5f);
            boxCollider.offset = new Vector2(0, -1.6f);
        }
        else if (!Input.GetKey(KeyCode.S) && TriggerMonolog.Do == true)
        {
                anim.SetInteger("Sit", 1);
                anim.SetInteger("Up", 0);
                boxCollider.size = new Vector2(2.4f, 5.76f);
                boxCollider.offset = new Vector2(0, 0);
           
            if (Input.GetKey(KeyCode.D))
            {
                anim.SetInteger("Walk", 0);
                transform.position += transform.right * speed * Time.deltaTime;
                Xpos = false;
                attackPos_R.transform.position = pos_R.position;
            }
            else
            {
                anim.SetInteger("Walk", 1);
            }

            if (Input.GetKey(KeyCode.A))
            {
                anim.SetInteger("Walk_L", 0);
                transform.position -= transform.right * speed * Time.deltaTime;
                Xpos = true;
                attackPos_R.transform.position = pos_L.position;

            }
            else
            {
                anim.SetInteger("Walk_L", 1);
            }

            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetInteger("Run", 0);
                transform.position += transform.right * speedFast * Time.deltaTime;
            }
            else
            {
                anim.SetInteger("Run", 1);
            }


            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetInteger("Run_L", 0);
                transform.position -= transform.right * speedFast * Time.deltaTime;
            }
            else
            {
                anim.SetInteger("Run_L", 1);
            }
            Jump();
            CheckingGround();

            if (razhresh == 1)
            {
                Shield();
                Attack();
            }
            else
            {
                anim.SetInteger("Block", 1);
                anim.SetInteger("Attack", 1);
                anim.SetInteger("MegaAttack", 1);
            }

        }

        else
        {
            anim.SetInteger("Run_L", 1);
            anim.SetInteger("Run", 1);
            anim.SetInteger("Walk", 1);
            anim.SetInteger("Walk_L", 1);
        }


        
    }

    public void onAttack_R()
    {
        attackPos_R.GetComponent<CircleCollider2D>().enabled = true;
        StartCoroutine(Stop_Attack());
    }

    
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Xpos)
            {
                if (orujie == 1)
                {
                    anim.SetInteger("Attack", 0);
                }
                else if (orujie == 2)
                {
                    anim.SetInteger("MegaAttack", 0);
                }
            }
            else
            {
                if (orujie == 1)
                {
                    anim.SetInteger("Attack", 0);
                }
                else if (orujie == 2)
                {
                    anim.SetInteger("MegaAttack", 0);
                }
            }
        }
        else
        {
            anim.SetInteger("Attack", 1);
            anim.SetInteger("MegaAttack", 1);
        }
    }


    public void onAttack_L()
    {
        StartCoroutine(Stop_Attack());
        attackPos_R.GetComponent<CircleCollider2D>().enabled = true;
    }

    void Shield()
    {
        if (Input.GetMouseButton(1))
        {
            if (Xpos)
            {
                anim.SetInteger("Block", 0);
                shield.SetActive(true);
            }
            else
            {
                anim.SetInteger("Block", 0);
                shield.SetActive(true);
            }
            boxCollider.size = new Vector2(2.4f, 4.8f);
            boxCollider.offset = new Vector2(-0.3f, -0.06f);
        }
        else
        {
            shield.SetActive(false);
            anim.SetInteger("Block", 1);
            boxCollider.size = new Vector2(2.4f, 5.76f);
            boxCollider.offset = new Vector2(0, 0);  
        }
    }


    void Jump()
    {
        if ((Input.GetKeyDown(KeyCode.W) && OnGround) ^ (Input.GetKeyDown(KeyCode.Space)&& OnGround))
        {
            jumping = true;
            jumpTime = 0;
        }
        else
        {
            anim.SetInteger("Jump", 1);
        }
        if (jumping)
        {
            anim.SetInteger("Jump", 0);
            rb.velocity = new Vector2(rb.velocity.x, jumpAmount);
            jumpTime += Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Space) | jumpTime > buttonTime)
        {
            jumping = false;
        }
    }


    void CheckingGround()
    {
        OnGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }    

    IEnumerator Stop_Attack()
    {
        yield return new WaitForSeconds(0.2f);
        attackPos_R.GetComponent<CircleCollider2D>().enabled = false;
    }

    private void FixedUpdate()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        if (health < 6)
        {
            EndTime -= Time.deltaTime;
            if (EndTime <= 0)
            {
                health += heal;
                EndTime = StartTime;
            }
        }
        if (health <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }

        }
    }
}
