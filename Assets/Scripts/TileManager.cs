using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> _activeTiles = new List<GameObject>();
    public Transform playerTransform;

    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if(i == 0)
              SpawnTile(0);
            else
              SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    private void Update()
    {
        if(playerTransform.position.z -35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        _activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(_activeTiles[0]);
        _activeTiles.RemoveAt(0);
    }
}
