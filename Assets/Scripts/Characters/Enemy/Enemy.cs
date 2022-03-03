using UnityEngine;

public class Enemy : Character
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out BlastWave blastWave))
        {
            gameObject.SetActive(false);
        }
    }
}