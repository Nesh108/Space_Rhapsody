using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [Header("References")]
    public SpriteRenderer InvincibilityRenderer;
    public GameObject ExplosionObject;
    public Animator ShipAnimator;

    [Header("Settings")]
    public int MaxHealth = 3;
    public float InvincibilityDuration = 2f;

    private int _currentHealth;
    private float _invincibilityTimer;
    private bool _isPlayer;

    void Start()
    {
        _isPlayer = gameObject.CompareTag("Player");

        _currentHealth = MaxHealth;

        if (InvincibilityRenderer != null)
        {
            InvincibilityRenderer.enabled = false;
        }

        _invincibilityTimer = 0f;
    }

    void Update()
    {
        if(_currentHealth <= 0)
        {
            Die();
        }

        HandleInvincibility();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet"))
        {
            Hit();
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("Enemy"))
        {
            Hit();
            collision.GetComponent<HealthHandler>().Die();
        }
    }

    void HandleInvincibility()
    {
        if (_invincibilityTimer > 0)
        {
            _invincibilityTimer -= Time.deltaTime;

            if (InvincibilityRenderer != null)
            {
                InvincibilityRenderer.enabled = true;
            }
        }
        else
        {
            if (InvincibilityRenderer != null)
            {
                InvincibilityRenderer.enabled = false;
            }
        }
    }

    void Hit()
    {
        if (_invincibilityTimer <= 0)
        {
            if(ShipAnimator != null)
            {
                ShipAnimator.SetTrigger("IsHit");
            }

            // L'invincibilità non è attiva
            _currentHealth--;
            Debug.Log("Sono stato colpito: " + _currentHealth);
            _invincibilityTimer = InvincibilityDuration;
        }
    }

    public void Die()
    {
        // Creiamo un'esplosione
        GameObject explosionObject = GameObject.Instantiate(ExplosionObject, transform.position, ExplosionObject.transform.rotation, null);
        Destroy(explosionObject, explosionObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length);

        if (_isPlayer)
        {
            // RICARICA LIVELLO
            Destroy(gameObject);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");

        }
        else
        {
            // Distruggiamo la nave
            Destroy(gameObject);
        }
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

}
