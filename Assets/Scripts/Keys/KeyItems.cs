using UnityEngine;

public class KeyItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Key picked up!");
            GameManager.Instance.OnKeyCollected();
            Destroy(gameObject);
        }
    }

}
