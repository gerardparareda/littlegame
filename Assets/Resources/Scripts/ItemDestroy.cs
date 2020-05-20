using UnityEngine;

public class ItemDestroy : Interactable
{

    //public Item item;
    public int life;
    public GameObject destroyedVersion;

    private Transform particleFX;
    private ParticleSystem ps;
    GameManager gameManager;

    private void Start()
    {
        particleFX = transform.GetChild(0);
        //particleFX.transform.position = transform.position;
        ps = particleFX.GetComponent<ParticleSystem>();
        gameManager = GameManager.instance;
    }

    public override void Interact()
    {
        base.Interact();
        // Override with the expected behaviour of interacting a destructible object
    }

    public override void Hit()
    {
        base.Hit();
        if (gameManager.player.GetComponent<PlayerController>().usingItem.name == "Martell")
        {
            ps.Stop();
            ps.Clear();
            ps.Play();
            Debug.Log("Hitting " + transform.name);
            Vector3 dir = (transform.position - gameManager.player.transform.position);

            if (life > 1)
            {
                GetComponent<Rigidbody>().AddForce(dir.normalized * 5f, ForceMode.VelocityChange);
                life--;
            }
            else if (life == 1)
            {
                life--;
                Instantiate(destroyedVersion, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}
