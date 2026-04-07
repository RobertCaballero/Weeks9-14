using UnityEngine;
using UnityEngine.Events;

public class Spikes : MonoBehaviour
{

    public int damage = 10;
    public player player;
    public UnityEvent OnEnter;
    public UnityEvent OnExit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyDamage()
    {
        player.TakingDamage(damage);
    }


}
