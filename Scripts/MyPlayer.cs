using Photon.Pun;
using Photon.Voice.PUN;
using UnityEngine;

public class MyPlayer : MonoBehaviour
{
    #region Public Fields

    #endregion
    #region Private Fields
    private float movementX { get; set; }

    private Rigidbody2D rigidBody { get; set; }
    private SpriteRenderer sr { get; set; }
    private Animator anim { get; set; }

    private PhotonView photonView { get; set; }
    private PhotonVoiceView photonVoiceView { get; set; }

    private float moveForce { get; set; } = 10f;
    private float jumpForce { get; set; } = 11f;

    private string WALK_ANIMATION = "Walk";
    private string GROUND = "Ground";

    private bool isGrounded = true;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        photonView = GetComponent<PhotonView>();
        photonVoiceView = GetComponent<PhotonVoiceView>();
    }

    private void Update()
    {
        if (photonView.IsMine && MenuManager.isWalking)
        {
            PlayerMoveKeyboard();
            AnimatePlayer();
            PlayerJump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
        }
    }
    #endregion

    #region Private Methods
    private void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            photonView.RPC("FlipFalse", RpcTarget.AllBuffered);
            anim.SetBool(WALK_ANIMATION, true);
        }
        else if (movementX < 0)
        {
            photonView.RPC("FlipTrue", RpcTarget.AllBuffered);
            anim.SetBool(WALK_ANIMATION, true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
    #endregion

    #region Private Methods PUN RPC
    [PunRPC]
    private void FlipTrue()
    {
        sr.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        sr.flipX = false;
    }
    #endregion
}
