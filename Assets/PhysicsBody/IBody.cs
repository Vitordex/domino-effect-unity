using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace domino_effect.PhysicsBody {
  public interface IBody {
    GameObject gameObject { get; }

    (Vector3, Quaternion) InitialValues { get; }
    void Rollback();

    void ApplyForce();
  }
}
