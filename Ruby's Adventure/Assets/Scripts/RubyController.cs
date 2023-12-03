using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RubyController : MonoBehaviour
{

   [SerializeField] private GameObject gameOverPanel;
   [SerializeField] private Text restartandQuitText;
   [SerializeField] private GameObject WinnerPanel;
   [SerializeField] private GameObject Winnertext;
   [SerializeField] private GameObject WinnerPanelLvL2;
   [SerializeField] private GameObject WinnertextLvL2;


    public int scoreCount;
    public float speed = 3.0f;
    
    public int maxHealth = 5;
    
    public GameObject projectilePrefab;
    public ParticleSystem damgeEffect;

    public AudioClip throwSound;
    public AudioClip hitSound;
    
    public int health { get { return currentHealth; }}
    int currentHealth;
    
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;
    
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    
    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);
    
    AudioSource audioSource;
    private  bool Gameover = false;
    private bool hasWon = false;
    private bool canDisplayWinText = false;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

        currentHealth = maxHealth;

        audioSource = GetComponent<AudioSource>();


        gameOverPanel.SetActive(false);
        restartandQuitText.gameObject.SetActive(false);
        WinnerPanel.SetActive(false);
        Winnertext.gameObject.SetActive(false);
        WinnerPanelLvL2.SetActive(false);
        WinnertextLvL2.gameObject.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        
        if(Input.GetKeyDown(KeyCode.C))
        {
            Launch();
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                }
            }
        }
        if (Gameover == true)
        {
            StartCoroutine(GameOverSequence());

            if (Input.GetKeyDown(KeyCode.Q))
            {

                SceneManager.LoadScene("QuitGame");
            }

            if (Input.GetKeyDown(KeyCode.R))
                {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            

        }
       
        if (  UIManger.instance.scoreCount == 2 )
        {
             StartCoroutine(WinSequence());
          
            if (Input.GetKeyDown(KeyCode.R))
                {
                  SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }

            if (Input.GetKeyDown(KeyCode.Q))
                {
                  SceneManager.LoadScene("QuitGame");
                }

            if (Input.GetKeyDown(KeyCode.Y))
            {

                SceneManager.LoadScene("Level 2");
                WinnerPanel.SetActive(false);
                Winnertext.gameObject.SetActive(false);

            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MainMenu");
            }


        }

        if (BossMonster.BossHealth == 0) 
        {
            StartCoroutine(WinSequence2());

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                SceneManager.LoadScene("QuitGame");
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MainMenu");
            }


        }

    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {

        if (amount < 0)
        {
            if(currentHealth == 0)
            {
                rigidbody2d.simulated = false;
                Gameover = true;
              
            }

            animator.SetTrigger("Hit");
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
            PlaySound(hitSound);
            damgeEffect.Play();

           
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }
    
    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
        
        PlaySound(throwSound);
    } 
    
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }


    IEnumerator GameOverSequence()
    {
       gameOverPanel.SetActive(true);

        yield return new WaitForSeconds(2.0f);

        restartandQuitText.gameObject.SetActive(true);

    }

    IEnumerator WinSequence()
    {
        WinnerPanel.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        Winnertext.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Y))
        {

            SceneManager.LoadScene("Level 2");
            WinnerPanel.SetActive(false);
            Winnertext.gameObject.SetActive(false);

        }


    }

    IEnumerator WinSequence2()
    {
        WinnerPanelLvL2.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        WinnertextLvL2.gameObject.SetActive(true);

        


    }



}
