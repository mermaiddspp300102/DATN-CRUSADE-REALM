using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public GameObject[] prefabsToPlace; // Mảng các Prefab cần xếp
    public int numberOfPrefabsToPlace; // Số lượng Prefab cần xếp
    public Vector2Int gridSize; // Kích thước của grid
    public float spacing = 1f; // Khoảng cách giữa các Prefab
    public Transform gridOrigin; // Gốc của grid

    void Start()
    {
        PlacePrefabsRandomly();
    }

    void PlacePrefabsRandomly()
    {
        for (int i = 0; i < numberOfPrefabsToPlace; i++)
        {
            // Chọn một vị trí ngẫu nhiên trên grid
            Vector2Int randomPosition = new Vector2Int(Random.Range(0, gridSize.x), Random.Range(0, gridSize.y));
            Vector3 spawnPosition = gridOrigin.position + new Vector3(randomPosition.x * spacing, 0f, randomPosition.y * spacing);

            // Chọn một Prefab ngẫu nhiên từ mảng Prefabs
            GameObject randomPrefab = prefabsToPlace[Random.Range(0, prefabsToPlace.Length)];

            // Xây dựng một bản sao của Prefab và đặt nó tại vị trí ngẫu nhiên
            GameObject newObject = Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
