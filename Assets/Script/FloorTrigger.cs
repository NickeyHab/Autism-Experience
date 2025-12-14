using UnityEngine;
using UnityEngine.Playables;

public class FloorTrigger : MonoBehaviour
{
    [SerializeField]
    private PlayableDirector timelineDirector;

    private const string PlayerTag = "Player";
    private bool triggered = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        Debug.Log("Tag: '" + collision.gameObject.tag + "' | Expected: '" + PlayerTag + "'");
        if (!triggered && collision.gameObject.CompareTag(PlayerTag))
        {
            triggered = true;

            if (timelineDirector != null)
            {
                timelineDirector.enabled = true;
                timelineDirector.Play();
            }
        }
    }
}
