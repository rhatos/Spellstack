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
    Room[] adjacentRooms = new Room[4];
    public GameObject roomPrefab;

    // Active list of entities
    List<Entity> entities = new List<Entity>();


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

    public void exitRoom(int moveIntoRoom){

        foreach(Entity e in entities){
            e.getObject().SetActive(false);
        }

        roomPrefab.SetActive(false);
        adjacentRooms[moveIntoRoom].roomPrefab.SetActive(true);
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
