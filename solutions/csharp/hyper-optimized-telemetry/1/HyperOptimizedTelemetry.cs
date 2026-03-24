using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        // Identify the smallest valid type and its metadata based on the table
        (byte prefix, byte[] bytes) = reading switch
        {
            // Positive Ranges
            > 4_294_967_295L => ((byte)(256 - 8), BitConverter.GetBytes(reading)),
            > 2_147_483_647L => ((byte)4, BitConverter.GetBytes((uint)reading)),
            > 65_535L        => ((byte)(256 - 4), BitConverter.GetBytes((int)reading)),
            >= 0             => ((byte)2, BitConverter.GetBytes((ushort)reading)),
            
            // Negative Ranges
            >= -32_768       => ((byte)(256 - 2), BitConverter.GetBytes((short)reading)),
            >= -2_147_483_648 => ((byte)(256 - 4), BitConverter.GetBytes((int)reading)),
            _                => ((byte)(256 - 8), BitConverter.GetBytes(reading))
        };

        byte[] buffer = new byte[9];
        buffer[0] = prefix;
        Array.Copy(bytes, 0, buffer, 1, bytes.Length);
        
        return buffer;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];

        return prefix switch
        {
            2               => BitConverter.ToUInt16(buffer, 1),
            4               => BitConverter.ToUInt32(buffer, 1),
            (byte)(256 - 2) => BitConverter.ToInt16(buffer, 1),
            (byte)(256 - 4) => BitConverter.ToInt32(buffer, 1),
            (byte)(256 - 8) => BitConverter.ToInt64(buffer, 1),
            // Note: 8 is not a valid prefix based on the test expectations for these ranges
            _               => 0 
        };
    }
}