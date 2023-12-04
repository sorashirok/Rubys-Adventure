using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossMonster : MonoBehaviour
{
    [SerializeField] private GameObject WinnerPanel;
    [SerializeField] private GameObject Winnertext;

   public static int BossHealth = 10;

    // Start is called before the first frame update
    void Start()
    {
      
        WinnerPanel.SetActive(false);
        Winnertext.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Projectile cogProjectile = other.gameObject.GetComponent<Projectile>();
        if (cogProjectile != null)
        {
            // Assuming that the cog is the projectile thrown by Ruby
            BossHealth--;
            Debug.Log("boss health is at : " + BossHealth);

           
            Destroy(cogProjectile.gameObject);
        }
    }

    


    // Update is called once per frame
    void Update()
    {
     

        if (BossHealth == 0)
        {
            Destroy(gameObject);
            WinnerPanel.SetActive(true);
            Winnertext.gameObject.SetActive(true);
        }
        
    }

    

}
