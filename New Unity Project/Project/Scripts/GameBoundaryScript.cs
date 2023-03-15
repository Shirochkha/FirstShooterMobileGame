using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoundaryScript : MonoBehaviour
{
    // конец границы уничтожает объекты
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
