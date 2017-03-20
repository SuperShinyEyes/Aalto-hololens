using UnityEngine;

public class TapToPlaceParent : MonoBehaviour {

    bool placing = false;

    void OnSelect()
    {
        placing = !placing;

        if (placing)
        {
            SpatialMapping.Instance.DrawVisualMeshes = true;
        }

        else
        {
            SpatialMapping.Instance.DrawVisualMeshes = false;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (placing)
        {
            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            RaycastHit hitInfo;
            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 30.0f, SpatialMapping.PhysicsRaycastMask))
            {
                this.transform.parent.position = hitInfo.point;

                Quaternion toQuat = Camera.main.transform.localRotation;
                toQuat.x = 0;
                toQuat.z = 0;
                this.transform.parent.rotation = toQuat;

            }

        }		
	}
}
