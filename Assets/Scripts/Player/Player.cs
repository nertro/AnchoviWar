using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public bool HasAnchovi;
    public bool HasItem;
    public int ID;
    public bool IsInvinceble = false;
    public bool IsFast = false;
    public bool IsSlow = false;
    public float SlowTimer;
    public GameObject MyGUI;

    enum ItemType { Fast, Slow, RespawnBase, Invinceble, Banana, None }
    ItemType currentItem;
    float fastTimer;
    float invincebleTimer;
    float itemDelay;
    ThirdPersonControllerC controller;
    int score = 0;
    GameManager gameManager;
    private GameObject[] itemSpawns;

    void Start()
    {
        itemDelay = 5f;
        HasAnchovi = false;
        HasItem = false;
        currentItem = ItemType.None;
        controller = this.gameObject.GetComponent<ThirdPersonControllerC>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        itemSpawns = GameObject.FindGameObjectsWithTag("ItemSpawn");
    }

    void Update()
    {
        UpdateItem();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Anchovi")
        {
            HasAnchovi = true;
            MyGUI.GetComponent<GameGUI>().AnchoviSprite.SetActive(true);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Item" &! HasItem)
        {
            PickUpItem();
            HasItem = true;
            for (int i = 0; i < itemSpawns.Length; i++)
            {
                if (itemSpawns[i].transform.position == other.transform.position)
                {
                    itemSpawns[i].GetComponent<SpawnPoint>().HasItem = false;
                }
            }
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Pizza" && HasAnchovi)
        {
            AddOneToScore();
            MyGUI.GetComponent<GameGUI>().AnchoviSprite.SetActive(false);
            HasAnchovi = false;
            gameManager.ReSpawnPizza();
            gameManager.SpawnAnchovis(GameObject.FindGameObjectWithTag("AnchoviBase").transform.position);
        }
    }

    void PickUpItem()
    {
            int rand = Random.Range(0, 5);
            ItemType newType = (ItemType)rand;
            currentItem = newType;
            MyGUI.GetComponent<GameGUI>().ActivateItemSprite((int)currentItem);
    }

    void UseItem()
    {
        if (currentItem == ItemType.Fast)
        {
            IsFast = true;
            controller.walkSpeed *= 2;
            fastTimer = 0;
            if (IsSlow)
            {
                IsSlow = false;
                controller.walkSpeed *= 2;
            }
            IsInvinceble = false;
        }
        else if (currentItem == ItemType.Slow)
        {
            for (int i = 0; i < gameManager.Players.Length; i++)
            {
                if (gameManager.Players[i] != this.gameObject &! gameManager.Players[i].GetComponent<Player>().IsInvinceble)
                {
                    gameManager.Players[i].GetComponent<ThirdPersonControllerC>().walkSpeed /= 2;
                    gameManager.Players[i].GetComponent<Player>().IsSlow = true;
                    gameManager.Players[i].GetComponent<Player>().SlowTimer = 0;
                    if (gameManager.Players[i].GetComponent<Player>().IsFast)
                    {
                        gameManager.Players[i].GetComponent<Player>().IsFast = false;
                        gameManager.Players[i].GetComponent<ThirdPersonControllerC>().walkSpeed /= 2;
                    }
                }
            }
        }
        else if (currentItem == ItemType.RespawnBase)
        {
            gameManager.ReSpawnPizza();
        }
        else if (currentItem == ItemType.Invinceble)
        {
            IsInvinceble = true;
        }
        else if (currentItem == ItemType.Banana)
        {
            for (int i = 0; i < gameManager.Players.Length; i++)
            {
                if (gameManager.Players[i].GetComponent<Player>().HasAnchovi 
                    && gameManager.Players[i] != this.gameObject
                    &! gameManager.Players[i].GetComponent<Player>().IsInvinceble)
                {
                    gameManager.Players[i].GetComponent<Player>().MyGUI.GetComponent<GameGUI>().AnchoviSprite.SetActive(false);
                    gameManager.Players[i].GetComponent<Player>().HasAnchovi = false;
                    gameManager.SpawnAnchovis(gameManager.Players[i].transform.position);
                    gameManager.SpawnPlayer(i);
                }
            }
        }

        MyGUI.GetComponent<GameGUI>().DeactivateItemSprite((int)currentItem);
        currentItem = ItemType.None;
        HasItem = false;
    }

    void UpdateItem()
    {
        if (Input.GetAxis("Fire1") >= 1 && HasItem)
        {
            UseItem();
        }
        if (IsFast)
        {
            fastTimer += Time.deltaTime;
            if (fastTimer >= itemDelay)
            {
                IsFast = false;
                controller.walkSpeed /= 2;
                fastTimer = 0;
            }
        }
        else if (IsSlow)
        {
            SlowTimer += Time.deltaTime;
            if (SlowTimer >= itemDelay)
            {
                IsSlow = false;
                controller.walkSpeed *= 2;
                SlowTimer = 0;
            }
        }
        else if (IsInvinceble)
        {
            invincebleTimer += Time.deltaTime;
            if (invincebleTimer >= itemDelay)
            {
                IsInvinceble = false;
                invincebleTimer = 0;
            }
        }
    }

    public void AddOneToScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }
}
