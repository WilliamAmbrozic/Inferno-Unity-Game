using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Rigidbody rb;
    public GameObject PS;
    private float fuelCount;
    public bool hitStone;
    private float blueFuelCount;
    private bool start;
    private int levelCount;
    public float jumpSpeed;
    public Vector3 Position;
    public float SavedHorizontal;
    public float SavedVertical;
    private bool death;
    public float fallSpeed;
    public float reFuelRate;
    public Slider FuelSlider;
    private bool hitWall;
    public float blueReFuelRate;
    public GameObject GameOverText;
    public Slider blueFuelSlider;
    private bool decreaseBlueFuel;
    public float blueDecreaseRate;
    public GameObject Shield;
    public float blueJumpValue;
    public float nextlevelJump;
    public int startingFuel;
    public BoxCollider Box;
    public Text Score;
    private int ScoreInt;
    public Text deathScoretext;
    public GameObject deathScore;
    public GameObject greenfuel;
    public GameObject greenfuelText;
    public GameObject bluefuel;
    public GameObject bluefuelText;
    public GameObject scndCam;
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject four;
    public GameObject BP;
    public GameObject FOV;
    public GameObject FOVSlider;
    public GameObject FOVText;
    public Button RetryButton;
    public Button ExitButton;
    private Vector3 SpawnPosition;
    public GameObject Screen;
    public GameObject SpawnPlate;
    public GameObject ExitButtonLeg;
    public GameObject RetryButtonLeg;
    public float fuelDecreaseRate;
    public Rigidbody FallingRock;
    public GameObject NextLevelText;
    public GameObject AllFuel;
    public GameObject AllFuelBlue;
    public GameObject key1;
    public GameObject key2;
    public GameObject key3;
    public GameObject key4;
    public GameObject key5;
    public GameObject key6;
    public GameObject key7;
    public Text LevelCountText;
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform Spawn4;
    public Transform Spawn5;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject Title;
    public GameObject TitleText1;
    public GameObject TitleText2;

    // Use this for initialization
    void Start () {

        Button retry = RetryButton.GetComponent<Button>();
        retry.onClick.AddListener(TaskOnClick);

        Button Exit = ExitButton.GetComponent<Button>();
        Exit.onClick.AddListener(TaskOnClickExit);

        rb = GetComponent<Rigidbody>();
        decreaseBlueFuel = false;
        fuelCount = startingFuel;
        levelCount = 2;
        start = false;
        death = false;
        hitStone = false;
        Score.text = "";
        deathScoretext.text = "";
        LevelCountText.text = "";
        NextLevelText.GetComponent<TextMesh>().text = "";

        CountText();
        CountLevel();
	}
    void TaskOnClickExit()
    {
        Application.Quit();
    }
    void TaskOnClick()
    {
        hitStone = false;
        fuelCount = startingFuel;
        transform.position = new Vector3(-0.02226352f, 16.798f, -3.860089f);
        Screen.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
        transform.rotation = Quaternion.Euler(0, 360, 0);
        gameObject.SetActive(true);
        SpawnPlate.SetActive(true);
        deathScore.SetActive(false);
        greenfuel.SetActive(true);
        greenfuelText.SetActive(true);
        bluefuel.SetActive(true);
        bluefuelText.SetActive(true);
        scndCam.SetActive(true);
        one.SetActive(true);
        two.SetActive(true);
        three.SetActive(true);
        four.SetActive(true);
        FOV.SetActive(true);
        FOVSlider.SetActive(true);
        FOVText.SetActive(true);
        GameOverText.SetActive(false);
        ExitButtonLeg.SetActive(false);
        RetryButtonLeg.SetActive(false);
        text1.SetActive(true);
        text2.SetActive(true);
        text3.SetActive(true);
        text4.SetActive(true);
        text5.SetActive(true);
        text6.SetActive(true);
        text7.SetActive(true);
        start = false;
        blueFuelCount = 0;
        levelCount = 2;
    }
    // Update is called once per frame
    void Update () {
        ScoreInt = ((int)rb.position.y - 16) + (levelCount - 2) * 56;
        Score.text = "" + ScoreInt;
        deathScoretext.text = Score.text;
        LevelCountText.text = "" +(levelCount - 1);
        NextLevelText.GetComponent<TextMesh>().text = "Level " + levelCount;
        if (start == false)
        {
            FallingRock.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }
        if  (start == true)
        {
            rb.constraints = RigidbodyConstraints.None;
            FallingRock.constraints = RigidbodyConstraints.None;
        }
        if (hitStone == true)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        }
        FuelSlider.value = fuelCount;
        blueFuelSlider.value = (int)blueFuelCount;
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            SavedHorizontal = Input.GetAxis("Horizontal");
            PS.SetActive(true);
        }
        else
        {
            PS.SetActive(false);
        }
        if (Input.GetAxis("Vertical") > 0 || Input.GetAxis("Vertical") < 0)
        {
            SavedVertical = Input.GetAxis("Vertical");
            PS.SetActive(true);
        }
        else
        {
            PS.SetActive(false);
        }
        if (decreaseBlueFuel == true && blueFuelCount > 0)
        {
            blueFuelCount-= blueDecreaseRate * Time.deltaTime;
            Shield.SetActive(true);
        }
        if (blueFuelCount <= 0)
        {
            decreaseBlueFuel = false;
            Shield.SetActive(false);
        }
        if (death == false && hitStone == false)
        {
            Position = new Vector3(SavedHorizontal, 0.0f, SavedVertical);
            transform.rotation = Quaternion.LookRotation(Position);
        }
        else
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime);
        }
        transform.rotation = Quaternion.LookRotation(Position);
        if (Input.GetKey("space") && fuelCount > 0 && hitWall == false && hitStone == false)
        {
            Title.SetActive(false);
            TitleText1.SetActive(false);
            TitleText2.SetActive(false);
            start = true;
            Vector3 jump = new Vector3(0.0f, 15.0f, 0.0f);
            rb.AddForce(jump * jumpSpeed * Time.deltaTime);
            BP.SetActive(true);

            fuelCount-= Time.deltaTime * fuelDecreaseRate;
        }
        else
        {
            BP.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "hazard")
        {
            fuelCount += (int)reFuelRate;
            other.gameObject.SetActive(false);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);

        }
        if (other.gameObject.tag == "Blue Fuel")
        {
            if (blueFuelCount == 0)
            {
                blueFuelCount += (int)blueReFuelRate;
            }
            else if (blueFuelCount > 0 && blueFuelCount < 200)
            {
                blueFuelCount += 200 - blueFuelCount;
            }
            other.gameObject.SetActive(false);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
            decreaseBlueFuel = true;

        }
        if (other.gameObject.tag == "lava")
        {
            if (blueFuelCount <= 0)
            {
                gameObject.SetActive(false);
                deathScore.SetActive(true);
                greenfuel.SetActive(false);
                greenfuelText.SetActive(false);
                bluefuel.SetActive(false);
                bluefuelText.SetActive(false);
                scndCam.SetActive(false);
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                FOV.SetActive(false);
                FOVSlider.SetActive(false);
                FOVText.SetActive(false);
                for (int i = 0; i < AllFuel.transform.childCount; i++)
                {
                    GameObject child = AllFuel.transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(true);
                }
                for (int i = 0; i < AllFuelBlue.transform.childCount; i++)
                {
                    GameObject child = AllFuelBlue.transform.GetChild(i).gameObject;
                    if (child != null)
                        child.SetActive(true);
                }
            }
            else
            {
                if (transform.position.y <= 18)
                {
                    transform.position = Spawn1.position;
                }
                else if (transform.position.y > 18 && transform.position.y < 21)
                {
                    transform.position = Spawn2.position;
                }
                else if (transform.position.y > 21 && transform.position.y < 36)
                {
                    transform.position = Spawn3.position;
                }
                else if (transform.position.y > 36 && transform.position.y < 47)
                {
                    transform.position = Spawn4.position;
                }
                else if (transform.position.y > 47 && transform.position.y < 61)
                {
                    transform.position = Spawn5.position;
                }
                blueFuelCount = 0;
            }
           
        }
        if (other.gameObject.tag == "Next Level")
        {

            Vector3 jump = new Vector3(0.0f, nextlevelJump, 0.0f);
            rb.AddForce(jump * jumpSpeed * Time.deltaTime);
            levelCount++;
            hitStone = false;
            fuelCount = startingFuel;
            transform.position = new Vector3(-0.02226352f, 16.798f, -3.860089f);
            Screen.transform.position = new Vector3(0.0f, 5.0f, 0.0f);
            transform.rotation = Quaternion.Euler(0, 360, 0);
            start = false;
            gameObject.SetActive(true);
            SpawnPlate.SetActive(true);
            deathScore.SetActive(false);
            greenfuel.SetActive(true);
            greenfuelText.SetActive(true);
            bluefuel.SetActive(true);
            bluefuelText.SetActive(true);
            scndCam.SetActive(true);
            one.SetActive(true);
            two.SetActive(true);
            three.SetActive(true);
            four.SetActive(true);
            FOV.SetActive(true);
            FOVSlider.SetActive(true);
            FOVText.SetActive(true);
            GameOverText.SetActive(false);
            ExitButtonLeg.SetActive(false);
            RetryButtonLeg.SetActive(false);
            key1.SetActive(false);
            key2.SetActive(false);
            key3.SetActive(false);
            key4.SetActive(false);
            key5.SetActive(false);
            key6.SetActive(false);
            key7.SetActive(false);
            for (int i = 0; i < AllFuel.transform.childCount; i++)
            {
                GameObject child = AllFuel.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(true);
            }
            for (int i = 0; i < AllFuelBlue.transform.childCount; i++)
            {
                GameObject child = AllFuelBlue.transform.GetChild(i).gameObject;
                if (child != null)
                    child.SetActive(true);
            }
            Renderer rend = GetComponent<Renderer>();
            rend.material.shader = Shader.Find("Specular");
            rend.material.SetColor("_SpecColor", Color.red);

        }
        if (other.gameObject.tag == "wall")
        {
            if (blueFuelCount <= 0)
            {
                hitStone = true;
                rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                deathScore.SetActive(true);
                greenfuel.SetActive(false);
                greenfuelText.SetActive(false);
                bluefuel.SetActive(false);
                bluefuelText.SetActive(false);
                scndCam.SetActive(false);
                one.SetActive(false);
                two.SetActive(false);
                three.SetActive(false);
                four.SetActive(false);
                FOV.SetActive(false);
                FOVSlider.SetActive(false);
                FOVText.SetActive(false);
                GameOverText.SetActive(true);
                ExitButtonLeg.SetActive(true);
                RetryButtonLeg.SetActive(true);
            }
            else
            {
                if (transform.position.y <= 18)
                {
                    transform.position = Spawn1.position;
                }
                else if (transform.position.y > 18 && transform.position.y < 21)
                {
                    transform.position = Spawn2.position;
                }
                else if (transform.position.y > 21 && transform.position.y < 36)
                {
                    transform.position = Spawn3.position;
                }
                else if (transform.position.y > 36 && transform.position.y < 47)
                {
                    transform.position = Spawn4.position;
                }
                else if (transform.position.y > 47 && transform.position.y < 61)
                {
                    transform.position = Spawn5.position;
                }
                blueFuelCount = 0;
            }
        }
        if (other.gameObject.tag == "level")
        {
            other.gameObject.SetActive(false);
            levelCount++;
            CountLevel();
        }

    }

    void CountText()
    {


    }
    void CountLevel()
    {


    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed * Time.deltaTime);
        

    }
}
