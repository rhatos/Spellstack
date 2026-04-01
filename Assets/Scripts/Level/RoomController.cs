using UnityEngine;
using System.Collections.Generic;

public class RoomController : MonoBehaviour
{

    public LevelController levelController;

    // Entrance triggers
    public RoomTrigger enterSouthRoomTrigger;
    public RoomTrigger enterNorthRoomTrigger;
    public RoomTrigger enterEastRoomTrigger;
    public RoomTrigger enterWestRoomTrigger;

    public Dictionary<int,Transform> spawnPoints = new Dictionary<int,Transform>();
    public GameObject spawnPointHolder;

    void Awake(){

        // Add all spawn points
        int idx = 0;
        foreach(Transform t in spawnPointHolder.GetComponentsInChildren<Transform>()){
            spawnPoints.Add(idx,t);
            idx++;
        }

        if(enterSouthRoomTrigger != null){
            enterSouthRoomTrigger.EnteredTrigger += OnEnterRoomSouthTrigger;
            enterSouthRoomTrigger.ExitedTrigger += OnExitRoomSouthTrigger;
        }

        if(enterNorthRoomTrigger != null){
        enterNorthRoomTrigger.EnteredTrigger += OnEnterRoomNorthTrigger;
        enterNorthRoomTrigger.ExitedTrigger += OnExitRoomNorthTrigger;
        }

        if(enterEastRoomTrigger != null){
        enterEastRoomTrigger.EnteredTrigger += OnEnterRoomEastTrigger;
        enterEastRoomTrigger.ExitedTrigger += OnExitRoomEastTrigger;
        }

        if(enterWestRoomTrigger != null){
        enterWestRoomTrigger.EnteredTrigger += OnEnterRoomWestTrigger;
        enterWestRoomTrigger.ExitedTrigger += OnExitRoomWestTrigger;
        }
    }

    public GameObject instantiateEntity(GameObject e, Transform t){
        GameObject o = Instantiate(e,t.position,Quaternion.identity);
        o.SetActive(false);
        return o;
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

    void OnEnterRoomEastTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller to change rooms
            Debug.Log("Entered a east room trigger");

            levelController.switchRoom(2);
        }
    }

    void OnExitRoomEastTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller that we have left the trigger and it can be triggered again.
            Debug.Log("Exited a east room trigger");
            levelController.canSwitchRooms = true;
        }
    }
    void OnEnterRoomWestTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller to change rooms
            Debug.Log("Entered a west room trigger");

            levelController.switchRoom(3);
        }
    }

    void OnExitRoomWestTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller that we have left the trigger and it can be triggered again.
            Debug.Log("Exited a west room trigger");
            levelController.canSwitchRooms = true;
        }
    }


    void OnEnterRoomNorthTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller to change rooms
            Debug.Log("Entered a north room trigger");

            levelController.switchRoom(0);
        }
    }

    void OnExitRoomNorthTrigger(Collider2D other){

        if(other.CompareTag("Player")){

            // Prompt level controller that we have left the trigger and it can be triggered again.
            Debug.Log("Exited a north room trigger");
            levelController.canSwitchRooms = true;
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
