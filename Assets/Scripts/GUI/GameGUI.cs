using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {
    public GameObject AnchoviSprite;
    public GameObject Owner;
    public GameObject[] Items = new GameObject[5];
    public GameObject scoreLabel;

    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreLabel.GetComponent<UILabel>().text = Owner.GetComponent<Player>().GetScore().ToString();
    }

    public void ActivateItemSprite(int ID)
    {
        Items[ID].SetActive(true);
    }

    public void DeactivateItemSprite(int ID)
    {
        Items[ID].SetActive(false);
    }
}
