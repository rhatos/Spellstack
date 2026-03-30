using UnityEngine;
using System.Collections.Generic;


// Room controller handles all rooms
// Essentially the transitions and keeping track of the state of the rooms
public class LevelController : MonoBehaviour
{

    // Current room the player is in
    public Room currentRoom;
    public RoomController roomController; // initally null, but based on current room

    public Room[] rooms = new Room[100];

    public List<GameObject> roomPrefabs = new List<GameObject>();

    public PlayerController player;

    public bool canSwitchRooms = true;

    // DEBUG
    Room startRoom = new Room();
    Room differentRoom = new Room();
    Room differentRoomAgain = new Room();
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

        // Change this to test collisions @joshua
        startRoom.roomPrefabNumber = 13;

        differentRoom.adjacentRooms[0] = startRoom;
        differentRoom.adjacentRooms[1] = differentRoomAgain;

        differentRoom.determinePrefabNumber();


        differentRoomAgain.adjacentRooms[0] = differentRoom;
        differentRoomAgain.roomPrefabNumber = 1;

        addRoom(startRoom,45);
        addRoom(differentRoom,55);
        addRoom(differentRoomAgain,56);

    }

    public void addRoom(Room room, int position){
        rooms[position] = room;
    }

    // Just for testing
    void initStartingRoom(){

        currentRoom.enterRoom();
    }

    // Level generator also calls this
    public void initRooms(){

        foreach(Room r in rooms){

            if(r != null){
                Vector3 position = new Vector3(0,0,1);

                // Determine prefab number

                GameObject roomPrefab = Instantiate(roomPrefabs[r.roomPrefabNumber],position,this.transform.rotation); // note roomPrefabs[0] needs to change
                r.roomPrefab = roomPrefab;
                r.roomPrefab.GetComponent<RoomController>().levelController = this;
                r.initRoom();


            }
        }


        // Starting room
        currentRoom = rooms[45];
    }

    // Update is called once per frame
    void Update()
    {
       // currentRoom.Update(); 
    }

    // Must be called by the RoomController
    public void switchRoom(int direction){

        if(canSwitchRooms){
            currentRoom = currentRoom.exitRoom(direction);
            roomController = currentRoom.roomPrefab.GetComponent<RoomController>();
            roomController.levelController = this;
            currentRoom.enterRoom();
            
            // I.e: MOVING DOWN
            if(direction == 1){
                if(roomController.enterNorthRoomTrigger != null) player.transform.position = roomController.enterNorthRoomTrigger.spawnPoint.transform.position;
            }

            if(direction == 0){
                if(roomController.enterSouthRoomTrigger != null) player.transform.position = roomController.enterSouthRoomTrigger.spawnPoint.transform.position;
            }

            if(direction == 2){
                if(roomController.enterWestRoomTrigger != null) player.transform.position = roomController.enterWestRoomTrigger.spawnPoint.transform.position;
            }

            if(direction == 3){
                if(roomController.enterEastRoomTrigger != null) player.transform.position = roomController.enterEastRoomTrigger.spawnPoint.transform.position;
            }
        }

    }

    public void leftTrigger(){
        canSwitchRooms = true;
    }
}
