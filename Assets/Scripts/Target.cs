using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour
{
    private const float TIME_TO_DESTROY = 10F;

    public float upforce = 1f;
    public float sideforce = .1f;

    private Vector3 spawnPoint;
    //float lifeTime = 10f;

    [SerializeField]
    private int maxHP = 1;
    private int currentHP;

    [SerializeField]
    private int scoreAdd = 10;

    //new Rigidbody rigidbody;

    private void Start()
    {
        this.gameObject.transform.position = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0F, 1F), 1F, transform.position.z));
        float xforce = Random.Range(-sideforce, sideforce);
        float yforce = Random.Range(upforce, upforce);

        currentHP = maxHP;
        Destroy(gameObject, TIME_TO_DESTROY);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int collidedObjectLayer = collision.gameObject.layer;

        if (collidedObjectLayer.Equals(Utils.BulletLayer))
        {
            Destroy(collision.gameObject);

            currentHP -= 1;

            if (currentHP <= 0)
            {
                Player player = FindObjectOfType<Player>();

                if (player != null)
                {
                    player.ApplyScore(10);
                }

                Destroy(gameObject);
            }
        }
        else if (collidedObjectLayer.Equals(Utils.PlayerLayer) || collidedObjectLayer.Equals(Utils.KillVolumeLayer))
        {
            Player player = FindObjectOfType<Player>();

            if (player != null)
            {
                player.ApplyDamage(1);

            }

            Destroy(gameObject);
        }
    }// eso es de gio no funciono

   /* public new void Instantiate()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.isKinematic = true;
        spawnPoint = transform.position;
    }

    public void Begin(Vector3 position)
    {
        transform.position = position;
        rigidbody.velocity = Vector3.zero;
        rigidbody.isKinematic = false;
        throw new System.NotImplementedException();
        Invoke("End", lifeTime);
    }

    public void End()
    {
        transform.position = spawnPoint;
        throw new System.NotImplementedException();
    }*/
}