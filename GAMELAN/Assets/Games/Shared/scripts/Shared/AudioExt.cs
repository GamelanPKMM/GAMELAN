using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioExt : MonoBehaviour {

    private void OnDestroy()
    {
        AudioController.getInstance().removeSound(this.gameObject);
    }
}
