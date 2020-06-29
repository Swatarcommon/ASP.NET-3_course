using System;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace Lab_01
{
    public class LNZSocketHandler : IHttpHandler
    {

        private WebSocket socket;

        private readonly ReaderWriterLockSlim Locker = new ReaderWriterLockSlim();

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
                context.AcceptWebSocketRequest(WebSocketRequest);
        }

        private async Task WebSocketRequest(AspNetWebSocketContext context)
        {
            Locker.EnterWriteLock();
            try
            {
                socket = context.WebSocket;
            }
            finally
            {
                Locker.ExitWriteLock();
            }

            while (true)
            {
                var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(DateTime.Now.ToLongDateString()));

                Thread.Sleep(5000);

                try
                {
                    if (socket.State == WebSocketState.Open)
                    {
                        await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                    }
                }

                catch (ObjectDisposedException)
                {
                    Locker.EnterWriteLock();
                    try
                    {
                        socket.Abort();
                    }
                    finally
                    {
                        Locker.ExitWriteLock();
                    }
                }
            }
        }
    }
}