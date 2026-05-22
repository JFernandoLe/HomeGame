using UnityEngine;

namespace CameraDoorScript
{
    public class CameraOpenDoor : MonoBehaviour
    {
        public float DistanceOpen = 5;

        void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(
                    transform.position,
                    transform.forward,
                    out hit,
                    DistanceOpen))
            {
                Debug.Log("Golpeando: " + hit.transform.name);

                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    Debug.Log("BOTON A");

                    hit.transform.SendMessage(
                        "OpenDoor",
                        SendMessageOptions.DontRequireReceiver
                    );
                }
            }
        }
    }
}