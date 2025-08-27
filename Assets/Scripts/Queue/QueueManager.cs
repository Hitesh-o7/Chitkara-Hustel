using System.Collections.Generic;
using UnityEngine;

public class QueueManager : MonoBehaviour
{
    [SerializeField] private GameObject employeePrefab;
    [SerializeField] private Transform spawnPoint;

    private Queue<GameObject> employeeQueue = new Queue<GameObject>();
    private GameObject currentEmployee;

    private bool isWaitingForPlayer = false;
    private List<string> assignedTasks = new List<string>();

    private void Update()
    {
        // Player presses E to interact with the counter
        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleCounterInteraction();
        }
    }

    public void HandleCounterInteraction()
    {
        if (currentEmployee == null)
        {
            SpawnNewEmployee();
        }
        else if (isWaitingForPlayer && AllTasksCompleted())
        {
            CompleteInteraction();
        }
        else
        {
            Debug.Log("Complete the assigned tasks first.");
        }
    }

    void SpawnNewEmployee()
    {
        currentEmployee = Instantiate(employeePrefab, spawnPoint.position, Quaternion.identity);
        assignedTasks = GetRandomTasks(2); // Assign 2 random tasks
        foreach (var task in assignedTasks)
        {
            TaskManager.Instance.AssignTask(task);
        }
        isWaitingForPlayer = true;
        Debug.Log("New employee assigned 2 tasks.");
    }

    void CompleteInteraction()
    {
        Destroy(currentEmployee);
        currentEmployee = null;
        isWaitingForPlayer = false;
        assignedTasks.Clear();
        Debug.Log("Employee served and removed from queue.");
    }

    bool AllTasksCompleted()
    {
        foreach (var task in assignedTasks)
        {
            if (!TaskManager.Instance.IsTaskCompleted(task))
                return false;
        }
        return true;
    }

    List<string> GetRandomTasks(int count)
    {
        // Combine all tasks
        List<string> allTasks = new List<string>();
        allTasks.AddRange(TaskLibrary.DeansOfficeTasks);
        allTasks.AddRange(TaskLibrary.BabbageBlockTasks);
        allTasks.AddRange(TaskLibrary.StaffRoom1Tasks);
        allTasks.AddRange(TaskLibrary.NewtonBlockTasks);
        allTasks.AddRange(TaskLibrary.EdisonBlockTasks);
        allTasks.AddRange(TaskLibrary.FlemmingBlockTasks);
        allTasks.AddRange(TaskLibrary.StaffRoom2Tasks);
        allTasks.AddRange(TaskLibrary.TuringBlockTasks);
        allTasks.AddRange(TaskLibrary.PantryTasks);
        allTasks.AddRange(TaskLibrary.Square1Tasks);
        allTasks.AddRange(TaskLibrary.PicassoBlockTasks);
        allTasks.AddRange(TaskLibrary.Square2Tasks);
        // Add other room tasks here

        // Shuffle and pick
        List<string> selected = new List<string>();
        while (selected.Count < count && allTasks.Count > 0)
        {
            int index = Random.Range(0, allTasks.Count);
            selected.Add(allTasks[index]);
            allTasks.RemoveAt(index);
        }

        return selected;
    }
}
