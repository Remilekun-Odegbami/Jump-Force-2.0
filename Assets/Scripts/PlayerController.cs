using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioSource playerAudio;
    public float jumpForce = 15;
    public float gravityModifier;
    public bool isOnGround = true;

    private AudioManager playerAudioManager;


    // Start is called before the first frame update
    void Start()
    {
        // helps get the component of the rigibody of the player component 
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudioManager = FindObjectOfType<AudioManager>();

        // this multiplies gravity by the modifier given in unity
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // FOR PC
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !GameManager.isGameOver)
        {
            // ForceMode.Impulse is a built in Vector3 method used to apply a force 
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // when the shift button is pressed the player jumps
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            Debug.Log("Jumping");
            dirtParticle.Stop();
            playerAudioManager.Play("Jump");
        }

        // FOR MOBILE
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && !GameManager.isGameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // when the shift button is pressed the player jumps
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudioManager.Play("Jump");
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            // this enables us know when the player is back to the ground
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            GameManager.isGameOver = true;
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudioManager.Play("Crash");
        }
    }

    public void StartGame()
    {
        GameManager.isGameStarted = true;
    }

}
