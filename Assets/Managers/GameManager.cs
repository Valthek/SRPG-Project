using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Entities.Attributes;
using Assets.Entities.Interfaces;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Units;
    public List<GameObject> TileObjects;
    public List<ITile> TileEntities { get; set; }
    public List<IUnit> UnitEntities { get; set; }

    public Transform SelectedUnit { get; set; }
    public Transform SelectedTile { get; set; }

    public int FieldSize;
    
    private readonly Random _random = new Random();

    // Start is called before the first frame update
    void Start()
    {
        TileEntities = new List<ITile>();
        UnitEntities = new List<IUnit>();
        var parent = Instantiate(new GameObject(), new Vector3(0, 0, 0), Quaternion.identity);
        parent.name = "Field";
        for (int i = 0; i < FieldSize; i++)
        {
            for (int j = 0; j < FieldSize; j++)
            {
                var tile = Instantiate(TileObjects[Random.Range(0, TileObjects.Count)], new Vector3(i * 2.0F, 0, j * 2.0f), Quaternion.identity);
                tile.transform.parent = parent.transform;
                var tileEntity = tile.gameObject.GetComponent<ITile>();
                tileEntity.TilePosition = new Vector3(i,0,j);
                TileEntities.Add(tileEntity);
            }
        }

        foreach (ITile t in TileEntities)
        {
            var neigh = TileEntities.Where(e => Vector3.Distance(t.TilePosition, e.TilePosition) <= 1.1f && t != e).ToList();
            t.Neighbors = neigh;
        }

        foreach(GameObject unit in Units)
        {   
            var unitStartPosition = new Vector3(0,0,0);
            var newUnit = Instantiate(unit, new Vector3(0, 1, 0), Quaternion.identity);
            var unitData = newUnit.gameObject.GetComponent<IUnit>();
            unitData.Movement = new Movement(0.1f)
            {
                CurrentLocation =
                    TileEntities.FirstOrDefault(t => t.TilePosition == unitStartPosition)
            };
            UnitEntities.Add(unitData);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
