using UnityEngine;
using UnityEngine.UI;

public class MapCell : MonoBehaviour
{

    public int index;
    public Material defaultMat;
    public Material activeMat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void setActive(){
        this.GetComponent<Image>().material = activeMat;
    }

    public void setInActive(){
        this.GetComponent<Image>().material = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
