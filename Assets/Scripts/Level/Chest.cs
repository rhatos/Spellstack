using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject cardPickUpPrefab;
    public GameObject eButton;

    private Animator anim;
    public bool canOpen = false;
    public bool isOpen = false;
    public bool canUse = false;

    GameObject spellSelectionScreen;
    GameObject tempCard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.anim = this.GetComponent<Animator>();
        this.eButton.SetActive(false);

        spellSelectionScreen = GameObject.Find("SpellSelectUI");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!canOpen) anim.speed = 0;
        if(canOpen) anim.speed = 1;

       if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f && !isOpen){
           isOpen = true;
           Vector3 cardPosition = new Vector3(transform.position.x,transform.position.y+0.7f,0);
           tempCard = Instantiate(cardPickUpPrefab,cardPosition,Quaternion.identity);
       }

       if(isOpen && canUse){
           if(Input.GetKeyDown(KeyCode.E)){
               spellSelectionScreen.GetComponent<SpellSelector>().activate();
               Destroy(tempCard);
               Destroy(this.gameObject);
               Time.timeScale = 0f;
           }
       }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            eButton.SetActive(true);
            canUse = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            eButton.SetActive(false);
            canUse = false;
        }
    }


}
