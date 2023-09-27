using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DataConfiguration
{
    [Serializable]
    public class Attribute
    {
        [field: SerializeField] public AttributeType Type { get; private set; }
        [field: SerializeField] public float Value { get; private set; }
    }
}

