using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    public float[] xPos;
    int xPosIndex = 1;
    public float speed = 5f;
    public float floorHeight;
    public Rigidbody rb;

    void start(){

    }

    public void Begin(){

    }

    private void Update(){

        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft();
        if (Input.GetKeyDown(KeyCode.D))
            MoveRight();

        if (rb.position.y < 0f){
            Debug.Log("Player has gone below -1");
            FindObjectOfType<GameManager>().EndGame();
        }
        

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(xPos[xPosIndex], floorHeight, transform.position.z), Time.deltaTime * speed);
    }
    void MoveLeft(){
        xPosIndex--;
        if(xPosIndex < 0)
            xPosIndex = 0;
    }
    void MoveRight(){
        if(xPosIndex<2)    
            xPosIndex++;
        if(xPosIndex > xPos.Length - 1)
            xPosIndex = 0;
    }    
}
