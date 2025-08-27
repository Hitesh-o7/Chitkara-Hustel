using System.Collections.Generic;
using UnityEngine;

public class TaskCompletionTrigger : MonoBehaviour
{
    [Tooltip("Name of the task group. Example: DeansOfficeTasks, BabbageBlockTasks, etc.")]
    [SerializeField] private string taskGroup;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Debug.Log($"Player entered trigger for area: {taskGroup}");

        List<string> taskPool = GetTaskGroup(taskGroup);

        foreach (string task in taskPool)
        {
            if (TaskManager.Instance.IsTaskActive(task))
            {
                TaskManager.Instance.CompleteTask(task);
            }
        }
    }

    private List<string> GetTaskGroup(string group)
    {
        return group switch
        {
            "DeansOfficeTasks" => TaskLibrary.DeansOfficeTasks,
            "BabbageBlockTasks" => TaskLibrary.BabbageBlockTasks,
            "StaffRoom1Tasks" => TaskLibrary.StaffRoom1Tasks,
            "NewtonBlockTasks" => TaskLibrary.NewtonBlockTasks,
            "EdisonBlockTasks" => TaskLibrary.EdisonBlockTasks,
            "FlemmingBlockTasks" => TaskLibrary.FlemmingBlockTasks,
            "StaffRoom2Tasks" => TaskLibrary.StaffRoom2Tasks,
            "TuringBlockTasks" => TaskLibrary.TuringBlockTasks,
            "PantryTasks" => TaskLibrary.PantryTasks,
            "Square1Tasks" => TaskLibrary.Square1Tasks,
            "Square2Tasks" => TaskLibrary.Square2Tasks,
            "PicassoBlockTasks" => TaskLibrary.PicassoBlockTasks,
            _ => new List<string>() // return empty if no match
        };
    }
}
