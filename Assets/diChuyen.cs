using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diChuyen : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public int tocDo = 4;
    public float traiPhai;
    public bool isFacingRight = true;
    public Animator anim;
    [SerializeField] AudioSource jumpSound;    
    

    public int doCao;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        traiPhai = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(tocDo * traiPhai, rb.velocity.y);

        if (isFacingRight == true && traiPhai == -1)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            isFacingRight = false;
        }
        if (isFacingRight == false && traiPhai == 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
            isFacingRight = true;
        }
        //animation
        anim.SetFloat("diChuyen", Mathf.Abs(traiPhai));

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("TanCong");
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * doCao, ForceMode2D.Impulse);
            jumpSound.Play();
        }
    }
}
