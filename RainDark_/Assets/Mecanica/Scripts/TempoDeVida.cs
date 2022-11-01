using UnityEngine;

public class TempoDeVida : MonoBehaviour
{
    [SerializeField] private float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

}
