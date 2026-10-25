"""
A small COLLADA (.dae) geometry reader for Blender 5, which no longer ships a COLLADA importer. It reads triangle,
polylist and polygon meshes (positions, UVs), node transforms from the visual scene, and each material's diffuse
texture, which is enough for static props such as the 3TD Fantasy Ruins pack. Animation, skinning, lights and cameras
are ignored.
"""
import os
import xml.etree.ElementTree as ET

import bpy
from mathutils import Matrix


def _ns(root):
    return root.tag[: root.tag.index("}") + 1] if root.tag.startswith("{") else ""


def load(path):
    """Imports the file and returns the new objects."""
    tree = ET.parse(path)
    root = tree.getroot()
    ns = _ns(root)
    q = lambda tag: ns + tag
    folder = os.path.dirname(path)
    up_axis = (root.findtext(".//%s/%s" % (q("asset"), q("up_axis"))) or "Y_UP").strip()
    unit = root.find(".//%s/%s" % (q("asset"), q("unit")))
    scale = float(unit.get("meter", "1")) if unit is not None else 1.0

    # images and materials -> Blender materials with the diffuse texture
    images = {}
    for img in root.iter(q("image")):
        f = img.findtext(".//" + q("init_from"))
        if f:
            p = os.path.normpath(os.path.join(folder, f.replace("file:///", "").replace("file://", "")))
            if not os.path.exists(p):  # exported with the author's absolute paths: look beside the .dae instead
                want = os.path.basename(f.replace("\\", "/")).lower()
                p = next((os.path.join(folder, x) for x in os.listdir(folder) if x.lower() == want), p)
            images[img.get("id")] = p
    effects = {}
    for eff in root.iter(q("effect")):
        tex = eff.find(".//%s/%s" % (q("diffuse"), q("texture")))
        sampler_src = None
        if tex is not None:
            tid = tex.get("texture")
            # texture -> sampler2D -> surface -> image id (COLLADA 1.4), or the image id directly
            for np_ in eff.iter(q("newparam")):
                if np_.get("sid") == tid:
                    src = np_.findtext(".//" + q("source"))
                    for np2 in eff.iter(q("newparam")):
                        if np2.get("sid") == src:
                            sampler_src = np2.findtext(".//" + q("init_from"))
            sampler_src = sampler_src or tid
        effects[eff.get("id")] = images.get(sampler_src)
    materials = {}
    for mat in root.iter(q("material")):
        ie = mat.find(q("instance_effect"))
        tex = effects.get(ie.get("url", "#")[1:]) if ie is not None else None
        m = bpy.data.materials.new(mat.get("name") or mat.get("id"))
        m.use_nodes = True
        if tex and os.path.exists(tex):
            nt = m.node_tree
            bsdf = next(n for n in nt.nodes if n.type == "BSDF_PRINCIPLED")
            node = nt.nodes.new("ShaderNodeTexImage")
            node.image = bpy.data.images.load(tex, check_existing=True)
            nt.links.new(node.outputs["Color"], bsdf.inputs["Base Color"])
        materials[mat.get("id")] = m

    # geometries
    meshes = {}
    for geom in root.iter(q("geometry")):
        mesh_el = geom.find(q("mesh"))
        if mesh_el is None:
            continue
        sources = {}
        for src in mesh_el.findall(q("source")):
            fa = src.find(q("float_array"))
            acc = src.find(".//" + q("accessor"))
            if fa is None or acc is None:
                continue
            vals = [float(v) for v in (fa.text or "").split()]
            stride = int(acc.get("stride", "1"))
            sources[src.get("id")] = [vals[i:i + stride] for i in range(0, len(vals) - stride + 1, stride)]
        vert_el = mesh_el.find(q("vertices"))
        vert_src = None
        if vert_el is not None:
            for inp in vert_el.findall(q("input")):
                if inp.get("semantic") == "POSITION":
                    vert_src = inp.get("source")[1:]
        positions = sources.get(vert_src, [])
        verts = [tuple(p[:3]) for p in positions]
        faces, face_mats, loop_uvs = [], [], []
        mat_slots = []
        for prim in list(mesh_el):
            tag = prim.tag.replace(ns, "")
            if tag not in ("triangles", "polylist", "polygons"):
                continue
            inputs = prim.findall(q("input"))
            stride = max(int(i.get("offset", "0")) for i in inputs) + 1
            voff = next(int(i.get("offset", "0")) for i in inputs if i.get("semantic") == "VERTEX")
            uv_in = next((i for i in inputs if i.get("semantic") == "TEXCOORD"), None)
            uvs = sources.get(uv_in.get("source")[1:], []) if uv_in is not None else []
            uoff = int(uv_in.get("offset", "0")) if uv_in is not None else None
            sym = prim.get("material")
            if sym not in mat_slots:
                mat_slots.append(sym)
            slot = mat_slots.index(sym)
            if tag == "polygons":
                plists = [[int(v) for v in (p.text or "").split()] for p in prim.findall(q("p"))]
                counts = [len(p) // stride for p in plists]
                idx = [v for p in plists for v in p]
            else:
                idx = [int(v) for v in (prim.findtext(q("p")) or "").split()]
                if tag == "triangles":
                    counts = [3] * (len(idx) // (3 * stride))
                else:
                    counts = [int(v) for v in (prim.findtext(q("vcount")) or "").split()]
            k = 0
            for n in counts:
                face, fuv = [], []
                for j in range(n):
                    base = (k + j) * stride
                    face.append(idx[base + voff])
                    if uoff is not None and uvs:
                        fuv.append(tuple(uvs[idx[base + uoff]][:2]))
                k += n
                if len(set(face)) >= 3:
                    faces.append(face)
                    face_mats.append(slot)
                    loop_uvs.append(fuv)
        me = bpy.data.meshes.new(geom.get("name") or geom.get("id"))
        me.from_pydata(verts, [], faces)
        if any(loop_uvs):
            uvl = me.uv_layers.new(name="UVMap")
            li = 0
            for face, fuv in zip(faces, loop_uvs):  # from_pydata lays loops out face by face
                if len(fuv) == len(face):
                    for j, uv in enumerate(fuv):
                        uvl.data[li + j].uv = uv
                li += len(face)
        for p, s in zip(me.polygons, face_mats):
            p.material_index = s
        meshes[geom.get("id")] = (me, mat_slots)
        me.validate()

    # the visual scene: place each instanced geometry with its node transform
    out = []
    axis = Matrix(((1, 0, 0, 0), (0, 0, -1, 0), (0, 1, 0, 0), (0, 0, 0, 1))) if up_axis == "Y_UP" else Matrix.Identity(4)
    axis = Matrix.Scale(scale, 4) @ axis

    def walk(node, parent):
        mtx = parent.copy()
        for child in list(node):
            t = child.tag.replace(ns, "")
            vals = [float(v) for v in (child.text or "").split()] if t in ("matrix", "translate", "rotate", "scale") else []
            if t == "matrix" and len(vals) == 16:
                mtx = mtx @ Matrix([vals[0:4], vals[4:8], vals[8:12], vals[12:16]])
            elif t == "translate":
                mtx = mtx @ Matrix.Translation(vals)
            elif t == "rotate":
                import math
                mtx = mtx @ Matrix.Rotation(math.radians(vals[3]), 4, vals[:3])
            elif t == "scale":
                mtx = mtx @ Matrix.Diagonal((*vals, 1.0))
        for ig in node.findall(q("instance_geometry")):
            gid = ig.get("url", "#")[1:]
            if gid not in meshes:
                continue
            me, slots = meshes[gid]
            binds = {b.get("symbol"): b.get("target", "#")[1:] for b in ig.iter(q("instance_material"))}
            if len(me.materials) == 0:
                for s in slots:
                    me.materials.append(materials.get(binds.get(s, s)))
            ob = bpy.data.objects.new(node.get("name") or gid, me)
            ob.matrix_world = axis @ mtx
            bpy.context.scene.collection.objects.link(ob)
            out.append(ob)
        for sub in node.findall(q("node")):
            walk(sub, mtx)

    for vs in root.iter(q("visual_scene")):
        for node in vs.findall(q("node")):
            walk(node, Matrix.Identity(4))
    if not out:  # no visual scene: place each geometry once
        for gid, (me, slots) in meshes.items():
            ob = bpy.data.objects.new(gid, me)
            ob.matrix_world = axis
            bpy.context.scene.collection.objects.link(ob)
            out.append(ob)
    return out
