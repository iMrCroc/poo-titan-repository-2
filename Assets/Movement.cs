using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    Vector3 startPos;
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
        startPos = new Vector3(-56.46f,40f,0);
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

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Finish")
        {
            dead = true;
        }
        if (collider.gameObject.tag == "GameController")
        {
            nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }


    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("start");
        }

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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

        if(RigidBody.velocity.magnitude > 35)
        {
            RigidBody.velocity = RigidBody.velocity.normalized * 35;
        }

    }
    void LoadScene()
    {
        PlayerPrefs.SetInt("deaths", PlayerPrefs.GetInt("deaths") + 1);
        StartCoroutine(FogDelay());
        dead = false;
    }

    IEnumerator FogDelay()
    {
        float buffer = Time.time;
        float end = Time.time + 2f;
        while (Time.time < end)
        {
            RenderSettings.fogDensity = Mathf.Lerp(0.01f, 0.2f, Time.time - buffer);
            yield return null;
        }
        transform.position = startPos;
        RigidBody.velocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        buffer = Time.time;
        end = Time.time + 1f;
        float maxFog = RenderSettings.fogDensity;
        while (Time.time < end)
        {
            RenderSettings.fogDensity = Mathf.Lerp(maxFog, 0.01f, Time.time - buffer);
            yield return null;
        }
    }
}
