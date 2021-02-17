using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rebelbyte.UI
{
    /// <summary>
    /// UI Class for Indicator over GameObjects
    /// </summary>
    public class IndicatorUI : MonoBehaviour
    {
        void LateUpdate()
        {
            transform.LookAt(Camera.main.transform);
            transform.Rotate(0, 180, 0);
        }
    }
}
