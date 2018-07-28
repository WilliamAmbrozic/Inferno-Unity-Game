using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RockFalling : MonoBehaviour {

    public Rigidbody rb;
    public float RockStartPosition;
    public float impactSpeed;
    public float FallSpeed;
    public float Range;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lava")
        {
            Vector3 fall = new Vector3(Random.Range(-Range, Range), RockStartPosition, Random.Range(-Range, Range));
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime + fall);
            rb.velocity = new Vector3(0, FallSpeed, 0);
        }
        if (other.gameObject.tag == "Player")
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
        }
        if (other.gameObject.tag == "Right Protection")
        {
            Vector3 impact = new Vector3(10.0f, 0.0f, 0.0f);
            rb.AddForce(impact * impactSpeed * Time.deltaTime);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
        }
        if (other.gameObject.tag == "Left Protection")
        {
            Vector3 impact = new Vector3(-10.0f, 10.0f, 0.0f);
            rb.AddForce(impact * impactSpeed * Time.deltaTime);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
        }
        if (other.gameObject.tag == "Up Protection")
        {
            Vector3 impact = new Vector3(0.0f, 0.0f, 10.0f);
            rb.AddForce(impact * impactSpeed * Time.deltaTime);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
        }
        if (other.gameObject.tag == "Down Protection")
        {
            Vector3 impact = new Vector3(0.0f, 0.0f, -10.0f);
            rb.AddForce(impact * impactSpeed * Time.deltaTime);
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            audio.Play(44100);
        }
    }
}
