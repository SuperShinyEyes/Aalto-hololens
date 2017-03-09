### Get component
```csharp
GazeStabilizer gazeStabilizer;
gazeStabilizer = GetComponent<GazeStabilizer>();
```

### GazeManager
```csharp
public class GazeManager : Singleton<GazeManager>
    {
        [Tooltip("Maximum gaze distance for calculating a hit.")]
        public float MaxGazeDistance = 5.0f;

        [Tooltip("Select the layers raycast should target.")]
        public LayerMask RaycastLayerMask = Physics.DefaultRaycastLayers;

        /// <summary>
        /// Physics.Raycast result is true if it hits a Hologram.
        /// </summary>
        public bool Hit { get; private set; }

        /// <summary>
        /// HitInfo property gives access
        /// to RaycastHit public members.
        /// </summary>
        public RaycastHit HitInfo { get; private set; }

        /// <summary>
        /// Position of the user's gaze.
        /// </summary>
        public Vector3 Position { get; private set; }

        /// <summary>
        /// RaycastHit Normal direction.
        /// </summary>
        public Vector3 Normal { get; private set; }

        private GazeStabilizer gazeStabilizer;
        private Vector3 gazeOrigin;
        private Vector3 gazeDirection;

        void Awake()
        {
            /* TODO: DEVELOPER CODING EXERCISE 3.a */

            // 3.a: GetComponent GazeStabilizer and assign it to gazeStabilizer.
            gazeStabilizer =GetComponent<GazeStabilizer>();


        }

        private void Update()
        {
            // 2.a: Assign Camera's main transform position to gazeOrigin.
            Camera.main.transform.position = gazeOrigin;

            // 2.a: Assign Camera's main transform forward to gazeDirection.
            Camera.main.transform.forward = gazeDirection;

            // 3.a: Using gazeStabilizer, call function UpdateHeadStability.
            // Pass in gazeOrigin and Camera's main transform rotation.
            gazeStabilizer.UpdateHeadStability(gazeOrigin, Camera.main.transform.rotation);

            // 3.a: Using gazeStabilizer, get the StableHeadPosition and
            // assign it to gazeOrigin.
            gazeOrigin = gazeStabilizer.StableHeadPosition;

            UpdateRaycast();
        }

        /// <summary>
        /// Calculates the Raycast hit position and normal.
        /// </summary>
        private void UpdateRaycast()
        {
            /* TODO: DEVELOPER CODING EXERCISE 2.a */

            // 2.a: Create a variable hitInfo of type RaycastHit.
            RaycastHit hitInfo;

            // 2.a: Perform a Unity Physics Raycast.
            // Collect return value in public property Hit.
            // Pass in origin as gazeOrigin and direction as gazeDirection.
            // Collect the information in hitInfo.
            // Pass in MaxGazeDistance and RaycastLayerMask.
            Hit = Physics.Raycast(gazeOrigin, gazeDirection, out hitInfo, MaxGazeDistance, RaycastLayerMask);


            // 2.a: Assign hitInfo variable to the HitInfo public property
            // so other classes can access it.
            this.HitInfo = hitInfo;

            if (Hit)
            {
                // If raycast hit a hologram...

                // 2.a: Assign property Position to be the hitInfo point.
                Position = hitInfo.point;
                // 2.a: Assign property Normal to be the hitInfo normal.
                Normal = hitInfo.normal;
            }
            else
            {
                // If raycast did not hit a hologram...

                // Save defaults ...

                // 2.a: Assign Position to be gazeOrigin plus MaxGazeDistance times gazeDirection.
                Position = gazeOrigin + MaxGazeDistance * gazeDirection;
                // 2.a: Assign Normal to be the user's gazeDirection.
                Normal = gazeDirection;
            }
        }
    }
```

###
```csharp
public class CursorManager : Singleton<CursorManager>
   {
       [Tooltip("Drag the Cursor object to show when it hits a hologram.")]
       public GameObject CursorOnHolograms;

       [Tooltip("Drag the Cursor object to show when it does not hit a hologram.")]
       public GameObject CursorOffHolograms;

       void Awake()
       {
           if (CursorOnHolograms == null || CursorOffHolograms == null)
           {
               return;
           }

           // Hide the Cursors to begin with.
           CursorOnHolograms.SetActive(false);
           CursorOffHolograms.SetActive(false);
       }

       void Update()
       {
           /* TODO: DEVELOPER CODING EXERCISE 2.b */

           if (GazeManager.Instance == null || CursorOnHolograms == null || CursorOffHolograms == null)
           {
               return;
           }

           if (GazeManager.Instance.Hit)
           {
               // 2.b: SetActive true the CursorOnHolograms to show cursor.
               CursorOnHolograms.SetActive(true);
               // 2.b: SetActive false the CursorOffHolograms hide cursor.
               CursorOffHolograms.SetActive(false);
           }
           else
           {
               // 2.b: SetActive true CursorOffHolograms to show cursor.
               CursorOffHolograms.SetActive(true);
               CursorOnHolograms.SetActive(false);
               // 2.b: SetActive false CursorOnHolograms to hide cursor.

           }

           // 2.b: Assign gameObject's transform position equals GazeManager's instance Position.
           gameObject.transform.position = GazeManager.Instance.Position;

           // 2.b: Assign gameObject's transform up vector equals GazeManager's instance Normal.
           gameObject.transform.up = GazeManager.Instance.Normal;
       }
   }
```

### Detach from Unity's physics system.
```csharp
foreach (Collider collider in GameObject.GetComponents<Collider>()) {
  Destroy(collider);
}

foreach (Rigidbody rigidbody in GameObject.GetComponents<Rigidbody>()) {
  Destroy(rigidbody);
}
```

###
```csharp

```

###
```csharp

```

###
```csharp

```

###
```csharp

```

###
```csharp

```

###
```csharp

```

###
```csharp

```

###
```csharp

```

###
```csharp

```
