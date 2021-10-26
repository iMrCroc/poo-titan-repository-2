using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement1 : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody RigidBody;
    public Transform cam;
    public bool canPlayerMove=true;
    public float speed;
    public float jumpForce;
    private float height;
    private bool canJump;
    private bool dead;
    private int nextSceneToLoad;
    private int bonusInertia = 1;
    void Start() {
       
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        canJump = true;
        if (collisionInfo.collider.tag == "Finish")
        {
            dead = true;
        }

        if (collisionInfo.collider.tag == "GameController")
        {
            nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneToLoad);
        }

        if (collisionInfo.collider.tag == "MainCamera")
        {
            bonusInertia = 5;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        bonusInertia = 1;

    }




    void FixedUpdate()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("start");
        }

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")+1);
        input = Vector2.ClampMagnitude(input, 1);
        Vector3 camF = cam.forward;
        Vector3 camR = cam.right;

        camF.y = 0;
        camR.y = 0;
        camF = camF.normalized;
        camR = camR.normalized;


        height = Player.transform.position.y;
        if (dead)
        {
            LoadScene();
        }
        float moveVertical = Input.GetAxisRaw("Vertical"); // Gets the vertical axis values
        float moveHorizontal = Input.GetAxisRaw("Horizontal"); // Gets the horizontal axis values

        if (canPlayerMove) // checks to see if player can move
        {
            RigidBody.AddForce((camF * input.y + camR * input.x) * speed * Time.deltaTime * 5 * bonusInertia) ; // changes the values of the transform according to the movement times speed times the time between the last frame
        }
    }
    void LoadScene()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(nextSceneToLoad);
    }
}
