using UnityEngine;
using System.Collections.Generic;

public class Room
{

    // Grid of entities
    public int gridWidth = 10;
    public int gridHeight = 10;
    int[,] grid;

    // Adjacent Rooms
    // 0 = north
    // 1 = south
    // 2 = east
    // 3 = west
    public Room[] adjacentRooms = new Room[4];
    public GameObject roomPrefab;

    // Active list of entities
    List<Entity> entities = new List<Entity>();

    public int roomPrefabNumber = 0;

    public void initRoom(){

        grid = new int[gridWidth,gridHeight];
        roomPrefab.SetActive(false);
    }

    public void enterRoom(){

        foreach(Entity e in entities){
            e.getObject().SetActive(true);
        }

        roomPrefab.SetActive(true);
    }

    public Room exitRoom(int moveIntoRoom){

        foreach(Entity e in entities){
            e.getObject().SetActive(false);
        }

        roomPrefab.SetActive(false);

        return adjacentRooms[moveIntoRoom];
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
