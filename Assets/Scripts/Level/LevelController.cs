using UnityEngine;
using System.Collections.Generic;


// Room controller handles all rooms
// Essentially the transitions and keeping track of the state of the rooms
public class LevelController : MonoBehaviour
{

    // Current room the player is in
    public Room currentRoom;
    public RoomController roomController; // initally null, but based on current room

    List<Room> rooms = new List<Room>();
    public List<GameObject> roomPrefabs = new List<GameObject>();

    public PlayerController player;

    public bool canSwitchRooms = true;

    // DEBUG
    Room startRoom = new Room();
    Room differentRoom = new Room();
    //

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        setupDebugRoom();
        initRooms();
        roomController = currentRoom.roomPrefab.GetComponent<RoomController>();
        currentRoom.enterRoom();
        
    }

    void setupDebugRoom(){

        // Room connections
        startRoom.adjacentRooms[1] = differentRoom;
        differentRoom.adjacentRooms[0] = startRoom;
        differentRoom.roomPrefabNumber = 1;

        addRoom(startRoom);
        addRoom(differentRoom);

    }

    // Level generator calls this
    public void addRoom(Room room){

        rooms.Add(room);

    }

    // Just for testing
    void initStartingRoom(){

        currentRoom.enterRoom();
    }

    // Level generator also calls this
    public void initRooms(){

        foreach(Room r in rooms){
            Vector3 position = new Vector3(0,0,1);
            GameObject roomPrefab = Instantiate(roomPrefabs[r.roomPrefabNumber],position,this.transform.rotation); // note roomPrefabs[0] needs to change
            r.roomPrefab = roomPrefab;
            r.roomPrefab.GetComponent<RoomController>().levelController = this;
            r.initRoom();

        }

        currentRoom = rooms[0];
    }

    // Update is called once per frame
    void Update()
    {
       // currentRoom.Update(); 
    }

    // Must be called by the RoomController
    public void switchRoom(int direction){

        if(canSwitchRooms){
            // canSwitchRooms = false;
            Debug.Log("DIRECTION: " + direction);
            currentRoom = currentRoom.exitRoom(direction);
            Debug.Log("EXITING IN DIRECTION: " + direction);
            roomController = currentRoom.roomPrefab.GetComponent<RoomController>();
            Debug.Log("SETTING ROOM CONTROLLER " + direction);
            roomController.levelController = this;
            currentRoom.enterRoom();
            
            // I.e: MOVING DOWN
            if(direction == 1){
                // Then should be teleported to the NORTH entrance of the new room
                // ... room
                player.transform.position = roomController.enterNorthRoomTrigger.spawnPoint.transform.position;

            }

            if(direction == 0){
                player.transform.position = roomController.enterSouthRoomTrigger.spawnPoint.transform.position;
            }
        }

    }

    public void leftTrigger(){
        canSwitchRooms = true;
    }
}
