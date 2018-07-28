using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float fallSpeed;
    public bool death;
    private bool start;
    public GameObject GameOverText;
    public GameObject ExitButtonLeg;
    public GameObject RetryButtonLeg;
    public Button RetryButton;
    public GameObject deathScore;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;
    public Text LevelCountText;
    private int level;
    private int leveltmp;
    public Material Level1Material;
    public Material Level2Material;
    public Material Level3Material;
    public Material Level4Material;
    public Material Level5Material;
    public Slider BlueSlider;

    // Use this for initialization
    void Start()
    {
        level = int.Parse(LevelCountText.text);
        leveltmp = 0;
        rb = GetComponent<Rigidbody>();
        death = false;
        Button retry = RetryButton.GetComponent<Button>();
        retry.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        GameOverText.SetActive(false);
        ExitButtonLeg.SetActive(false);
        RetryButtonLeg.SetActive(false);
        deathScore.SetActive(false);
        Text1.SetActive(true);
        Text2.SetActive(true);
        Text3.SetActive(true);
        Text4.SetActive(true);
        Text5.SetActive(true);
        Text6.SetActive(true);
        Text7.SetActive(true);
        start = false;
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        level = int.Parse(LevelCountText.text);

        if (level == 1)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material = Level1Material;
        }
        else if (level == 2)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material = Level2Material;
        }
        else if (level == 3)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material = Level3Material;
        }
        else if (level == 4)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material = Level4Material;
        }
        else if (level >= 5)
        {
            Renderer rend = GetComponent<Renderer>();
            rend.material = Level5Material;
        }

        if (start == false)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        if (Input.GetKey("space"))
        {
            start = true;
           
        }
        if (death == false)
        {
            Vector3 fall = new Vector3(0.0f, 0.02f * level, -0.03f);
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime + fall);
        }
            fallSpeed = 0.0f;
        }

        
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (BlueSlider.value <= 0)
            {
                death = true;
                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
                audio.Play(44100);
                GameOverText.SetActive(true);
                ExitButtonLeg.SetActive(true);
                RetryButtonLeg.SetActive(true);
            }
            
        }
        if (other.gameObject.tag == "hazard")
        {
        }
        if (other.gameObject.tag == "Blue Fuel")
        {
        }
        if (other.gameObject.tag == "Text")
        {
            Text1.SetActive(false);
            Text2.SetActive(false);
            Text3.SetActive(false);
            Text4.SetActive(false);
            Text5.SetActive(false);
            Text6.SetActive(false);
            Text7.SetActive(false);
        }


    }

    void FixedUpdate()
    {

    }
}
