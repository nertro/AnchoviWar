using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
    //public bool showPlush = false;
    //public bool fadePlush = false;
    //public GameObject hitmarker;

    //private float hitmarkerTimer = 0;
    //private GameObject activePlush;
    //private GameObject scoreLabel;
    //private GameObject bulletLabel;
    //private GameManager gameManager;

    //void Start()
    //{
    //    activePlush = GameObject.FindGameObjectWithTag("Plush");
    //    activePlush.GetComponent<UISprite>().alpha = 0;
    //    scoreLabel = GameObject.FindGameObjectWithTag("Points");
    //    bulletLabel = GameObject.FindGameObjectWithTag("BulletsLeft");
    //    gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    //}

    //void Update () {
    //    if (showPlush)
    //    {
    //        AddPlushToScreen(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().health);
    //    }
    //    if (fadePlush)
    //    {
    //        FadePlushAway();
    //    }
    //    if (hitmarker.activeInHierarchy) 
    //    {
    //        hitmarkerTimer += Time.deltaTime;
    //        if (hitmarkerTimer > 0.2f) 
    //        {
    //            hitmarker.SetActive(false);
    //            hitmarkerTimer = 0;
    //        }
    //    }
    //    UpdateScore();
    //    if(bulletLabel.activeInHierarchy)
    //    {
    //        UpdateBullets();
    //    }
    //}

    //void AddPlushToScreen(int playerHealth)
    //{
    //    if (playerHealth > 60)
    //    {
    //        activePlush.GetComponent<UISprite>().spriteName = "Plush_Phase_1";
    //    }
    //    else if (playerHealth > 30)
    //    {
    //        activePlush.GetComponent<UISprite>().spriteName = "Plush_Phase_2";
    //    }
    //    else if (playerHealth > 10)
    //    {
    //        activePlush.GetComponent<UISprite>().spriteName = "Plush_Phase_3";
    //    }
    //    else if (playerHealth < 10)
    //    {
    //        activePlush.GetComponent<UISprite>().spriteName = "Plush_Phase_4";
    //    }
    //    activePlush.GetComponent<Animator>().Play("NotHit");
    //    activePlush.GetComponent<UISprite>().alpha = 0.8f;
    //}

    //void FadePlushAway()
    //{
    //    activePlush.GetComponent<Animator>().Play("fadeOutTest");
    //    fadePlush = false;
    //}

    //void UpdateScore()
    //{
    //    scoreLabel.GetComponent<UILabel>().text = gameManager.GetScore().ToString();
    //}

    //void UpdateBullets()
    //{
    //    bulletLabel.GetComponent<UILabel>().text = gameManager.BulletsLeft.ToString();
    //}
}
