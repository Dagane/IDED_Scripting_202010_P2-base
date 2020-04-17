using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Ipool
{
    void Instantiate();

    void Begin(Vector3 position);
    void End();


}

