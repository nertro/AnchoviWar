using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject Anchovis;
    public GameObject Pizza;
    public GameObject[] Players;
    public GameObject[] PlayerBases;

    private GameObject AnchoviBase;
    private GameObject[] pizzaBases;
    private GameObject pizza;

	void Start () {
        Players = GameObject.FindGameObjectsWithTag("Player");
        PlayerBases = GameObject.FindGameObjectsWithTag("PlayerBase");
        for (int i = 0; i < Players.Length; i++)
        {
            SpawnPlayer(i);
        }

        AnchoviBase = GameObject.FindGameObjectWithTag("AnchoviBase");
        SpawnAnchovis(AnchoviBase.transform.position);

        pizzaBases = GameObject.FindGameObjectsWithTag("PizzaBase");
        pizza = (GameObject)Instantiate(Pizza, ChoosePizzaBase(), Quaternion.identity);
	}

	void Update () {
	}

    public void SpawnPlayer(int ID)
    {
        Players[ID].transform.position = PlayerBases[ID].transform.position;
    }

    public void SpawnAnchovis(Vector3 position)
    {
        Instantiate(Anchovis, position, Quaternion.identity);
    }

    Vector3 ChoosePizzaBase()
    {
        int rand = Random.Range(0, pizzaBases.Length - 1);
        return pizzaBases[rand].transform.position;
    }

    public void ReSpawnPizza()
    {
        pizza.transform.position = ChoosePizzaBase();
    }
}
