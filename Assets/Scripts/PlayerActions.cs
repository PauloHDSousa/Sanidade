using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField]
    float interactRadius = .5f;

    int interactMask = 0;

    bool canInteract = true;
    void Start()
    {
        interactMask = LayerMask.GetMask("Interact");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && canInteract)
        {
            Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactRadius, interactMask);
            foreach (var hitCollider in hitColliders)
            {
                var interact = hitCollider.GetComponent<InteractablesObjects>();
                if (interact != null)
                    interact.GainHumorAndSanity();

                var abajour = hitCollider.GetComponent<AbajourObject>();
                if (abajour != null)
                    abajour.Switch();
            }
        }
    }

    public void SetPlayerInteract(bool _interact)
    {
        canInteract = _interact;
    }
}
