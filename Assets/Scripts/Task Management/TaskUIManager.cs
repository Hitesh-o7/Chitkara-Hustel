using System.Text;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskUIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private GameObject taskPanel;
    [SerializeField] private TMP_Text taskText;
    [SerializeField] private TMP_Text timerText;

    private bool isVisible = false;
    private float currentTime = 0f;
    private bool isTimerRunning = false;

    private List<string> failedTasks = new List<string>();

    private const float INITIAL_TASK_DURATION = 320f;  
    private const float DURATION_REDUCTION_PER_TASK = 30f;
    private const float MINIMUM_TASK_DURATION = 30f;

    // taskCycleCount now represents the 0-based index of the current task in a chain.
    // It's used to calculate the duration reduction for the task currently being assigned.
    // It's incremented after a task is assigned (preparing for the next) and reset on timer failure.
    private int taskCycleCount = 0;

    private void Start()
    {
        taskPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isVisible = !isVisible;
            taskPanel.SetActive(isVisible);

            if (isVisible)
            {
                UpdateTaskText(); // Refresh task text when panel becomes visible
                UpdateTimerUI();  // Ensure timer display is current
            }
        }

        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;
            currentTime = Mathf.Max(currentTime, 0f);
            UpdateTimerUI();

            if (currentTime <= 0f)
            {
                isTimerRunning = false; // Stop the timer before processing end
                OnTimerEnd();
            }
        }
    }

    public void AssignNewTaskAndUpdateTimer()
    {
        // Calculate duration based on the current task's index in the chain
        float newDuration = INITIAL_TASK_DURATION - (DURATION_REDUCTION_PER_TASK * taskCycleCount);
        newDuration = Mathf.Max(newDuration, MINIMUM_TASK_DURATION);

        currentTime = newDuration;
        isTimerRunning = true;

        Debug.Log($"New task assigned (Cycle Index: {taskCycleCount}). Timer set to: {newDuration}s");
        UpdateTimerUI(); // Update UI immediately with new time

        taskCycleCount++; // Move this AFTER using it
    }

    public void OnTaskCompleted()
    {
        // taskCycleCount is no longer incremented here; it's advanced by AssignNewTaskAndUpdateTimer.
        // This method now primarily signals that a task is done, allowing the timer to potentially pause.
        Debug.Log("Task completed by player.");
        PauseTimerIfNoTasks();
    }

    public void PauseTimerIfNoTasks()
    {
        if (TaskManager.Instance.GetActiveTasks().Count == 0)
        {
            isTimerRunning = false;
            Debug.Log("All tasks for the current timer cycle completed or no tasks active — timer paused.");
        }
        else
        {
            Debug.Log("Tasks still active or TaskManager reports active tasks, timer continues.");
        }
    }

    private void OnTimerEnd()
    {
        Debug.Log("Timer ended!");

        // Process failed tasks
        List<string> remainingActiveTasks = TaskManager.Instance.GetActiveTasks();
        if (remainingActiveTasks.Count > 0)
        {
            Debug.Log($"Adding {remainingActiveTasks.Count} tasks to failed list.");
            failedTasks.AddRange(remainingActiveTasks);
            TaskManager.Instance.ClearAllActiveTasks(); // Clear tasks that were active when timer ended
        }
        else
        {
            Debug.Log("Timer ended, but no tasks were reported as active by TaskManager.");
        }

        // Reset cycle count for the next chain of tasks
        taskCycleCount = 0;
        Debug.Log("Task cycle count reset to 0 for the next chain.");

        UpdateTaskText(); // Refresh UI to show failed tasks
        // The timer UI will show 00:00 due to currentTime being 0
    }

    private void UpdateTaskText()
    {
        List<string> activeTasks = TaskManager.Instance.GetActiveTasks();
        List<string> completedTasks = TaskManager.Instance.GetCompletedTasks(); // Assuming TaskManager tracks these

        StringBuilder sb = new StringBuilder();

        if (activeTasks.Count == 0 && completedTasks.Count == 0 && failedTasks.Count == 0)
        {
            sb.Append("No tasks yet.");
        }
        else
        {
            if (activeTasks.Count > 0)
            {
                sb.AppendLine("Active Tasks:");
                foreach (string task in activeTasks)
                {
                    sb.AppendLine("• " + task);
                }
                sb.AppendLine();
            }

            // Assuming TaskManager has a way to provide completed tasks for UI purposes.
            // If TaskManager doesn't store a list of 'session completed' tasks, this part might need adjustment.
            if (completedTasks.Count > 0)
            {
                sb.AppendLine("✔ Completed Tasks (Session):"); // Clarify if these are from current session
                foreach (string task in completedTasks)
                {
                    // TMPro rich text for strikethrough: <s>text</s>
                    sb.AppendLine("<s>• " + task + "</s>");
                }
                sb.AppendLine();
            }

            if (failedTasks.Count > 0)
            {
                sb.AppendLine("❌ Failed Tasks:");
                foreach (string task in failedTasks)
                {
                    sb.AppendLine("• " + task);
                }
                sb.AppendLine(); // Add a blank line for spacing if needed
            }
        }

        taskText.text = sb.ToString();
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    public void RefreshUI()
    {
        if (isVisible)
        {
            UpdateTaskText();
            UpdateTimerUI(); // Also ensure timer is up-to-date
        }
    }

    public bool IsVisible()
    {
        return isVisible;
    }

    // Optional: Method to clear failed tasks if needed, e.g., when starting a completely new game or level
    public void ClearFailedTasksList()
    {
        failedTasks.Clear();
        Debug.Log("Failed tasks list cleared.");
        if (isVisible) UpdateTaskText();
    }
}