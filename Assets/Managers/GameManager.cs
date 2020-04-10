using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public List<GameObject> Tiles;
    public int FieldSize;

    private readonly Random _random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        var parent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        parent.name = "Field";
        for (int i = 0; i < FieldSize; i++)
        {
            for (int j = 0; j < FieldSize; j++)
            {
                var tile = Instantiate(Tiles[Random.Range(0, Tiles.Count)], new Vector3(i * 2.0F, 0, j * 2.0f), Quaternion.identity);
                tile.transform.parent = parent.transform;
            }
        }
        Instantiate(Player, new Vector3(0, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
