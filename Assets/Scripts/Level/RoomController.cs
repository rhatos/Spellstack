using UnityEngine;

public class RoomController : MonoBehaviour
{

    public LevelController levelController;

    // Entrance triggers
    public RoomTrigger enterSouthRoomTrigger;
    public RoomTrigger enterNorthRoomTrigger;

    void Awake(){
        enterSouthRoomTrigger.EnteredTrigger += OnEnterRoomSouthTrigger;
        enterSouthRoomTrigger.ExitedTrigger += OnExitRoomSouthTrigger;
        enterNorthRoomTrigger.EnteredTrigger += OnEnterRoomNorthTrigger;
        enterNorthRoomTrigger.EnteredTrigger += OnEnterRoomNorthTrigger;
    }

    void OnEnterRoomSouthTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller to change rooms
            Debug.Log("Entered a south room trigger");

            levelController.switchRoom(1);
        }
    }

    void OnExitRoomSouthTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller that we have left the trigger and it can be triggered again.
            Debug.Log("Exited a south room trigger");
        }
    }

    void OnEnterRoomNorthTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller to change rooms
            Debug.Log("Entered a south room trigger");

            levelController.switchRoom(0);
        }
    }

    void OnExitRoomNorthTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller that we have left the trigger and it can be triggered again.
            Debug.Log("Exited a south room trigger");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
