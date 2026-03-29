using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://www.youtube.com/watch?v=1-HIA6-LBJc
//Binding of isaac style level generation

public class LevelGenerator : MonoBehaviour
{

    public int minRooms = 10;
    public int maxRooms = 20;

    public int[] roomLayout;
    private int roomCount;
    private List<int> endRooms;

    public RoomCell roomCellPrefab;
    private float cellSize;
    private Queue<int> cellQueue;

    private List<RoomCell> spawnedRoomCells;

    public LevelController levelController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cellSize = 0.25f;
        spawnedRoomCells = new();

        SetupLevel();
        
    }

    void SetupLevel(){

        for(int i = 0; i < spawnedRoomCells.Count; i++){
            Destroy(spawnedRoomCells[i].gameObject);
        }

        spawnedRoomCells.Clear();

        roomLayout = new int[100];
        roomCount = default;
        cellQueue = new Queue<int>();
        endRooms = new List<int>();

        // Center
        VisitRoomCell(45);

        GenerateLevel();

    }

    void setupRooms(){

        // First pass
        int num = 0;
        foreach(int i in roomLayout){

            if(i > 0){
                Room r = new Room();
                levelController.addRoom(r, num);
            }
            num++;
        }

        // Now adjacent rooms
        num = 0;
        foreach(Room r in levelController.rooms){
            if(r != null){
               if(levelController.rooms[num+1] != null) r.adjacentRooms[2] = levelController.rooms[num+1]; 
               if(levelController.rooms[num-1] != null) r.adjacentRooms[3] = levelController.rooms[num-1];
               if(levelController.rooms[num+10] != null) r.adjacentRooms[1] = levelController.rooms[num+10]; 
               if(levelController.rooms[num-10] != null) r.adjacentRooms[0] = levelController.rooms[num-10]; 
            }
            num++;
        }

    }

    void GenerateLevel(){

        while(cellQueue.Count > 0){
            int index = cellQueue.Dequeue();
            int x = index % 10;

            bool created = false;

            if(x > 1) created |= VisitRoomCell(index - 1);
            if(x < 9) created |= VisitRoomCell(index + 1);
            if(index > 20) created |= VisitRoomCell(index - 10);
            if(index < 70) created |= VisitRoomCell(index + 10);

            if(created == false){
                endRooms.Add(index);
            }
        }

        if(roomCount < minRooms){
            SetupLevel();
            return;
        }

        int i = 0;
        foreach(int c in roomLayout){

            if(c > 0) Debug.Log(i + ": " + c);

            i++;
        }

    }

    int RandomEndRoom(){
        return -1;
    }

    // Returns value between 0 and 4
    private int GetNeighbourCount(int index){

        return roomLayout[index - 10] + roomLayout[index - 1] + roomLayout[index + 1] + roomLayout[index + 10];
    }

    private bool VisitRoomCell(int index){

        if(roomLayout[index] != 0){
            return false;
        }

        if(GetNeighbourCount(index) > 1){
            return false;
        }

        if(roomCount > maxRooms){
            return false;
        }

        if(Random.value < 0.5f){
            return false;
        }

        cellQueue.Enqueue(index);
        roomLayout[index] = 1;
        roomCount++;

        SpawnRoom(index);

        return true;

    }

    private void SpawnRoom(int index){

        // 1d array
        int x = index % 10;
        int y = index / 10;
        Vector2 position = new Vector2(x * cellSize, -y * cellSize);

        RoomCell cell = Instantiate(roomCellPrefab, position, Quaternion.identity);
        cell.value = 1;
        cell.index = index;

        spawnedRoomCells.Add(cell);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            SetupLevel();
        }
        
    }
}
