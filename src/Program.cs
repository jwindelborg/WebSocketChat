using System;
using System.Threading;
using RedHttpServerCore;
using RedHttpServerCore.Response;
using System.Text.Encodings.Web;

namespace ChatRoom.NETCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new RedHttpServer(5000, "public");
            var rman = new RoomManager();

            server.Get("/", async (req, res) =>
            {
                await res.RenderPage("pages/index.ecs", new RenderParams
                {
                    {"url", "Main"}
                });
            });

            server.Get("/:room", async (req, res) =>
            {
                var room = System.Net.WebUtility.UrlDecode(req.Params["room"]);
                await res.RenderPage("pages/index.ecs", new RenderParams
                {
                    {"url", room}
                });
            });

            server.WebSocket("/ws/:room", async (req, wsd) =>
            {
                var room = System.Net.WebUtility.UrlDecode(req.Params["room"]).ToLowerInvariant();
                rman.Join(room, wsd);

            });
            server.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
