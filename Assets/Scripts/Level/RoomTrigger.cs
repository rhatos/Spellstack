using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public event System.Action<Collider2D> EnteredTrigger;
    public event System.Action<Collider2D> ExitedTrigger;

    public GameObject spawnPoint;

    void OnTriggerEnter2D(Collider2D other){
        EnteredTrigger?.Invoke(other);
    }

    void OnTriggerExit2D(Collider2D other){
        ExitedTrigger?.Invoke(other);
    }
}
