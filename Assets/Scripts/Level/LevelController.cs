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
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public List<GameObject> chestPrefabs = new List<GameObject>();
    public PlayerController player;
    public bool canSwitchRooms = true;

    // DEBUG
    public int numberOfEnemiesPerRoom = 5;
    public int numberOfChestsInLevel = 5;
    private int availableChestsLeft = 5;


    public Minimap miniMap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // setupDebugRoom();
        // initRooms();

        
    }

    public void addRoom(Room room, int position){
        rooms[position] = room;
        rooms[position].index = position;
    }

    // Just for testing
    void initStartingRoom(){

        currentRoom.enterRoom();
    }

    // Level generator also calls this
    public void initRooms(){
        //
        // foreach(Room r in rooms){
        //     if(r)
        // }
        bool generatedBoss = false;
        foreach(Room r in rooms){

            if(r != null){
                Vector3 position = new Vector3(0,0,1);

                // Determine prefab number
                r.determinePrefabNumber();

                GameObject roomPrefab = Instantiate(roomPrefabs[r.roomPrefabNumber],position,this.transform.rotation); // note roomPrefabs[0] needs to change
                r.roomPrefab = roomPrefab;
                r.roomPrefab.GetComponent<RoomController>().levelController = this;
                r.initRoom();

                if(r.endRoom && !generatedBoss){
                    r.generateEntities(enemyPrefabs,chestPrefabs,numberOfEnemiesPerRoom, false,true);
                    generatedBoss = true;
                } else {

                bool generateChest = false;
                if(Random.Range(0,3) == 1 && availableChestsLeft > 0) generateChest = true;
                if(r.index != 45) r.generateEntities(enemyPrefabs,chestPrefabs,numberOfEnemiesPerRoom, generateChest,false);
                if(generateChest && r.index != 45) availableChestsLeft--;


                }
            }
        }



        // Starting room
        currentRoom = rooms[45];
        miniMap.visitCell(45);
        roomController = currentRoom.roomPrefab.GetComponent<RoomController>();
        currentRoom.enterRoom();
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
            miniMap.visitCell(currentRoom.index);
            
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
