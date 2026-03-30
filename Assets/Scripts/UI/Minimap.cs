using UnityEngine;
using System.Collections.Generic;

public class Minimap : MonoBehaviour
{

    Dictionary<int, MapCell> mapCells = new Dictionary<int, MapCell>();

    public MapCell startingCell;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void visitCell(int index){
        float cellSize = 16;
        int x = index % 10;
        int y = index / 10;
        setAllInActive();
        if(mapCells.ContainsKey(index)){
            // Apply shader
            mapCells[index].setActive();
        } else {

            Vector2 position = new Vector2(x * cellSize, (-y-1) * cellSize);
            MapCell cell = Instantiate(startingCell,position,Quaternion.identity);
            cell.index = index;
            cell.transform.SetParent(this.gameObject.transform, false);

            mapCells.Add(index,cell);
        }

        mapCells[index].setActive();
    }

    public void setAllInActive(){
        foreach(var c in mapCells){
            c.Value.setInActive();
        }
    }

    public void leaveCell(int index){

        // Turn off shader/set to default
    }
}
