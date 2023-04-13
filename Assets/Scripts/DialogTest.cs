using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTest : MonoBehaviour
{
    [SerializeField]
    private DialogSystem dialogSystem;
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => dialogSystem.UpdataDialog(0, true));
    }
}
