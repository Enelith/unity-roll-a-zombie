using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int selectedZombiePosition = 0;

    public GameObject selectedZombie;
    public List<GameObject> zombies;

    public Vector3 selectedSize;
    public Vector3 defaultSize;

    // Start is called before the first frame update
    void Start()
    {
        SelectZombie(selectedZombie);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("left")) {
            GetZombieLeft();
        }
        if(Input.GetKeyDown("right")) {
            GetZombieRight();      
        }
        if(Input.GetKeyDown("up")) {
            PushUp();
        } 
    }

    void GetZombieLeft() {
        selectedZombiePosition = ( selectedZombiePosition > 0 ? selectedZombiePosition - 1 : zombies.Count -1 );
        ChangeSelectedZombie();
    }

    void GetZombieRight() {
        selectedZombiePosition = ( selectedZombiePosition < zombies.Count - 1 ? selectedZombiePosition + 1 : 0 );
        ChangeSelectedZombie();
    }

    void ChangeSelectedZombie() {
        SelectZombie(zombies[selectedZombiePosition]);
    }

    void SelectZombie(GameObject zombie) {
        selectedZombie.transform.localScale = defaultSize;
        selectedZombie = zombie;
        selectedZombie.transform.localScale = selectedSize;
    }

    void PushUp() {
        RigidBody rb = selectedZombie.GetComponent<RigidBody>();
        rb.AddForce(0, 0, 10, ForceMode.Impulse);
    }
}
