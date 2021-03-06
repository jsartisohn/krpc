using System;
using System.Net.Sockets;

namespace KRPC.Server.Net
{
    sealed class TCPStream : IStream<byte,byte>
    {
        readonly NetworkStream stream;

        public TCPStream (NetworkStream stream)
        {
            this.stream = stream;
        }

        public bool DataAvailable {
            get {
                try {
                    return stream.DataAvailable;
                } catch {
                    return false;
                }
            }
        }

        public byte Read ()
        {
            throw new NotImplementedException ();
        }

        public int Read (byte[] buffer, int offset)
        {
            return stream.Read (buffer, offset, buffer.Length - offset);
        }

        public int Read (byte[] buffer, int offset, int size)
        {
            return stream.Read (buffer, offset, size);
        }

        public void Write (byte value)
        {
            throw new NotImplementedException ();
        }

        public void Write (byte[] buffer)
        {
            stream.Write (buffer, 0, buffer.Length);
        }

        public void Close ()
        {
            stream.Close ();
        }
    }
}
