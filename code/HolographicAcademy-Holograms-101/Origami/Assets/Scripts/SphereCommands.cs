using UnityEngine;

public class SphereCommands : MonoBehaviour
{
    Vector3 orientationPosition;

    void Start()
    {
        orientationPosition = this.transform.localPosition;
    }
    // Called by GazeGestureManager when the user performs a Select gesture
    void OnSelect()
    {
        // If the sphere has no Rigidbody component, add one to enable physics.
        if (!this.GetComponent<Rigidbody>())
        {
            var rigidbody = this.gameObject.AddComponent<Rigidbody>();
            rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        }
    }

    void OnReset()
    {
        var rigidbody = this.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            DestroyImmediate(rigidbody);
        }

        this.transform.localPosition = orientationPosition;
    }

    void OnDrop()
    {
        OnSelect();
    }
}