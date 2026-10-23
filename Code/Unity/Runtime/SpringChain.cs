// Project Ascend — lightweight spring bones for ears, tails, manes, cap rims, feathers, slime lobes.
// Verlet tail simulation (same idea as VRM spring bones). Values come from motion.json springs[]:
//   stiffness 0..1 (pull back to the rest pose), damping 0..1 (velocity loss), gravity (m/s² scale, negative floats up).
using System.Collections.Generic;
using UnityEngine;

namespace Ascend.Monsters
{
    public class SpringChain : MonoBehaviour
    {
        public Transform rootBone;
        [Min(1)] public int length = 2;
        [Range(0, 1)] public float stiffness = 0.4f;
        [Range(0, 1)] public float damping = 0.2f;
        public float gravity = 0.2f;
        [Tooltip("On: the animated pose each frame is the rest pose (use for bones your clips animate, e.g. tails).\nOff: the bind pose is the rest pose (ears, lobes, feathers that clips don't touch).")]
        public bool followAnimation = false;
        [Tooltip("Extra wobble added on hit: call Impulse(direction).")]
        public float impulseScale = 1f;

        class Node
        {
            public Transform t;
            public Quaternion restLocalRot;
            public Vector3 localAxis;  // bone direction in local space
            public float boneLength;
            public Vector3 prevTip, currTip;
        }

        readonly List<Node> _nodes = new List<Node>();
        Vector3 _pendingImpulse;

        void Start() => Init();

        public void Init()
        {
            _nodes.Clear();
            var t = rootBone ? rootBone : transform;
            float lastLen = 0.1f;
            for (int i = 0; i < length && t != null; i++)
            {
                Transform child = t.childCount > 0 ? t.GetChild(0) : null;
                Vector3 axis = child ? child.localPosition : Vector3.up * lastLen;
                float len = child ? child.localPosition.magnitude * t.lossyScale.x : lastLen;
                if (axis.sqrMagnitude < 1e-8f) axis = Vector3.up;
                var n = new Node { t = t, restLocalRot = t.localRotation, localAxis = axis.normalized, boneLength = Mathf.Max(len, 0.001f) };
                n.currTip = n.prevTip = t.position + t.rotation * n.localAxis * n.boneLength;
                _nodes.Add(n);
                lastLen = n.boneLength;
                t = child;
            }
        }

        public void Impulse(Vector3 worldDir) => _pendingImpulse += worldDir * impulseScale;

        void LateUpdate()
        {
            float dt = Mathf.Min(Time.deltaTime, 1f / 30f);
            if (dt <= 0f) return;
            Vector3 imp = _pendingImpulse; _pendingImpulse = Vector3.zero;
            foreach (var n in _nodes)
            {
                // rest direction given the parent's current rotation
                Quaternion parentRot = n.t.parent ? n.t.parent.rotation : Quaternion.identity;
                Quaternion rest = followAnimation ? n.t.localRotation : n.restLocalRot; // animator has already written this frame's pose
                Vector3 restDir = parentRot * rest * n.localAxis;
                Vector3 velocity = (n.currTip - n.prevTip) * (1f - damping);
                Vector3 next = n.currTip + velocity
                               + restDir * (stiffness * 4f * dt)          // pull toward the rest pose
                               + Vector3.down * (gravity * dt)            // gravity (negative = float)
                               + imp * dt;
                next = n.t.position + (next - n.t.position).normalized * n.boneLength; // keep bone length
                n.prevTip = n.currTip;
                n.currTip = next;
                n.t.localRotation = rest;
                Vector3 from = n.t.rotation * n.localAxis;
                n.t.rotation = Quaternion.FromToRotation(from, next - n.t.position) * n.t.rotation;
            }
        }
    }
}
