using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public float jumpPower;
    public int itemCount;
    public GameManagerLogic manager;
    bool isJump;
    public AudioClip[] clip;
    AudioSource audios;  
    Rigidbody rigid;
    void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audios = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !isJump) 
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }
    }
    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        rigid.AddForce(new Vector3(h, 0, v), ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Debug.Log($"Item Count Up : {itemCount} ");
            itemCount++;
            audios.clip = clip[0];
            audios.Play();
            other.gameObject.SetActive(false);
            manager.GetItem(itemCount);
        }
        else if(other.tag == "Point")
        {
             if(itemCount >= manager.totalItemCount)
             {
                //Game Clear! && Next Stage
                if (manager.stage == 4)
                {
                    SceneManager.LoadScene(5);
                }
                else
                {
                    SceneManager.LoadScene(manager.stage + 1);
                }
             }
            else
            {
                //Restart Stage
                SceneManager.LoadScene(manager.stage);
            }
        }
        if (other.tag == "Replay")
        {
            SceneManager.LoadScene(1);
        }
    }
}
