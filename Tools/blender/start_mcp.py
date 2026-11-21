"""Bring Blender up already connectable to the MCP server.

The MCP for Blender add-on talks to Claude over a socket, but the add-on only starts that socket when somebody
clicks "Connect to Claude" in the sidebar. Launched with this script, Blender enables the add-on and starts the
server itself, so a session can reach it without anyone touching the GUI:

    "E:/SteamLibrary/steamapps/common/Blender/blender.exe" --python Tools/blender/start_mcp.py

Then, from Claude, `get_addon_status` should answer. If it does not, check that port 9876 is listening
(`netstat -ano | findstr 9876`) — a second Blender already holding the port is the usual reason.

Measured on 2026-11-21 with Blender 5.3.0 and add-on 1.8: works, with the add-on reporting protocol 15 against an
expected 16. The server says to update with `uvx mcp-for-blender install-addon`; that is deliberately NOT done here,
because the older protocol works through fallbacks and an update needs a Blender restart to take effect.
"""
import bpy
import addon_utils

ADDON = "blender_mcp"
PORT = 9876


def _start():
    try:
        bpy.context.scene.blendermcp_port = PORT
        bpy.ops.blendermcp.start_server()
        print("[start_mcp] server listening on %d" % PORT)
    except Exception as exc:                     # noqa: BLE001 - report rather than die inside a timer
        print("[start_mcp] could not start the server: %s" % exc)
    return None                                  # one shot


def main():
    try:
        addon_utils.enable(ADDON, default_set=True, persistent=True)
        print("[start_mcp] enabled add-on %s" % ADDON)
    except Exception as exc:                     # noqa: BLE001
        print("[start_mcp] could not enable %s: %s" % (ADDON, exc))
        return
    # The add-on registers its scene properties during its own load, so starting the server immediately races it.
    bpy.app.timers.register(_start, first_interval=2.0)


main()
