using UnityEngine;

public class RoomCell : MonoBehaviour
{
    public int index;
    public int value;

    void Start(){
        this.gameObject.SetActive(false);
    }

}
