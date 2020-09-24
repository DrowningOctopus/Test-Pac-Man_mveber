using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGhostController
{
    void ChasePacMan();
    void Scatter();
    void Frighten();
    void SetFearColor();
    void SetRegularColor();
}
