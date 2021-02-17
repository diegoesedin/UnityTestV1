using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rebelbyte.Character
{
    /// <summary>
    /// UI Class for Indicator on Character's head
    /// </summary>
    public class CharacterIndicator : MonoBehaviour
    {
        void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}
