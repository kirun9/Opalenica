namespace Opalenica;

using System.Text;

public class CheckSumBinaryReader : BinaryReader
{
    public CheckSumBinaryReader(Stream input) : base(input)
    {
    }

    public CheckSumBinaryReader(Stream input, Encoding encoding) : base(input, encoding)
    {
    }

    public CheckSumBinaryReader(Stream input, Encoding encoding, Boolean leaveOpen) : base(input, encoding, leaveOpen)
    {
    }

    /*public bool Read(out byte[] buffer)
    {
        //read stream anc check if last byte is equal to checksum but do not return last byte


    }*/

    public bool Read(out byte[] buffer, int index, int count)
    {
        byte[] ibuffer = new byte[count];
        int read = base.Read(ibuffer, index, count);
        buffer = new byte[read - 1];
        int i = 0;
        for (; i < buffer.Length; i++)
        {
            buffer[i] = ibuffer[i];
        }
        byte checksum = CalculateCheckSum(buffer);
        return (checksum & ibuffer[i]) == 1;
    }

    private static byte CalculateCheckSum(byte[] byteData)
    {
        byte chkSumByte = 0x00;
        for (int i = 0; i < byteData.Length; i++)
        {
            chkSumByte ^= byteData[i];
        }
        return chkSumByte;
    }
}
