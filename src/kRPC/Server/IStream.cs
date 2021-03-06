namespace KRPC.Server
{
    /// <summary>
    /// A non-generic stream.
    /// </summary>
    interface IStream
    {
        /// <summary>
        /// Returns true if the stream contains data to read.
        /// </summary>
        bool DataAvailable { get; }

        /// <summary>
        /// Close the stream and free its resources.
        /// </summary>
        void Close ();
    }

    /// <summary>
    /// A generic stream, from which values of type In can be read and values of type Out can be written.
    /// </summary>
    interface IStream<TIn,TOut> : IStream
    {
        /// <summary>
        /// Read a single value from the stream.
        /// </summary>
        TIn Read ();

        /// <summary>
        /// Read multiple values from the stream, into buffer starting at offset
        /// and up to the end of the buffer.
        /// </summary>
        int Read (TIn[] buffer, int offset);

        /// <summary>
        /// Read multiple values from the stream, into buffer starting at offset
        /// and up to the end of the buffer or size items, whichever comes first.
        /// </summary>
        int Read (TIn[] buffer, int offset, int size);

        /// <summary>
        /// Write a value to the stream.
        /// </summary>
        void Write (TOut value);

        /// <summary>
        /// Write multiple values to the stream.
        /// </summary>
        void Write (TOut[] buffer);
    }
}
