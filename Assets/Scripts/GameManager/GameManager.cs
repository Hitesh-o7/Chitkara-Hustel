using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public DoorController[] allDoors;
    public GameObject keyPrefab;
    public Transform[] keySpawnPoints;

    private GameObject currentKey;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnRandomKey();
    }

    public void OnKeyCollected()
    {
        Debug.Log("Key collected! Opening doors...");

        foreach (var door in allDoors)
        {
            if (door == null)
            {
                Debug.LogWarning("A door is missing from the GameManager's list!");
                continue;
            }

            Debug.Log("Opening door: " + door.gameObject.name);
            door.OpenDoor();
        }
    }


    public void OnTaskCompleted()
    {
        Debug.Log("Task completed. Resetting doors and respawning key...");
        foreach (var door in allDoors)
        {
            door.ResetDoor();
        }
        SpawnRandomKey();
    }

    private void SpawnRandomKey()
    {
        if (keySpawnPoints.Length == 0 || keyPrefab == null) return;

        int index = Random.Range(0, keySpawnPoints.Length);
        Transform spawnPoint = keySpawnPoints[index];

        Debug.Log("Spawning key at: " + spawnPoint.name);
        currentKey = Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
    }

}
