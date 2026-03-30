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

    public void determinePrefabNumber(){
        // i.e: all 4 directions, so 15 different directions

        bool up = false;
        bool down = false;
        bool right = false;
        bool left = false;

        if(adjacentRooms[0] != null) up = true;
        if(adjacentRooms[1] != null) down = true;
        if(adjacentRooms[2] != null) right = true;
        if(adjacentRooms[3] != null) left = true;
  
        // 1 Entrance (4)
        if (up && !down && !left && !right) {roomPrefabNumber=8;} // only up
        if (!up && down && !left && !right) {roomPrefabNumber=7;} // only down
        if (!up && !down && left && !right) {roomPrefabNumber=9;} // only left
        if (!up && !down && !left && right) {roomPrefabNumber=10;} // only right

        // 2 Entrances (6)
        if (up && down && !left && !right) {roomPrefabNumber = 0;} // vertical
        if (up && !down && left && !right) {roomPrefabNumber = 2;} // L with up and left
        if (up && !down && !left && right) {roomPrefabNumber = 1;} // L with up and right
        if (!up && down && left && !right) {roomPrefabNumber = 4;} // L with down and left
        if (!up && down && !left && right) {roomPrefabNumber=11;} // L shape with down and right
        if (!up && !down && left && right) {roomPrefabNumber=Random.Range(5,7);} // left and right there are 2 prefabs for this

        // 3 Entrances (4)
        if (up && down && left && !right) {roomPrefabNumber=13;} // Up, Down and Left only
        if (up && down && !left && right) {roomPrefabNumber=15;} // Up, Down and Right only
        if (up && !down && left && right) {roomPrefabNumber=12;} // Up, Left and Right only
        if (!up && down && left && right) {roomPrefabNumber=14;} // Down, Left and Right only

        // 4 Entrances (1)
        if (up && down && left && right) {roomPrefabNumber=3;} // 4 directions
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
