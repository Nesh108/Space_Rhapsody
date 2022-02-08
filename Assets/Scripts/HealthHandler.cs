using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    [Header("References")]
    public SpriteRenderer InvincibilityRenderer;

    [Header("Settings")]
    public int MaxHealth = 3;
    public float InvincibilityDuration = 2f;

    private int _currentHealth;
    private float _invincibilityTimer;

    void Start()
    {
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

        /////
        // TEST - Hit
        if (Input.GetKeyUp(KeyCode.H))
        {
            Hit();
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
            // L'invincibilità non è attiva
            _currentHealth--;
            Debug.Log("Sono stato colpito: " + _currentHealth);
            _invincibilityTimer = InvincibilityDuration;
        }
    }

    void Die()
    {
        Debug.Log("Sono Morto!");
        Destroy(gameObject);
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

}
