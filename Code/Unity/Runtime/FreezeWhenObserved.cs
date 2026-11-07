// AETHWYRD — "it never moves while you watch it" (Smiling Scarecrow, Dread/Horror monsters).
// If the monster is inside the camera view and not hidden behind walls, its agent stops and its animation freezes.
using UnityEngine;
using UnityEngine.AI;

namespace Ascend.Monsters
{
    public class FreezeWhenObserved : MonoBehaviour
    {
        public Camera viewer;
        public Renderer[] renderers;
        public LayerMask occluders = ~0;
        public float checkInterval = 0.1f;
        [Tooltip("Treat as observed only when closer than this (0 = any distance).")]
        public float maxDistance = 0f;

        public bool IsObserved { get; private set; }

        NavMeshAgent _agent;
        Animator _anim;
        float _timer, _savedAnimSpeed = 1f;
        readonly Plane[] _planes = new Plane[6];

        void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _anim = GetComponentInChildren<Animator>();
            if (renderers == null || renderers.Length == 0) renderers = GetComponentsInChildren<Renderer>();
        }

        void Update()
        {
            _timer -= Time.deltaTime;
            if (_timer > 0f) return;
            _timer = checkInterval;
            var cam = viewer ? viewer : Camera.main;
            if (!cam) return;
            bool seen = Check(cam);
            if (seen == IsObserved) return;
            IsObserved = seen;
            if (_agent && _agent.isOnNavMesh) _agent.isStopped = seen;
            if (_anim)
            {
                if (seen) { _savedAnimSpeed = _anim.speed; _anim.speed = 0f; }
                else _anim.speed = _savedAnimSpeed;
            }
        }

        bool Check(Camera cam)
        {
            Vector3 eye = cam.transform.position;
            if (maxDistance > 0f && (transform.position - eye).sqrMagnitude > maxDistance * maxDistance) return false;
            GeometryUtility.CalculateFrustumPlanes(cam, _planes);
            foreach (var r in renderers)
            {
                if (!r || !GeometryUtility.TestPlanesAABB(_planes, r.bounds)) continue;
                // visible if any of: bounds center, top, bottom has a clear line of sight
                Vector3 c = r.bounds.center, e = r.bounds.extents;
                if (Clear(eye, c) || Clear(eye, c + Vector3.up * e.y * 0.8f) || Clear(eye, c - Vector3.up * e.y * 0.8f)) return true;
            }
            return false;
        }

        bool Clear(Vector3 from, Vector3 to)
        {
            if (!Physics.Linecast(from, to, out var hit, occluders, QueryTriggerInteraction.Ignore)) return true;
            return hit.transform == transform || hit.transform.IsChildOf(transform);
        }
    }
}
