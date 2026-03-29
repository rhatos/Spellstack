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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Initialise all rooms after level generation
        // And set currentRoom
        // Instantiate as well, with scale set to 1.3
        // Also set levelcontroller to this
        initStartingRoom();
        roomController = currentRoom.roomPrefab.GetComponent<RoomController>();
        
    }

    // Level generator calls this
    public void addRoom(Room room){

        rooms.Add(room);

    }

    // Just for testing
    void initStartingRoom(){

        Room testRoom = new Room();

        this.currentRoom = testRoom;
        Vector3 position = new Vector3(0,0,1);
        GameObject roomPrefab = Instantiate(roomPrefabs[0],position,this.transform.rotation);

        testRoom.roomPrefab = roomPrefab;

        currentRoom.initRoom();
        currentRoom.enterRoom();
    }

    // Level generator also calls this
    public void initRooms(){

        foreach(Room r in rooms){
            Vector3 position = new Vector3(0,0,1);
            GameObject roomPrefab = Instantiate(roomPrefabs[0],position,this.transform.rotation); // note roomPrefabs[0] needs to change
            r.roomPrefab = roomPrefab;
            r.initRoom();

        }
    }

    // Update is called once per frame
    void Update()
    {
       currentRoom.Update(); 
    }

    public void switchRoom(int direction){

        currentRoom.exitRoom(direction);

    }
}
