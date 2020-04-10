﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Player;

    public List<Transform> Tiles;

    public int FieldSize;

    private readonly Random _random = new Random();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < FieldSize; i++)
        {
            for (int j = 0; j < FieldSize; j++)
            {
                Instantiate(Tiles[Random.Range(0,Tiles.Count)], new Vector3(i * 2.0F, 0, j*2.0f), Quaternion.identity);
            }
        }
        Instantiate(Player, new Vector3(0, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
