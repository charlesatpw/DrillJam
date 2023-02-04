using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPlacement : MonoBehaviour
{
    [SerializeField]
    public Transform playerTransform;

    [SerializeField]
    public GameObject water;

    [SerializeField]
    public GameObject fert;

    [SerializeField]
    public GameObject fuel;

    [SerializeField]
    public BoxCollider2D levelBoundingBox;

    public float minY;
    public float maxYAddition;

    public float minX;
    public float maxX;

    public float minItemProximity;

    public int maxTriesPerSpawn;

    public int numberOfItem;

    private float totalWeighting;

    private void Start()
    {
        minX = levelBoundingBox.bounds.min.x + 3f;
        maxX = levelBoundingBox.bounds.max.x - 3f;
    }

    private void Update()
    {
        if (playerTransform.position.y < minY + maxYAddition)
        {
            minY = minY - maxYAddition;
            SpawnSectionOfItems(numberOfItem);
        }
    }

    private void SpawnSectionOfItems(int numberOfItem)
    {
        List<Vector3> spawnLocations = new List<Vector3>(numberOfItem);
        for (int i = 0; i < numberOfItem; i++)
        {
            spawnLocations.Add(SelectLocation(spawnLocations, minItemProximity, maxTriesPerSpawn, 0));
            SpawnItem(spawnLocations[i]);
        }
    }

    private void SpawnItem(Vector3 location)
    {
        // Pick time
        GameObject itemToSpawn = SelectItem();
        // Pick location
        Instantiate(itemToSpawn, location, new Quaternion(0, 0, 0, 0), transform);
    }

    private Vector3 SelectLocation(List<Vector3> spawnLocations, float minDistanceRadius, int maxTries, int currentTry)
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, minY + maxYAddition);
        float z = 0f;

        Vector3 location = new Vector3(x, y, z);
        if (!CheckIfPointsAreInRadius(spawnLocations, location, minDistanceRadius))
        {
            if (currentTry > maxTries)
            {
                return SelectLocation(spawnLocations, minDistanceRadius, maxTries, ++currentTry);
            }
        }
        return new Vector3(x, y, z);
    }

    private bool CheckIfPointsAreInRadius(List<Vector3> spawnLocations, Vector3 checkedLocation, float allowedRadius)
    {
        foreach (Vector3 location in spawnLocations)
        {
            if ((checkedLocation - location).magnitude < allowedRadius)
            {
                return true;
            }
        }
        return false;
    }

    private GameObject SelectItem()
    {
        List<ItemTemplate> items = new List<ItemTemplate>(Config.itemConfig.items.Values);
        float totalWeight = ItemService.GetTotalItemWeight();

        float randomValue = Random.Range(0f, totalWeight);

        if (randomValue < Config.itemConfig.items[GameConstants.Fertilizer].weight)
        {
            return fert;
        }
        else if (randomValue < Config.itemConfig.items[GameConstants.Jerry_Can].weight + Config.itemConfig.items[GameConstants.Fertilizer].weight)
        {
            return fuel;
        }
        else
        {
            return water;
        }
    }
}
