using UnityEngine;

public class DoorController : MonoBehaviour
{
    [Header("Door Parts")]
    public GameObject closedMesh; // Assign the closed door GameObject
    public GameObject openedMesh; // Assign the parent of the opened door (with frame and door inside)

    private bool isOpen = false;

    public void OpenDoor()
    {
        if (isOpen) return;

        if (closedMesh != null)
            closedMesh.SetActive(false);

        if (openedMesh != null)
            openedMesh.SetActive(true);

        isOpen = true;
    }

    public void ResetDoor()
    {
        if (!isOpen) return;

        if (closedMesh != null)
            closedMesh.SetActive(true);

        if (openedMesh != null)
            openedMesh.SetActive(false);

        isOpen = false;
    }
}
