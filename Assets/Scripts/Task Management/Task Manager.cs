using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance { get; private set; }

    private HashSet<string> activeTasks = new HashSet<string>();
    private HashSet<string> completedTasks = new HashSet<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public List<string> GetActiveTasks()
    {
        return new List<string>(activeTasks);
    }

    public List<string> GetCompletedTasks()
    {
        return new List<string>(completedTasks);
    }

    public void AssignTask(string taskID)
    {
        if (!activeTasks.Contains(taskID) && !completedTasks.Contains(taskID))
        {
            activeTasks.Add(taskID);
            Debug.Log($"Task assigned: {taskID}");

            var uiManager = Object.FindFirstObjectByType<TaskUIManager>();
            if (uiManager != null)
            {
                uiManager.AssignNewTaskAndUpdateTimer();
                uiManager.RefreshUI();
            }
        }
    }

    public void CompleteTask(string taskID)
    {
        if (activeTasks.Contains(taskID))
        {
            activeTasks.Remove(taskID);
            completedTasks.Add(taskID);
            Debug.Log($"Task completed: {taskID}");

            var uiManager = Object.FindFirstObjectByType<TaskUIManager>();
            if (uiManager != null)
            {
                uiManager.RefreshUI();
                uiManager.PauseTimerIfNoTasks();
            }
        }
        else
        {
            Debug.LogWarning($"TaskCompletion attempted on inactive or unknown task: {taskID}");
        }
    }

    public bool IsTaskActive(string taskID)
    {
        return activeTasks.Contains(taskID);
    }

    public bool IsTaskCompleted(string taskID)
    {
        return completedTasks.Contains(taskID);
    }

    public void ClearAllTasks()
    {
        activeTasks.Clear();
        completedTasks.Clear();
        Debug.Log("All tasks cleared.");

        var uiManager = Object.FindFirstObjectByType<TaskUIManager>();
        if (uiManager != null)
        {
            uiManager.PauseTimerIfNoTasks();
            uiManager.RefreshUI();
        }
    }
    public void ClearAllActiveTasks()
    {
        activeTasks.Clear();
    }

}
