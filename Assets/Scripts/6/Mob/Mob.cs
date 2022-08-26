using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    private NavMeshAgent agent;

    public ParticleSystem destroyParticle;
    public AudioSource destroyAudio;
    public GameObject modelGameObject;

    public UnityEvent onCreated;
    public UnityEvent onDestroyed;

    public float destroyDelay;
    public bool isDestroyed = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Start()
    {
        agent.SetDestination(new Vector3(0f, 2f, 1f));
        // agent.speed *= Random.Range(0.8f, 1.5f);
        agent.speed = 3f;

        onCreated?.Invoke();
        MobManager.Instance.OnSpawned(this);
    }

    public void Destroyed()
    {
        if (isDestroyed)
            return;

        isDestroyed = true;

        // destroyParticle.Play();
        // destroyAudio.Play();

        agent.enabled = false;
        modelGameObject.SetActive(false);

        Destroy(gameObject, destroyDelay);

        onDestroyed?.Invoke();
        MobManager.Instance.OnDestroyed(this);
    }

}
